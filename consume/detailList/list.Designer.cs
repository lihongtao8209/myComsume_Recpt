namespace detailList
{
    partial class list
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.ch_item_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_item_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_spec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_companyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_supNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_issue_qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_realTimeStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.work_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_item_no,
            this.ch_item_name,
            this.ch_spec,
            this.ch_companyName,
            this.ch_supNo,
            this.ch_issue_qty,
            this.ch_realTimeStock,
            this.work_date});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(832, 356);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ch_item_no
            // 
            this.ch_item_no.Text = "货号";
            this.ch_item_no.Width = 110;
            // 
            // ch_item_name
            // 
            this.ch_item_name.Text = "品名";
            this.ch_item_name.Width = 131;
            // 
            // ch_spec
            // 
            this.ch_spec.Text = "规格";
            this.ch_spec.Width = 89;
            // 
            // ch_companyName
            // 
            this.ch_companyName.Text = "厂商名称";
            this.ch_companyName.Width = 124;
            // 
            // ch_supNo
            // 
            this.ch_supNo.Text = "厂编";
            this.ch_supNo.Width = 115;
            // 
            // ch_issue_qty
            // 
            this.ch_issue_qty.Text = "当前发货量";
            this.ch_issue_qty.Width = 78;
            // 
            // ch_realTimeStock
            // 
            this.ch_realTimeStock.Text = "当前库存";
            // 
            // work_date
            // 
            this.work_date.Text = "更新时间";
            this.work_date.Width = 106;
            // 
            // list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "list";
            this.Size = new System.Drawing.Size(832, 356);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ch_item_name;
        private System.Windows.Forms.ColumnHeader ch_supNo;
        private System.Windows.Forms.ColumnHeader ch_companyName;
        private System.Windows.Forms.ColumnHeader ch_item_no;
        private System.Windows.Forms.ColumnHeader ch_issue_qty;
        private System.Windows.Forms.ColumnHeader ch_realTimeStock;
        private System.Windows.Forms.ColumnHeader work_date;
        private System.Windows.Forms.ColumnHeader ch_spec;
    }
}
