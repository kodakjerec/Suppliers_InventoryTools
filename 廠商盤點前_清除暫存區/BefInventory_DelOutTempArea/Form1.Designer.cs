namespace BefInventory_DelOutTempArea
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_SiteNo = new System.Windows.Forms.ComboBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Site_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_S_merd_supdidname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_S_slom_slodid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_S_slom_merdid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_N_merd_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Tqty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_N_basd_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_L_slom_jobid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_T_slom_updatedate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_S_cusdidname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_L_slom_sysno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Lbl_UserId = new System.Windows.Forms.Label();
            this.Lbl_WorkNum = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close_panel1 = new System.Windows.Forms.Button();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txb_SupdId = new System.Windows.Forms.TextBox();
            this.Lbl_Version = new System.Windows.Forms.Label();
            this.Chk_WithStock = new System.Windows.Forms.CheckBox();
            this.cmb_VendorNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_BatchID = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_BatchID = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.panel_BatchID.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "倉別";
            // 
            // cmb_SiteNo
            // 
            this.cmb_SiteNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SiteNo.FormattingEnabled = true;
            this.cmb_SiteNo.Location = new System.Drawing.Point(75, 50);
            this.cmb_SiteNo.Margin = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.cmb_SiteNo.Name = "cmb_SiteNo";
            this.cmb_SiteNo.Size = new System.Drawing.Size(126, 32);
            this.cmb_SiteNo.TabIndex = 4;
            this.cmb_SiteNo.SelectedIndexChanged += new System.EventHandler(this.cmb_SiteNo_SelectedIndexChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(994, 549);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Site_No,
            this.col_S_merd_supdidname,
            this.col_S_slom_slodid,
            this.col_S_slom_merdid,
            this.col_N_merd_name,
            this.col_Tqty,
            this.col_N_basd_name,
            this.col_L_slom_jobid,
            this.col_T_slom_updatedate,
            this.col_S_cusdidname,
            this.col_L_slom_sysno});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // col_Site_No
            // 
            this.col_Site_No.Caption = "倉別";
            this.col_Site_No.FieldName = "site_no";
            this.col_Site_No.Name = "col_Site_No";
            this.col_Site_No.OptionsColumn.AllowEdit = false;
            this.col_Site_No.Visible = true;
            this.col_Site_No.VisibleIndex = 0;
            this.col_Site_No.Width = 50;
            // 
            // col_S_merd_supdidname
            // 
            this.col_S_merd_supdidname.Caption = "供應商";
            this.col_S_merd_supdidname.FieldName = "S_merd_supdid";
            this.col_S_merd_supdidname.Name = "col_S_merd_supdidname";
            this.col_S_merd_supdidname.OptionsColumn.AllowEdit = false;
            this.col_S_merd_supdidname.Visible = true;
            this.col_S_merd_supdidname.VisibleIndex = 1;
            this.col_S_merd_supdidname.Width = 80;
            // 
            // col_S_slom_slodid
            // 
            this.col_S_slom_slodid.Caption = "儲位編號";
            this.col_S_slom_slodid.FieldName = "S_slom_slodid";
            this.col_S_slom_slodid.Name = "col_S_slom_slodid";
            this.col_S_slom_slodid.OptionsColumn.AllowEdit = false;
            this.col_S_slom_slodid.Visible = true;
            this.col_S_slom_slodid.VisibleIndex = 2;
            this.col_S_slom_slodid.Width = 92;
            // 
            // col_S_slom_merdid
            // 
            this.col_S_slom_merdid.Caption = "貨號";
            this.col_S_slom_merdid.FieldName = "S_slom_merdid";
            this.col_S_slom_merdid.Name = "col_S_slom_merdid";
            this.col_S_slom_merdid.OptionsColumn.AllowEdit = false;
            this.col_S_slom_merdid.Visible = true;
            this.col_S_slom_merdid.VisibleIndex = 3;
            this.col_S_slom_merdid.Width = 85;
            // 
            // col_N_merd_name
            // 
            this.col_N_merd_name.Caption = "品名規格";
            this.col_N_merd_name.FieldName = "N_merd_name";
            this.col_N_merd_name.Name = "col_N_merd_name";
            this.col_N_merd_name.OptionsColumn.AllowEdit = false;
            this.col_N_merd_name.Visible = true;
            this.col_N_merd_name.VisibleIndex = 4;
            this.col_N_merd_name.Width = 124;
            // 
            // col_Tqty
            // 
            this.col_Tqty.Caption = "庫存量";
            this.col_Tqty.FieldName = "Tqty";
            this.col_Tqty.Name = "col_Tqty";
            this.col_Tqty.OptionsColumn.AllowEdit = false;
            this.col_Tqty.Visible = true;
            this.col_Tqty.VisibleIndex = 5;
            this.col_Tqty.Width = 68;
            // 
            // col_N_basd_name
            // 
            this.col_N_basd_name.Caption = "分區";
            this.col_N_basd_name.FieldName = "N_basd_name";
            this.col_N_basd_name.Name = "col_N_basd_name";
            this.col_N_basd_name.OptionsColumn.AllowEdit = false;
            this.col_N_basd_name.Visible = true;
            this.col_N_basd_name.VisibleIndex = 6;
            this.col_N_basd_name.Width = 122;
            // 
            // col_L_slom_jobid
            // 
            this.col_L_slom_jobid.Caption = "最後更新JobId";
            this.col_L_slom_jobid.FieldName = "L_slom_jobid";
            this.col_L_slom_jobid.Name = "col_L_slom_jobid";
            this.col_L_slom_jobid.OptionsColumn.AllowEdit = false;
            this.col_L_slom_jobid.Visible = true;
            this.col_L_slom_jobid.VisibleIndex = 7;
            this.col_L_slom_jobid.Width = 128;
            // 
            // col_T_slom_updatedate
            // 
            this.col_T_slom_updatedate.Caption = "最後更新日期";
            this.col_T_slom_updatedate.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.col_T_slom_updatedate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_T_slom_updatedate.FieldName = "T_slom_updatedate";
            this.col_T_slom_updatedate.Name = "col_T_slom_updatedate";
            this.col_T_slom_updatedate.OptionsColumn.AllowEdit = false;
            this.col_T_slom_updatedate.Visible = true;
            this.col_T_slom_updatedate.VisibleIndex = 8;
            this.col_T_slom_updatedate.Width = 149;
            // 
            // col_S_cusdidname
            // 
            this.col_S_cusdidname.Caption = "營業所";
            this.col_S_cusdidname.FieldName = "S_cusd_id";
            this.col_S_cusdidname.Name = "col_S_cusdidname";
            this.col_S_cusdidname.OptionsColumn.AllowEdit = false;
            this.col_S_cusdidname.Visible = true;
            this.col_S_cusdidname.VisibleIndex = 9;
            this.col_S_cusdidname.Width = 130;
            // 
            // col_L_slom_sysno
            // 
            this.col_L_slom_sysno.Caption = "絕對序號";
            this.col_L_slom_sysno.FieldName = "L_slom_sysno";
            this.col_L_slom_sysno.Name = "col_L_slom_sysno";
            this.col_L_slom_sysno.Visible = true;
            this.col_L_slom_sysno.VisibleIndex = 10;
            this.col_L_slom_sysno.Width = 83;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = 1;
            this.repositoryItemCheckEdit1.ValueUnchecked = 0;
            // 
            // Lbl_UserId
            // 
            this.Lbl_UserId.AutoSize = true;
            this.Lbl_UserId.Font = new System.Drawing.Font("新細明體", 12F);
            this.Lbl_UserId.Location = new System.Drawing.Point(922, 76);
            this.Lbl_UserId.Name = "Lbl_UserId";
            this.Lbl_UserId.Size = new System.Drawing.Size(50, 16);
            this.Lbl_UserId.TabIndex = 10;
            this.Lbl_UserId.Text = "UserId";
            // 
            // Lbl_WorkNum
            // 
            this.Lbl_WorkNum.AutoSize = true;
            this.Lbl_WorkNum.Font = new System.Drawing.Font("新細明體", 12F);
            this.Lbl_WorkNum.Location = new System.Drawing.Point(922, 53);
            this.Lbl_WorkNum.Name = "Lbl_WorkNum";
            this.Lbl_WorkNum.Size = new System.Drawing.Size(74, 16);
            this.Lbl_WorkNum.TabIndex = 9;
            this.Lbl_WorkNum.Text = "WorkNum";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 136);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 593);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.gridControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 555);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "暫存區";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btn_Close_panel1);
            this.panel1.Controls.Add(this.gridControl2);
            this.panel1.Location = new System.Drawing.Point(674, 291);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 258);
            this.panel1.TabIndex = 7;
            // 
            // btn_Close_panel1
            // 
            this.btn_Close_panel1.BackColor = System.Drawing.Color.Red;
            this.btn_Close_panel1.ForeColor = System.Drawing.Color.White;
            this.btn_Close_panel1.Location = new System.Drawing.Point(3, 215);
            this.btn_Close_panel1.Name = "btn_Close_panel1";
            this.btn_Close_panel1.Size = new System.Drawing.Size(40, 40);
            this.btn_Close_panel1.TabIndex = 8;
            this.btn_Close_panel1.Text = "X";
            this.btn_Close_panel1.UseVisualStyleBackColor = false;
            this.btn_Close_panel1.Click += new System.EventHandler(this.btn_Close_panel1_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(320, 258);
            this.gridControl2.TabIndex = 7;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn8,
            this.gridColumn7});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "倉別";
            this.gridColumn2.FieldName = "site_no";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 50;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "分區";
            this.gridColumn8.FieldName = "N_basd_name";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 122;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "庫存量";
            this.gridColumn7.FieldName = "Tqty";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 68;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridControl3);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1000, 555);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "盤點結果表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(0, 0);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(1000, 555);
            this.gridControl3.TabIndex = 0;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "盤點日";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "供應商";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(287, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(126, 36);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // txb_SupdId
            // 
            this.txb_SupdId.Location = new System.Drawing.Point(512, 47);
            this.txb_SupdId.Name = "txb_SupdId";
            this.txb_SupdId.Size = new System.Drawing.Size(100, 36);
            this.txb_SupdId.TabIndex = 16;
            this.txb_SupdId.TextChanged += new System.EventHandler(this.txb_SupdId_TextChanged);
            this.txb_SupdId.Validated += new System.EventHandler(this.txb_SupdId_Validated);
            // 
            // Lbl_Version
            // 
            this.Lbl_Version.AutoSize = true;
            this.Lbl_Version.Font = new System.Drawing.Font("新細明體", 12F);
            this.Lbl_Version.Location = new System.Drawing.Point(922, 102);
            this.Lbl_Version.Name = "Lbl_Version";
            this.Lbl_Version.Size = new System.Drawing.Size(57, 16);
            this.Lbl_Version.TabIndex = 17;
            this.Lbl_Version.Text = "Version";
            // 
            // Chk_WithStock
            // 
            this.Chk_WithStock.AutoSize = true;
            this.Chk_WithStock.ForeColor = System.Drawing.Color.White;
            this.Chk_WithStock.Location = new System.Drawing.Point(618, 52);
            this.Chk_WithStock.Name = "Chk_WithStock";
            this.Chk_WithStock.Size = new System.Drawing.Size(149, 28);
            this.Chk_WithStock.TabIndex = 18;
            this.Chk_WithStock.Text = "包含庫存區";
            this.Chk_WithStock.UseVisualStyleBackColor = true;
            // 
            // cmb_VendorNo
            // 
            this.cmb_VendorNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_VendorNo.FormattingEnabled = true;
            this.cmb_VendorNo.Location = new System.Drawing.Point(75, 91);
            this.cmb_VendorNo.Margin = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.cmb_VendorNo.Name = "cmb_VendorNo";
            this.cmb_VendorNo.Size = new System.Drawing.Size(338, 32);
            this.cmb_VendorNo.TabIndex = 19;
            this.cmb_VendorNo.SelectedIndexChanged += new System.EventHandler(this.cmb_VendorNo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "快選";
            // 
            // panel_BatchID
            // 
            this.panel_BatchID.Controls.Add(this.label5);
            this.panel_BatchID.Controls.Add(this.cmb_BatchID);
            this.panel_BatchID.Enabled = false;
            this.panel_BatchID.Location = new System.Drawing.Point(416, 88);
            this.panel_BatchID.Name = "panel_BatchID";
            this.panel_BatchID.Size = new System.Drawing.Size(432, 39);
            this.panel_BatchID.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 24);
            this.label5.TabIndex = 24;
            this.label5.Text = "批次";
            // 
            // cmb_BatchID
            // 
            this.cmb_BatchID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BatchID.FormattingEnabled = true;
            this.cmb_BatchID.Items.AddRange(new object[] {
            "欲使用,先輸入供應商代號"});
            this.cmb_BatchID.Location = new System.Drawing.Point(95, 2);
            this.cmb_BatchID.Margin = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.cmb_BatchID.Name = "cmb_BatchID";
            this.cmb_BatchID.Size = new System.Drawing.Size(320, 32);
            this.cmb_BatchID.TabIndex = 23;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "顯示批次";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel_BatchID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_VendorNo);
            this.Controls.Add(this.Chk_WithStock);
            this.Controls.Add(this.Lbl_Version);
            this.Controls.Add(this.txb_SupdId);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Lbl_UserId);
            this.Controls.Add(this.Lbl_WorkNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_SiteNo);
            this.Font = new System.Drawing.Font("新細明體", 18F);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Form1";
            this.Text = "廠商盤點前_清除暫存區";
            this.Controls.SetChildIndex(this.cmb_SiteNo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.Lbl_WorkNum, 0);
            this.Controls.SetChildIndex(this.Lbl_UserId, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.Controls.SetChildIndex(this.txb_SupdId, 0);
            this.Controls.SetChildIndex(this.Lbl_Version, 0);
            this.Controls.SetChildIndex(this.Chk_WithStock, 0);
            this.Controls.SetChildIndex(this.cmb_VendorNo, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.panel_BatchID, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.panel_BatchID.ResumeLayout(false);
            this.panel_BatchID.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_SiteNo;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn col_Site_No;
        private DevExpress.XtraGrid.Columns.GridColumn col_S_merd_supdidname;
        private DevExpress.XtraGrid.Columns.GridColumn col_S_slom_slodid;
        private DevExpress.XtraGrid.Columns.GridColumn col_S_slom_merdid;
        private DevExpress.XtraGrid.Columns.GridColumn col_Tqty;
        private DevExpress.XtraGrid.Columns.GridColumn col_N_basd_name;
        private DevExpress.XtraGrid.Columns.GridColumn col_L_slom_jobid;
        private DevExpress.XtraGrid.Columns.GridColumn col_N_merd_name;
        private DevExpress.XtraGrid.Columns.GridColumn col_T_slom_updatedate;
        private DevExpress.XtraGrid.Columns.GridColumn col_S_cusdidname;
        private System.Windows.Forms.Label Lbl_UserId;
        private System.Windows.Forms.Label Lbl_WorkNum;
        private DevExpress.XtraGrid.Columns.GridColumn col_L_slom_sysno;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txb_SupdId;
        private System.Windows.Forms.Label Lbl_Version;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.Button btn_Close_panel1;
        private System.Windows.Forms.CheckBox Chk_WithStock;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.ComboBox cmb_VendorNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_BatchID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_BatchID;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

