using System;
using System.Data;
using System.Windows.Forms;
using New_WSC_DLL;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Reflection;
using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using System.IO;
using System.Linq;

namespace BefInventory_DelOutTempArea
{
    public partial class Form1 : WSC_Sample_Form
    {
        String Login_Server = "PXWMS_N", Login_Site_no = "";
        BindingSource BS_Repl = new BindingSource();
        DataSet DS_Repl = new DataSet();
        DataTable DT_Repl = new DataTable();
        string UserWorkNum = "", UserPC = "";
        string FileName_OutPutExcel = "";

        //此表單的LoaderFormInfo
        XSC.LoaderFormInfo fFormInfo;

        //此LoginUserId所使用的sqlClientAccess
        XSC.ClientAccess.sqlClientAccess sca;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void New_WSC_DLL_Form_Load(object sender, EventArgs e)
        {
            base.New_WSC_DLL_Form_Load(sender, e);

            //批次的解說文
            toolTip1.SetToolTip(txb_SupdId, "輸入完供應商代號, 按下Tab");
            cmb_BatchID.SelectedIndex = 0;

            //取得此表單的LoaderFormInfo
            fFormInfo = XSC.ClientLoader.FormInfo(this);
            //透過LoginUserId取得sqlClientAccess
            sca = XSC.ClientAccess.UserAccess.sqlUserAccess(fFormInfo.LoginUserId);

            #region 帳號權限判斷
            Boolean IsCorrectUser = false;
            bool IsPXWMS_N = false, IsPXWMS_S = false, IsPXWMS_C = false;
            //取得工號
            string cmdstring = "Select EMPID From XSC_Menu_Userlist where XSC_UserID=@userid";
            object[] objParam = { "@userid", SqlDbType.NVarChar.ToString(), fFormInfo.LoginUserId };
            DataTable dt_87 = sca.GetDataTable("EEPDC", cmdstring, objParam, 0);
            if (dt_87.Rows.Count > 0)
            {
                IsCorrectUser = true;
                UserWorkNum = dt_87.Rows[0][0].ToString();
            }

            if (UserWorkNum != "")
            {
                //取得兩倉權限
                //觀音
                cmdstring = "select top 1 0 from employee_data where S_empd_id=@userid";
                object[] objParam1 = { "@userid", SqlDbType.NVarChar.ToString(), UserWorkNum };
                DataTable dt_PXWMS_N = sca.GetDataTable("PXWMS_N", cmdstring, objParam1, 0);
                if (dt_PXWMS_N.Rows.Count > 0)
                {
                    IsPXWMS_N = true;
                }

                //岡山
                DataTable dt_PXWMS_S = sca.GetDataTable("PXWMS_S", cmdstring, objParam1, 0);
                if (dt_PXWMS_S.Rows.Count > 0)
                {
                    IsPXWMS_S = true;
                }

                //梧棲
                DataTable dt_PXWMS_C = sca.GetDataTable("PXWMS_C_Plus2", cmdstring, objParam1, 0);
                if (dt_PXWMS_C.Rows.Count > 0)
                {
                    IsPXWMS_C = true;
                }
            }

            if (IsPXWMS_N == false && IsPXWMS_S == false && IsPXWMS_C == false)
            {
                IsCorrectUser = false;
            }
            #endregion

            if (!IsCorrectUser)
            {
                MessageBox.Show("帳號無法對應三倉權限，請洽資訊部人員", ":<");
                SetMasterBindingNavigator(null);
                SetButtonEnable("L");
                return;
            }

            #region 設定新刪修會用到的物件
            List<object> Enable_objlist = new List<object>();
            Enable_objlist.Add(gridControl1);
            this.MasterObj = Enable_objlist;
            #endregion

            SetMasterBindingNavigator(BS_Repl);
            SetButtonEnable("FL EX help");

            #region 權限對應三倉
            bindingNavigatorEditButton.Text = "重新產生資料(&E)";
            if (IsPXWMS_N)
                cmb_SiteNo.Items.Add(new Item("觀音", "PXWMS_N"));
            if (IsPXWMS_S)
                cmb_SiteNo.Items.Add(new Item("岡山", "PXWMS_S"));
            if (IsPXWMS_C)
                cmb_SiteNo.Items.Add(new Item("梧棲", "PXWMS_C_Plus2"));
            cmb_SiteNo.SelectedIndex = 0;
            #endregion

            ResizeForm.ResizeForm.WSC_Resize(this, 1);

            //gridControl1.DataSource = BS_Repl;
            dateTimePicker1.Value = DateTime.Now.AddDays(3);
            DevExpressGridFunctions.GridviewSetup(gridView1);
            DevExpressGridFunctions.GridviewSetup(gridView2);
            DevExpressGridFunctions.GridviewSetup(gridView3);
            btn_Close_panel1.ForeColor = Color.White;
            btn_Close_panel1.BackColor = Color.Red;
            Lbl_UserId.Text = fFormInfo.LoginUserId;
            Lbl_WorkNum.Text = UserWorkNum;
            Lbl_Version.Text = "版本：" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();

            #region 獲取廠商清單
            DataTable dt_VendorList = GetSupdId();
            foreach (DataRow dr in dt_VendorList.Rows)
            {
                cmb_VendorNo.Items.Add(new Item(dr["NewAlias"].ToString(), dr["NewAlias"].ToString()));
            }
            #endregion
        }

        #region 前端按鈕動作
        /// <summary>
        /// 修改->變更為->重新產生暫存區資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void EditButton_Click(object sender, EventArgs e)
        {
            //base.EditButton_Click(sender, e);
            DialogResult dr1 = MessageBox.Show("重跑" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "資料耗時耗資源，確定嗎??", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            StartLoadingShow();
            try
            {
                if (dr1 == DialogResult.Yes)
                {
                    ReDoInvList();
                }
            }
            finally
            {
                CloseLoadingShow();
            }
            MessageBox.Show("產生資料完畢");
        }

        /// <summary>
        /// 倉別:下拉式選單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_SiteNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Login_Server = ((Item)cmb_SiteNo.SelectedItem).Value;
            if (Login_Server == "PXWMS_N")
                Login_Site_no = "DC1";
            else if (Login_Server == "PXWMS_S")
                Login_Site_no = "DC2";
            else if (Login_Server == "PXWMS_C_Plus2")
                Login_Site_no = "DC3";
        }

        /// <summary>
        /// 供應商:下拉式選單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_VendorNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_VendorNo.SelectedItem != null)
            {

                string[] Varstring = ((Item)cmb_VendorNo.SelectedItem).Value.Split(',');
                dateTimePicker1.Value = DateTime.Parse(Varstring[0]);
                txb_SupdId.Text = Varstring[1];
                txb_SupdId_Validated(txb_SupdId, new EventArgs());
            }
        }

        #region 廠商代號+批次
        /// <summary>
        /// 廠商編號變更後，帶出批次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_SupdId_Validated(object sender, EventArgs e)
        {
            panel_BatchID.Enabled = true;

            string GetSupdIdList =
            @"select DISTINCT T_slom_creatdate, batch
            from 廠商盤點_非庫存區_log with(nolock)
            where S_merd_supdid=@vendor_no
            order by T_slom_creatdate DESC";
            object[] obj1 = { "@Date", SqlDbType.Date.ToString(), dateTimePicker1.Value.ToString("yyyy/MM/dd"),
                              "@vendor_no",SqlDbType.VarChar.ToString(),txb_SupdId.Text,
                              "@site_no", SqlDbType.VarChar.ToString(),Login_Site_no};
            DataTable DT_SupdList = sca.GetDataTable("LGDC", GetSupdIdList, obj1, 0);

            cmb_BatchID.Items.Clear();

            if (DT_SupdList.Rows.Count > 0)
            {
                cmb_BatchID.Items.Add(new Item("不指定", ""));
                foreach (DataRow dr in DT_SupdList.Rows)
                    cmb_BatchID.Items.Add(new Item(DateTime.Parse(dr[0].ToString()).ToString("MM/dd HH:mm") + "," + dr[1].ToString(), dr[1].ToString()));
                cmb_BatchID.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 更改廠商代號會隱藏批次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_SupdId_TextChanged(object sender, EventArgs e)
        {
            panel_BatchID.Enabled = false;
        }

        #endregion

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void SearchButton_Click(object sender, EventArgs e)
        {
            StartLoadingShow();
            if (tabControl1.SelectedIndex == 0)
            {
                string ErrMsg = "";
                ErrMsg = GetSlotMerList();
                base.SearchButton_Click(sender, e);
                gridControl1.Enabled = true;

                if (ErrMsg != "")
                {
                    if (gridControl1.DataSource != null)
                        ((DataTable)gridControl1.DataSource).Clear();
                    if (gridControl2.DataSource != null)
                        ((DataTable)gridControl2.DataSource).Clear();
                    CloseLoadingShow();
                    MessageBox.Show(ErrMsg, "錯誤");
                }
            }
            if (tabControl1.SelectedIndex == 1)
            {
                string ErrMsg = "";
                ErrMsg = GetInventoryDate();
                base.SearchButton_Click(sender, e);
                if (ErrMsg != "")
                {
                    CloseLoadingShow();
                    MessageBox.Show(ErrMsg, "錯誤");
                }
            }
            CloseLoadingShow();

            if (tabControl1.SelectedIndex == 0)
            {
                //合併兩個gridcontrol到同一個報表
                FileName_OutPutExcel = DateTime.Now.ToString("yyyyMMdd") + "暫存區查詢";
            }
            else
            {
                FileName_OutPutExcel = DateTime.Now.ToString("yyyyMMdd") + "盤點結果表查詢";
            }

            if (cmb_BatchID.SelectedIndex > 0)
                FileName_OutPutExcel += "_批次_" + ((Item)cmb_BatchID.SelectedItem).Value;
        }

        /// <summary>
        /// 複寫原本的Enable狀態
        /// </summary>
        /// <param name="IwantObj"></param>
        /// <param name="Iwant"></param>
        protected override void Object_Enable(List<object> IwantObj, bool Iwant)
        {
            base.Object_Enable(IwantObj, Iwant);
            gridControl1.Enabled = !gridControl1.Enabled;
        }

        /// <summary>
        /// 儲存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void SaveButton_Click(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width / 3;
            int y = Screen.PrimaryScreen.WorkingArea.Height / 3;
            string Reason = DateTime.Now.ToString("yyyyMMdd") + "盤點除帳";
            string x1 = Interaction.InputBox("輸入除帳原因", "出貨暫存區刪除確認", Reason, x, y);
            //沒有原因退回
            if (x1 == "")
                return;
            else
            {
                //取消也退回
                DialogResult dr1 = MessageBox.Show("確定刪除出貨暫存區帳務？\n原因：" + x1, "第二次確認", MessageBoxButtons.YesNo);
                if (dr1 == DialogResult.No)
                    return;
            }

            DataTable DT_OnlyCount = new DataTable();
            string jobID = DateTime.Now.ToString("yyyyMMddHHmmss");
            string ErrMsg = "";

            foreach (DataRow dr in DT_Repl.Rows)
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    if (Convert.ToInt32(dr["Chk"]) == 1)
                    {
                        object[] objParam = {"@L_slom_sysno",SqlDbType.BigInt.ToString(),dr["L_slom_sysno"].ToString(),
                                             "@UserId",SqlDbType.NVarChar.ToString(),UserWorkNum,
                                            "@jobID",SqlDbType.BigInt.ToString(),jobID};
                        DT_OnlyCount = sca.GetDataTable(Login_Server, "spInventory_Delslotmer", objParam, 1);

                        if (DT_OnlyCount.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(DT_OnlyCount.Rows[0][0]) != 0)
                            {
                                //寫入Log
                                string Log_cmd = "Insert Into RunLog values(@jobID,'BefInv_DelOutTemp',@Date,@cmd,getdate())";
                                string Log_Detail = dr["Site_no"].ToString() + "," + dr["L_slom_sysno"].ToString() + "," + UserWorkNum + "," + UserPC;
                                object[] objParam_Log = {"@jobID",SqlDbType.NVarChar.ToString(),jobID,
                                                        "@Date",SqlDbType.Char.ToString(),jobID.Substring(0,8),
                                                        "@cmd",SqlDbType.NVarChar.ToString(),Log_Detail};
                                sca.GetDataTable("LGDC", Log_cmd, objParam_Log, 0);

                                ErrMsg += Log_Detail + "\n";
                            }
                        }
                        else
                        {
                            ErrMsg = "除帳失敗";
                        }
                    }
                }
            }
            base.SaveButton_Click(sender, e);

            if (ErrMsg != "")
            {
                MessageBox.Show("以下資料已刪除：\n" + ErrMsg + "請確認資料是否正確刪除\n系統自動重新查詢\n");
                bindingNavigatorSearchButton.PerformClick();
            }
        }

        /// <summary>
        /// 匯出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ToExcelButton_Click(object sender, EventArgs e)
        {
            base.ToExcelButton_Click(sender, e);
            if (tabControl1.SelectedIndex == 0)
            {
                if (gridView1.RowCount <= 0)
                {
                    MessageBox.Show("無內容，請重新查詢", "取消儲存");
                    return;
                }
            }
            else
            {
                if (gridView3.RowCount <= 0)
                {
                    MessageBox.Show("無內容，請重新查詢", "取消儲存");
                    return;
                }
            }
            SaveFileDialog OFD = new SaveFileDialog();
            OFD.InitialDirectory = "D:\\";
            OFD.RestoreDirectory = true;
            OFD.Title = "儲存檔案";
            OFD.DefaultExt = "xls";
            OFD.Filter = "Microsoft Office Excel 活頁簿 (*.xls)|*.xls";

            GridControl[] grids;

            if (tabControl1.SelectedIndex == 0)
            {
                //合併兩個gridcontrol到同一個報表
                grids = new GridControl[] { gridControl1 };
            }
            else
            {
                grids = new GridControl[] { gridControl3 };
            }

            OFD.FileName = FileName_OutPutExcel;
            DialogResult chooseOutPut = OFD.ShowDialog();
            if (chooseOutPut == DialogResult.Cancel)
            {
                return;
            }

            //gridview排版
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsPrint.AutoWidth = false;
            gridView1.BestFitColumns();
            gridView2.OptionsView.ColumnAutoWidth = false;
            gridView2.OptionsPrint.AutoWidth = false;
            gridView2.BestFitColumns();
            gridView3.OptionsView.ColumnAutoWidth = false;
            gridView3.OptionsPrint.AutoWidth = false;
            gridView3.BestFitColumns();
            gridView1.AppearancePrint.Row.Font = new Font("Arial Unicode MS", 12);
            gridView1.AppearancePrint.Row.Options.UseFont = true;
            gridView2.AppearancePrint.Row.Font = new Font("Arial Unicode MS", 12);
            gridView2.AppearancePrint.Row.Options.UseFont = true;
            gridView3.AppearancePrint.Row.Font = new Font("Arial Unicode MS", 12);
            gridView3.AppearancePrint.Row.Options.UseFont = true;

            PrintingSystem ps = new PrintingSystem();
            CompositeLink compositeLink = new CompositeLink();
            compositeLink.PrintingSystem = ps;

            foreach (GridControl gc in grids)
            {
                PrintableComponentLink link = new PrintableComponentLink();
                link.Component = gc;

                compositeLink.Links.Add(link);
            }
            compositeLink.CreateDocument();

            //準備輸出
            DevExpress.XtraPrinting.XlsExportOptions XEO = new DevExpress.XtraPrinting.XlsExportOptions();
            XEO.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;
            XEO.ExportMode = XlsExportMode.SingleFile;
            XEO.SheetName = FileName_OutPutExcel;

            DevExpress.XtraPrinting.PdfExportOptions PEO = new PdfExportOptions();
            //PEO.PasswordSecurityOptions.OpenPassword = "123";

            #region 檢查檔案是否能寫入
            bool IsFileLocked = false;
            if (File.Exists(OFD.FileName))
            {
                FileInfo filepath = new FileInfo(OFD.FileName);
                FileStream steam = null;
                try
                {
                    steam = filepath.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch (IOException e1)
                {
                    IsFileLocked = true;
                }
                finally
                {
                    if (steam != null)
                        steam.Close();
                }
            }
            #endregion
            if (IsFileLocked)
            {
                MessageBox.Show("檔案被鎖定，請檢查是否有其他程式正在開啟", "匯出失敗");
                return;
            }
            compositeLink.ExportToXls(OFD.FileName, XEO);
            //gridView1.ExportToXls(OFD.FileName, XEO);
            MessageBox.Show("檔案匯出至 " + OFD.FileName + " 完畢", "匯出成功");

            //gridview排版
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsPrint.AutoWidth = true;
            gridView1.BestFitColumns();
            gridView2.OptionsView.ColumnAutoWidth = true;
            gridView2.OptionsPrint.AutoWidth = true;
            gridView2.BestFitColumns();
            gridView3.OptionsView.ColumnAutoWidth = true;
            gridView3.OptionsPrint.AutoWidth = true;
            gridView3.BestFitColumns();
        }

        /// <summary>
        /// panel1隱藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_panel1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        #endregion

        #region 與資料庫連結
        /// <summary>
        /// 取得2個月內的盤點廠商
        /// </summary>
        /// <returns></returns>
        public DataTable GetSupdId()
        {
            DataTable CateIdList = new DataTable();

            string Sql_cmd =
            @"Select a.vendor_no, NewAlias=convert(varchar,a.inv_date,111)+','+RTRIM(a.vendor_no)+', '+RTRIM(b.alias)
            from (
                select DISTINCT vendor_no,inv_date from ven_inventory_date with(nolock)
                where inv_date between getdate()-60 and getdate()+60
            ) a
            inner join drp.dbo.drp_supplier b with(nolock) on a.vendor_no=b.ID
            order by a.inv_date DESC, a.vendor_no";
            CateIdList = sca.GetDataTable("LGDC", Sql_cmd);

            return CateIdList;
        }

        /// <summary>
        /// 暫存區內容
        /// </summary>
        /// <returns></returns>
        private string GetSlotMerList()
        {
            string ErrMsg = "";

            #region 抓近期盤點廠商
            string GetSupdIdList =
            @"Select DISTINCT VENDOR_NO 
            from VEN_INVENTORY_DATE with(nolock)
            where INV_date=@Date
                  and vendor_no like '%'+@vendor_no+'%'
                  and site_no=@site_no";
            object[] obj1 = { "@Date", SqlDbType.Date.ToString(), dateTimePicker1.Value.ToString("yyyy/MM/dd"),
                              "@vendor_no",SqlDbType.VarChar.ToString(),txb_SupdId.Text,
                              "@site_no", SqlDbType.VarChar.ToString(),Login_Site_no};
            DataTable DT_SupdList = sca.GetDataTable("LGDC", GetSupdIdList, obj1, 0);
            if (DT_SupdList.Rows.Count == 0)
            {
                ErrMsg = "指定日期無盤點廠商資訊";
                return ErrMsg;
            }

            string string_SupdList = "";
            foreach (DataRow dr in DT_SupdList.Rows)
            {
                if (string_SupdList != "")
                    string_SupdList += ",";
                string_SupdList += "'" + dr["VENDOR_NO"].ToString() + "'";
            }
            #endregion

            #region 抓暫存區資料
            string GetList = @"Select * from ";
            if (cmb_BatchID.SelectedIndex <= 0)
            {
                GetList += "[廠商盤點_非庫存區] with(nolock) where site_no=@site_no and S_merd_supdid in (" + string_SupdList + @") ";
            }
            else
            {
                GetList += "[廠商盤點_非庫存區_log] with(nolock) where site_no=@site_no and S_merd_supdid in (" + string_SupdList + @") ";
                GetList += " and batch=@batch ";
                obj1 = obj1.Concat(new[] { "@batch", SqlDbType.VarChar.ToString(), ((Item)cmb_BatchID.SelectedItem).Value }).ToArray();
            }

            if (Chk_WithStock.Checked == false)
                GetList += "and I_picz_type!=1 ";
            GetList += " order by site_no, I_picz_type, S_merd_supdid, S_slom_merdid ";
            DS_Repl = sca.GetDataSet("LGDC", GetList, obj1, 0);
            DT_Repl = DS_Repl.Tables[0];
            if (DT_Repl.Rows.Count == 0)
            {
                ErrMsg = "無暫存區資料\n";
                #region 再次檢查及時庫存
                GetList = @"select S_merd_supdid=SUBSTRING(b.S_merd_supdid,0,5),Tqty=SUM(a.L_slom_1qty-a.L_slom_reserqty+a.L_slom_replqty)
                        from slot_mer a with(nolock)
                        inner join mer_data b with(nolock) 
                        on a.L_slom_merdsysno=b.L_merd_sysno
                        where SUBSTRING(b.S_merd_supdid,0,5) in (" + string_SupdList + @")
                        GROUP BY SUBSTRING(b.S_merd_supdid,0,5)";
                DS_Repl = sca.GetDataSet(Login_Server, GetList, obj1, 0);
                DT_Repl = DS_Repl.Tables[0];
                if (DT_Repl.Rows.Count == 0)
                {
                    ErrMsg += "回查即時庫存也沒有資料\n";
                }
                else
                {
                    DT_Repl.TableName = "DT_Repl";
                    BS_Repl.DataSource = DS_Repl;
                    BS_Repl.DataMember = DT_Repl.TableName;
                    gridControl1.DataSource = DT_Repl;
                    ErrMsg += "Oh...No!即時庫存有資料，請重新產生暫存區結果\n";
                }
                ErrMsg += "廠商名單：" + string_SupdList;
                return ErrMsg;
                #endregion
            }
            DT_Repl.TableName = "DT_Repl";
            BS_Repl.DataSource = DS_Repl;
            BS_Repl.DataMember = DT_Repl.TableName;
            gridControl1.DataSource = DT_Repl;
            #endregion

            #region 抓暫存區統計資料
            var q = from a in DT_Repl.AsEnumerable()
                    group a by new
                    {
                        site_no = a.Field<string>("site_no"),
                        N_basd_name = a.Field<string>("N_basd_name")
                    } into g
                    select new
                    {
                        site_no = g.Key.site_no,
                        N_basd_name = g.Key.N_basd_name,
                        Tqty = g.Sum(x => x.Field<int>("Tqty"))
                    };

            //LINQ to DataTable
            DataTable dt_TotalList = new DataTable();
            dt_TotalList.Columns.Add("site_no", typeof(string));
            dt_TotalList.Columns.Add("N_basd_name", typeof(string));
            dt_TotalList.Columns.Add("Tqty", typeof(int));
            foreach (var qRow in q)
            {
                DataRow dr = dt_TotalList.NewRow();
                dr[0] = qRow.site_no;
                dr[1] = qRow.N_basd_name;
                dr[2] = qRow.Tqty;
                dt_TotalList.Rows.Add(dr);
            }
            gridControl2.DataSource = dt_TotalList;
            panel1.Visible = true;
            #endregion

            return ErrMsg;
        }

        /// <summary>
        /// 查詢盤點結果表
        /// </summary>
        /// <returns></returns>
        private string GetInventoryDate()
        {
            string ErrMsg = "";

            #region 抓近期盤點廠商
            string GetSupdIdList =
            @"Select DISTINCT VENDOR_NO 
            from VEN_INVENTORY_DATE with(nolock) 
            where INV_date=@Date
                  and vendor_no like '%'+@vendor_no+'%'
                  and site_no=@site_no";
            object[] obj1 = { "@Date", SqlDbType.Date.ToString(), dateTimePicker1.Value.ToString("yyyy/MM/dd"),
                              "@vendor_no",SqlDbType.VarChar.ToString(),txb_SupdId.Text,
                              "@site_no", SqlDbType.VarChar.ToString(),Login_Site_no};
            DataTable DT_SupdList = sca.GetDataTable("LGDC", GetSupdIdList, obj1, 0);
            if (DT_SupdList.Rows.Count == 0)
            {
                ErrMsg = "指定日期無盤點廠商資訊";
                return ErrMsg;
            }

            string string_SupdList = "";
            foreach (DataRow dr in DT_SupdList.Rows)
            {
                if (string_SupdList != "")
                    string_SupdList += ",";
                string_SupdList += "'" + dr["VENDOR_NO"].ToString() + "'";
            }
            #endregion

            #region 查詢盤點結果表
            GetSupdIdList =
            @"Select 關貿日期,
廠商編號,
貨號,
品名規格,
關貿庫存量,
總進貨量,
WMS實盤量,
WMS出貨暫存區,
WMS退貨區,
WMS退廠區,
WMS總庫存,
關貿WMS帳差
            from 廠商盤點_試算盤點結果表 with(nolock)
            where 廠商編號 in (" + string_SupdList + @") 
                  and 倉別=@site_no";
            object[] obj2 = { "@Date", SqlDbType.Date.ToString(), dateTimePicker1.Value.ToString("yyyy/MM/dd"),
                              "@vendor_no",SqlDbType.VarChar.ToString(),txb_SupdId.Text,
                              "@site_no", SqlDbType.VarChar.ToString(),Login_Site_no};
            DataTable DT_SupdList2 = sca.GetDataTable("LGDC", GetSupdIdList, obj2, 0);
            if (DT_SupdList2.Rows.Count == 0)
            {
                ErrMsg = "指定日期無盤點結果表";
                return ErrMsg;
            }
            gridControl3.DataSource = DT_SupdList2;
            return "";
            #endregion
        }

        /// <summary>
        /// 產生暫存區資料
        /// </summary>
        private string ReDoInvList()
        {
            string ErrMsg = "";

            #region 抓近期盤點廠商
            string GetSupdIdList =
            @"Select DISTINCT VENDOR_NO 
            from VEN_INVENTORY_DATE with(nolock) 
            where INV_date=@Date
                  and vendor_no like '%'+@vendor_no+'%'
                  and site_no=@site_no";
            object[] obj1 = { "@Date", SqlDbType.Date.ToString(), dateTimePicker1.Value.ToString("yyyy/MM/dd"),
                              "@vendor_no",SqlDbType.VarChar.ToString(),txb_SupdId.Text,
                              "@site_no", SqlDbType.VarChar.ToString(),Login_Site_no};
            DataTable DT_SupdList = sca.GetDataTable("LGDC", GetSupdIdList, obj1, 0);
            if (DT_SupdList.Rows.Count == 0)
            {
                ErrMsg = "指定日期無盤點廠商資訊";
                return ErrMsg;
            }

            foreach (DataRow dr in DT_SupdList.Rows)
            {
                object[] obj2 = { "@vendor_no", "NVarChar", dr["VENDOR_NO"].ToString() };
                sca.GetDataTable("LGDC", "[盤點_非庫存區_重滾]", obj2, 1);
            }
            #endregion

            return ErrMsg;
        }
        #endregion

        //下拉式選單內容
        public class Item
        {
            public string Name;
            public string Value;
            public Item(string name, string value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }
    }
}
