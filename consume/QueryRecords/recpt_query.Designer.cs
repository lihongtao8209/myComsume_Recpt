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
            this.tbc_Filter = new System.Windows.Forms.TabControl();
            this.tabPage_dateTime = new System.Windows.Forms.TabPage();
            this.daytime_query1 = new QueryRecords.Daytime_query();
            this.tabPage_others = new System.Windows.Forms.TabPage();
            this.chk_Filter = new System.Windows.Forms.CheckBox();
            this.btn_doQuery = new System.Windows.Forms.Button();
            this.ctrl_name_itemNo1 = new issue_recpt_Consume.ctrl_name_itemNo();
            this.l_name_itemNo = new System.Windows.Forms.Label();



            this.tbc_Filter.SuspendLayout();
            this.tabPage_dateTime.SuspendLayout();
            this.tabPage_others.SuspendLayout();
            this.SuspendLayout();
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
            this.tabPage_dateTime.TabIndex = 1;
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
            this.tabPage_others.Controls.Add(this.ctrl_name_itemNo1);
            this.tabPage_others.Controls.Add(this.l_name_itemNo);
            this.tabPage_others.Location = new System.Drawing.Point(4, 25);
            this.tabPage_others.Name = "tabPage_others";
            this.tabPage_others.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_others.Size = new System.Drawing.Size(592, 190);
            this.tabPage_others.TabIndex = 1;
            this.tabPage_others.Text = "耗材名或货号";
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
            this.btn_doQuery.Location = new System.Drawing.Point(504, 228);
            this.btn_doQuery.Name = "btn_doQuery";
            this.btn_doQuery.Size = new System.Drawing.Size(99, 38);
            this.btn_doQuery.TabIndex = 20;
            this.btn_doQuery.Text = "收货查询";
            this.btn_doQuery.UseVisualStyleBackColor = true;
            this.btn_doQuery.Click += new System.EventHandler(this.btn_doQuery_Click);
            // 
            // ctrl_name_itemNo1
            // 
            this.ctrl_name_itemNo1.consume_items_supplier_result = null;
            this.ctrl_name_itemNo1.inPutType = 0;
            this.ctrl_name_itemNo1.Location = new System.Drawing.Point(18, 28);
            this.ctrl_name_itemNo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_name_itemNo1.Name = "ctrl_name_itemNo1";
            this.ctrl_name_itemNo1.Size = new System.Drawing.Size(567, 36);
            this.ctrl_name_itemNo1.TabIndex = 20;
            // 
            // l_name_itemNo
            // 
            this.l_name_itemNo.AutoSize = true;
            this.l_name_itemNo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_name_itemNo.Location = new System.Drawing.Point(13, 5);
            this.l_name_itemNo.Name = "l_name_itemNo";
            this.l_name_itemNo.Size = new System.Drawing.Size(135, 20);
            this.l_name_itemNo.TabIndex = 19;
            this.l_name_itemNo.Text = "耗材名或货号";
            // 
            // recpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbc_Filter);
            this.Controls.Add(this.btn_doQuery);
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

        private System.Windows.Forms.TabControl tbc_Filter;
        private System.Windows.Forms.TabPage tabPage_dateTime;
        private QueryRecords.Daytime_query daytime_query1;
        private System.Windows.Forms.TabPage tabPage_others;
        private System.Windows.Forms.CheckBox chk_Filter;
        private System.Windows.Forms.Button btn_doQuery;
        private issue_recpt_Consume.ctrl_name_itemNo ctrl_name_itemNo1;
        private System.Windows.Forms.Label l_name_itemNo;
    }
}
