namespace Query_records
{
    partial class recpt_list
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
            this.ch_bar_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_item_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_recptQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_rt_stock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_work_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_imageName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_item_name,
            this.ch_bar_code,
            this.ch_item_no,
            this.ch_recptQty,
            this.ch_rt_stock,
            this.ch_work_date,
            this.ch_imageName});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1109, 445);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // ch_item_name
            // 
            this.ch_item_name.Text = "商品名称";
            this.ch_item_name.Width = 173;
            // 
            // ch_bar_code
            // 
            this.ch_bar_code.Text = "条码";
            this.ch_bar_code.Width = 140;
            // 
            // ch_item_no
            // 
            this.ch_item_no.Text = "货号";
            this.ch_item_no.Width = 90;
            // 
            // ch_recptQty
            // 
            this.ch_recptQty.Text = "收货量";
            this.ch_recptQty.Width = 64;
            // 
            // ch_rt_stock
            // 
            this.ch_rt_stock.Text = "库存";
            this.ch_rt_stock.Width = 67;
            // 
            // ch_work_date
            // 
            this.ch_work_date.Text = "更新时间";
            this.ch_work_date.Width = 185;
            // 
            // ch_imageName
            // 
            this.ch_imageName.Text = "图像名称";
            this.ch_imageName.Width = 283;
            // 
            // recpt_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Name = "recpt_list";
            this.Size = new System.Drawing.Size(1109, 445);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ch_item_name;
        private System.Windows.Forms.ColumnHeader ch_bar_code;
        private System.Windows.Forms.ColumnHeader ch_item_no;
        private System.Windows.Forms.ColumnHeader ch_recptQty;
        private System.Windows.Forms.ColumnHeader ch_rt_stock;
        private System.Windows.Forms.ColumnHeader ch_work_date;
        private System.Windows.Forms.ColumnHeader ch_imageName;
    }
}
