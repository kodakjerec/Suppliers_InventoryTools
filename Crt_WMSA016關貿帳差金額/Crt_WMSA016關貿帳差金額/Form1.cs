using System;
using System.ComponentModel;
using New_WSC_DLL;
using System.Threading;
using System.Data;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;

namespace Crt_WMSA016
{
    public partial class Form1 : WSC_Sample_Form
    {
        //此表單的LoaderFormInfo
        XSC.LoaderFormInfo fFormInfo;

        //此LoginUserId所使用的sqlClientAccess
        XSC.ClientAccess.sqlClientAccess sca;

        System.Data.DataTable dt_DieDate;   //查詢帳務日期
        System.Data.DataTable dt_OutPut;    //準備輸出

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //取得此表單的LoaderFormInfo
            fFormInfo = XSC.ClientLoader.FormInfo(this);
            //透過LoginUserId取得sqlClientAccess
            sca = XSC.ClientAccess.UserAccess.sqlUserAccess(fFormInfo.LoginUserId);

            SetButtonEnable("L");
            ResizeForm.ResizeForm.WSC_Resize(this, 1);
            label1.MaximumSize = new System.Drawing.Size(button1.Size.Width, 0);
            label2.MaximumSize = label1.MaximumSize;

            comboBox1.SelectedIndex = 0;
        }

        #region 準備產生資料
        private void button1_Click(object sender, EventArgs e)
        {
            bkW_CrtPaper.RunWorkerAsync();

        }

        private void bkW_CrtPaper_DoWork(object sender, DoWorkEventArgs e)
        {
            StartLoadingShow();
            //object[] obj1 = new object[] { "@date", "NVarChar", dateTimePicker1.Value.ToString("yyyy/MM/dd") };
            //sca.GetDataTable("LGDC", "exec [盤點_試算盤點結果表] '0123',@date,'' ", obj1, 0);
            string SqlConnection = "Data Source=192.168.100.175;Initial Catalog=LGDC;User ID=ncf;Password=ksi;Connect Timeout=0;Application Name=PXLNET";
            string cmd_Query = "盤點_試算盤點結果表";
            try
            {
                using (SqlConnection Conn = new SqlConnection(SqlConnection))
                {
                    SqlCommand SqlCmd = new SqlCommand(cmd_Query, Conn);
                    SqlCmd.CommandTimeout = 0;
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlCmd.Parameters.Add("@step", SqlDbType.VarChar);
                    SqlCmd.Parameters.Add("@date", SqlDbType.VarChar);
                    SqlCmd.Parameters.Add("@vendor_no", SqlDbType.VarChar);

                    SqlCmd.Parameters["@step"].Value = "0123";
                    SqlCmd.Parameters["@date"].Value = dateTimePicker1.Value.ToString("yyyy/MM/dd");
                    SqlCmd.Parameters["@vendor_no"].Value = "";

                    SqlCmd.Connection.Open();
                    SqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void bkW_CrtPaper_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CloseLoadingShow();

            tabControl1.SelectedIndex += 1;
        }
        #endregion

        #region 下載資料
        private void button2_Click(object sender, EventArgs e)
        {
            string ErrMsg = "";
            string site_no = comboBox1.SelectedItem.ToString().Split(',')[0];
            SaveFileDialog OFD = new SaveFileDialog();
            OFD.InitialDirectory = "D:\\";
            OFD.RestoreDirectory = true;
            OFD.Title = "儲存檔案";
            OFD.DefaultExt = "xlsx";
            OFD.Filter = "Microsoft Office Excel 活頁簿 (*.xlsx)|*.xlsx";

            //準備輸出
            string FileName = "廠商盤點_試算盤點結果表" + dateTimePicker1.Value.ToString("yyyyMMdd")+"_"+site_no;

            #region 檢查檔案是否能寫入
            OFD.FileName = FileName;
            OFD.ShowDialog();
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
                    ErrMsg = e1.Message;
                    IsFileLocked = true;
                }
                finally
                {
                    if (steam != null)
                        steam.Close();
                }
            }

            if (IsFileLocked)
            {
                MessageBox.Show("檔案被鎖定，請檢查是否有其他程式正在開啟" + Environment.NewLine + ErrMsg, "匯出失敗");
                return;
            }
            #endregion

            DateTime timeStart = DateTime.Now;

            try
            {
                string qry =
                @"select * 
            from 廠商盤點_試算盤點結果表 with(nolock)
            where (關貿庫存量!=0 or WMS總庫存!=0 or 總進貨量!=0)
            and [倉別]=@site_no
            order by 倉別, 廠商編號, 貨號";
                dt_OutPut = sca.GetDataTable("LGDC", qry, new object[] { "@site_no", SqlDbType.VarChar, site_no }, 0);


                Microsoft.Office.Interop.Excel.Application objXL = null;
                Microsoft.Office.Interop.Excel.Workbook objWB = null;

                objXL = new Microsoft.Office.Interop.Excel.Application();
                objXL.Visible = false;
                objXL.DisplayAlerts = false;

                objWB = objXL.Workbooks.Add(1);
                object useDefaultValue = Type.Missing;
                Microsoft.Office.Interop.Excel.Worksheet objSHT = (Worksheet)objWB.Sheets.Add(useDefaultValue, useDefaultValue, useDefaultValue, useDefaultValue);

                //Column
                for (int col = 1; col <= dt_OutPut.Columns.Count; col++)
                {
                    Range range = objSHT.get_Range(GetExcelColumnName(col) + "1", GetExcelColumnName(col) + "1");
                    range.Value2 = dt_OutPut.Columns[col - 1].ColumnName;
                }

                //row
                for (int row = 1; row <= dt_OutPut.Rows.Count; row++)
                {
                    for (int col = 1; col <= dt_OutPut.Columns.Count; col++)
                    {
                        Range range = objSHT.get_Range(GetExcelColumnName(col) + (row + 1).ToString(), GetExcelColumnName(col) + (row + 1).ToString());
                        range.NumberFormat = "@";
                        range.Value2 = dt_OutPut.Rows[row - 1][col - 1].ToString();
                    }
                }

                objWB.Close(true, OFD.FileName, null);
                objXL.Quit();
            }
            catch { }

            TimeSpan timespan1 = DateTime.Now - timeStart;
            MessageBox.Show("檔案匯出至 " + OFD.FileName + " 完畢"
                + Environment.NewLine
                + "花費 " + timespan1.TotalSeconds.ToString() + " 秒"
                , "匯出成功");
        }
        /// <summary>
        /// 取得excel Column Name
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                string cmd_query =
            @"select 關貿日期,Cnt1=COUNT(1)
            FROM (
            select DISTINCT 關貿日期, 廠商編號
            from 廠商盤點_試算盤點結果表) a
            group by 關貿日期";
                object[] obj1 = new object[] { "@date", "NVarChar", dateTimePicker1.Value.ToString("yyyy/MM/dd") };
                dt_DieDate = sca.GetDataTable("LGDC", cmd_query, obj1, 0);
                lbl_DieDate.Text = "";
                foreach (DataRow dr in dt_DieDate.Rows)
                {
                    lbl_DieDate.Text += DateTime.Parse(dr[0].ToString()).ToString("yyyy/MM/dd") + " 廠商共 " + dr[1].ToString() + " 家" + "\n";
                }
            }
        }
    }
}
