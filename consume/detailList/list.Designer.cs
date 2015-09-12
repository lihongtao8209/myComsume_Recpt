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
            this.ch_item_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_shoppe_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_barcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_item_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_issue_qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_realTimeStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.work_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_item_name,
            this.ch_shoppe_name,
            this.ch_barcode,
            this.ch_item_no,
            this.ch_issue_qty,
            this.ch_realTimeStock,
            this.work_date});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1109, 445);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ch_item_name
            // 
            this.ch_item_name.Text = "品名";
            this.ch_item_name.Width = 164;
            // 
            // ch_shoppe_name
            // 
            this.ch_shoppe_name.DisplayIndex = 2;
            this.ch_shoppe_name.Text = "专柜商品名";
            this.ch_shoppe_name.Width = 135;
            // 
            // ch_barcode
            // 
            this.ch_barcode.DisplayIndex = 1;
            this.ch_barcode.Text = "条码";
            this.ch_barcode.Width = 148;
            // 
            // ch_item_no
            // 
            this.ch_item_no.Text = "货号";
            this.ch_item_no.Width = 118;
            // 
            // ch_issue_qty
            // 
            this.ch_issue_qty.Text = "当前发货量";
            this.ch_issue_qty.Width = 93;
            // 
            // ch_realTimeStock
            // 
            this.ch_realTimeStock.Text = "当前库存";
            this.ch_realTimeStock.Width = 90;
            // 
            // work_date
            // 
            this.work_date.Text = "更新时间";
            this.work_date.Width = 90;
            // 
            // list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Name = "list";
            this.Size = new System.Drawing.Size(1109, 445);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ch_item_name;
        private System.Windows.Forms.ColumnHeader ch_shoppe_name;
        private System.Windows.Forms.ColumnHeader ch_barcode;
        private System.Windows.Forms.ColumnHeader ch_item_no;
        private System.Windows.Forms.ColumnHeader ch_issue_qty;
        private System.Windows.Forms.ColumnHeader ch_realTimeStock;
        private System.Windows.Forms.ColumnHeader work_date;
    }
}
