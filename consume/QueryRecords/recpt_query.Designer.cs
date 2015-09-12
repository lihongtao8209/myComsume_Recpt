namespace Query_records
{
    partial class recpt
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.t_item_no = new System.Windows.Forms.TextBox();
            this.l_itemNo = new System.Windows.Forms.Label();
            this.t_name = new System.Windows.Forms.TextBox();
            this.l_name = new System.Windows.Forms.Label();
            this.t_barcode = new System.Windows.Forms.TextBox();
            this.l_barcode = new System.Windows.Forms.Label();
            this.tbc_Filter = new System.Windows.Forms.TabControl();
            this.tabPage_dateTime = new System.Windows.Forms.TabPage();
            this.daytime_query1 = new QueryRecords.Daytime_query();
            this.tabPage_others = new System.Windows.Forms.TabPage();
            this.chk_Filter = new System.Windows.Forms.CheckBox();
            this.btn_doQuery = new System.Windows.Forms.Button();
            this.tbc_Filter.SuspendLayout();
            this.tabPage_dateTime.SuspendLayout();
            this.tabPage_others.SuspendLayout();
            this.SuspendLayout();
            // 
            // t_item_no
            // 
            this.t_item_no.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.t_item_no.Location = new System.Drawing.Point(18, 156);
            this.t_item_no.Name = "t_item_no";
            this.t_item_no.Size = new System.Drawing.Size(561, 30);
            this.t_item_no.TabIndex = 15;
            // 
            // l_itemNo
            // 
            this.l_itemNo.AutoSize = true;
            this.l_itemNo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.l_itemNo.Location = new System.Drawing.Point(13, 128);
            this.l_itemNo.Name = "l_itemNo";
            this.l_itemNo.Size = new System.Drawing.Size(51, 20);
            this.l_itemNo.TabIndex = 14;
            this.l_itemNo.Text = "货号";
            // 
            // t_name
            // 
            this.t_name.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.t_name.Location = new System.Drawing.Point(18, 89);
            this.t_name.Name = "t_name";
            this.t_name.Size = new System.Drawing.Size(561, 30);
            this.t_name.TabIndex = 13;
            // 
            // l_name
            // 
            this.l_name.AutoSize = true;
            this.l_name.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.l_name.Location = new System.Drawing.Point(13, 64);
            this.l_name.Name = "l_name";
            this.l_name.Size = new System.Drawing.Size(72, 20);
            this.l_name.TabIndex = 12;
            this.l_name.Text = "耗材名";
            // 
            // t_barcode
            // 
            this.t_barcode.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.t_barcode.Location = new System.Drawing.Point(18, 28);
            this.t_barcode.Name = "t_barcode";
            this.t_barcode.Size = new System.Drawing.Size(561, 30);
            this.t_barcode.TabIndex = 11;
            // 
            // l_barcode
            // 
            this.l_barcode.AutoSize = true;
            this.l_barcode.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.l_barcode.Location = new System.Drawing.Point(13, 5);
            this.l_barcode.Name = "l_barcode";
            this.l_barcode.Size = new System.Drawing.Size(293, 20);
            this.l_barcode.TabIndex = 10;
            this.l_barcode.Text = "请扫描耗材条码-耗材录入查询";
            // 
            // tbc_Filter
            // 
            this.tbc_Filter.Controls.Add(this.tabPage_dateTime);
            this.tbc_Filter.Controls.Add(this.tabPage_others);
            this.tbc_Filter.Location = new System.Drawing.Point(3, 3);
            this.tbc_Filter.Name = "tbc_Filter";
            this.tbc_Filter.SelectedIndex = 0;
            this.tbc_Filter.Size = new System.Drawing.Size(600, 219);
            this.tbc_Filter.TabIndex = 19;
            // 
            // tabPage_dateTime
            // 
            this.tabPage_dateTime.Controls.Add(this.daytime_query1);
            this.tabPage_dateTime.Location = new System.Drawing.Point(4, 25);
            this.tabPage_dateTime.Name = "tabPage_dateTime";
            this.tabPage_dateTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_dateTime.Size = new System.Drawing.Size(592, 190);
            this.tabPage_dateTime.TabIndex = 0;
            this.tabPage_dateTime.Text = "时间";
            this.tabPage_dateTime.UseVisualStyleBackColor = true;
            // 
            // daytime_query1
            // 
            this.daytime_query1.Location = new System.Drawing.Point(6, 6);
            this.daytime_query1.Name = "daytime_query1";
            this.daytime_query1.Size = new System.Drawing.Size(466, 75);
            this.daytime_query1.TabIndex = 0;
            // 
            // tabPage_others
            // 
            this.tabPage_others.Controls.Add(this.l_barcode);
            this.tabPage_others.Controls.Add(this.t_barcode);
            this.tabPage_others.Controls.Add(this.l_name);
            this.tabPage_others.Controls.Add(this.t_name);
            this.tabPage_others.Controls.Add(this.t_item_no);
            this.tabPage_others.Controls.Add(this.l_itemNo);
            this.tabPage_others.Location = new System.Drawing.Point(4, 25);
            this.tabPage_others.Name = "tabPage_others";
            this.tabPage_others.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_others.Size = new System.Drawing.Size(592, 190);
            this.tabPage_others.TabIndex = 1;
            this.tabPage_others.Text = "其它";
            this.tabPage_others.UseVisualStyleBackColor = true;
            // 
            // chk_Filter
            // 
            this.chk_Filter.AutoSize = true;
            this.chk_Filter.Location = new System.Drawing.Point(7, 239);
            this.chk_Filter.Name = "chk_Filter";
            this.chk_Filter.Size = new System.Drawing.Size(89, 19);
            this.chk_Filter.TabIndex = 18;
            this.chk_Filter.Text = "启用条件";
            this.chk_Filter.UseVisualStyleBackColor = true;
            this.chk_Filter.CheckedChanged += new System.EventHandler(this.chk_Filter_CheckedChanged);
            // 
            // btn_doQuery
            // 
            this.btn_doQuery.Font = new System.Drawing.Font("SimSun", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_doQuery.Location = new System.Drawing.Point(528, 228);
            this.btn_doQuery.Name = "btn_doQuery";
            this.btn_doQuery.Size = new System.Drawing.Size(75, 38);
            this.btn_doQuery.TabIndex = 20;
            this.btn_doQuery.Text = "查询";
            this.btn_doQuery.UseVisualStyleBackColor = true;
            this.btn_doQuery.Click += new System.EventHandler(this.btn_doQuery_Click);
            // 
            // recpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_doQuery);
            this.Controls.Add(this.tbc_Filter);
            this.Controls.Add(this.chk_Filter);
            this.Name = "recpt";
            this.Size = new System.Drawing.Size(606, 288);
            this.tbc_Filter.ResumeLayout(false);
            this.tabPage_dateTime.ResumeLayout(false);
            this.tabPage_others.ResumeLayout(false);
            this.tabPage_others.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_item_no;
        private System.Windows.Forms.Label l_itemNo;
        private System.Windows.Forms.TextBox t_name;
        private System.Windows.Forms.Label l_name;
        private System.Windows.Forms.TextBox t_barcode;
        private System.Windows.Forms.Label l_barcode;
        private System.Windows.Forms.TabControl tbc_Filter;
        private System.Windows.Forms.TabPage tabPage_dateTime;
        private QueryRecords.Daytime_query daytime_query1;
        private System.Windows.Forms.TabPage tabPage_others;
        private System.Windows.Forms.CheckBox chk_Filter;
        private System.Windows.Forms.Button btn_doQuery;
    }
}
