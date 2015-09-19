namespace issueConsume
{
    partial class issue
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
            this.l_barcode = new System.Windows.Forms.Label();
            this.t_barcode = new System.Windows.Forms.TextBox();
            this.l_name = new System.Windows.Forms.Label();
            this.t_name = new System.Windows.Forms.TextBox();
            this.t_shoppeName = new System.Windows.Forms.TextBox();
            this.l_shoppeName = new System.Windows.Forms.Label();
            this.t_stock = new System.Windows.Forms.TextBox();
            this.l_stock = new System.Windows.Forms.Label();
            this.l_issueItemQty = new System.Windows.Forms.Label();
            this.t_issueItemQty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // l_barcode
            // 
            this.l_barcode.AutoSize = true;
            this.l_barcode.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_barcode.Location = new System.Drawing.Point(15, 4);
            this.l_barcode.Name = "l_barcode";
            this.l_barcode.Size = new System.Drawing.Size(312, 25);
            this.l_barcode.TabIndex = 0;
            this.l_barcode.Text = "请扫描耗材条码-耗材发放";
            // 
            // t_barcode
            // 
            this.t_barcode.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_barcode.Location = new System.Drawing.Point(20, 32);
            this.t_barcode.Name = "t_barcode";
            this.t_barcode.Size = new System.Drawing.Size(561, 36);
            this.t_barcode.TabIndex = 1;
            this.t_barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_barcode_KeyDown);
            // 
            // l_name
            // 
            this.l_name.AutoSize = true;
            this.l_name.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_name.Location = new System.Drawing.Point(15, 72);
            this.l_name.Name = "l_name";
            this.l_name.Size = new System.Drawing.Size(90, 25);
            this.l_name.TabIndex = 2;
            this.l_name.Text = "耗材名";
            // 
            // t_name
            // 
            this.t_name.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_name.Location = new System.Drawing.Point(20, 100);
            this.t_name.Name = "t_name";
            this.t_name.ReadOnly = true;
            this.t_name.Size = new System.Drawing.Size(561, 36);
            this.t_name.TabIndex = 3;
            // 
            // t_shoppeName
            // 
            this.t_shoppeName.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_shoppeName.Location = new System.Drawing.Point(20, 167);
            this.t_shoppeName.Name = "t_shoppeName";
            this.t_shoppeName.ReadOnly = true;
            this.t_shoppeName.Size = new System.Drawing.Size(561, 36);
            this.t_shoppeName.TabIndex = 5;
            this.t_shoppeName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_shoppeName_KeyDown);
            // 
            // l_shoppeName
            // 
            this.l_shoppeName.AutoSize = true;
            this.l_shoppeName.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_shoppeName.Location = new System.Drawing.Point(15, 139);
            this.l_shoppeName.Name = "l_shoppeName";
            this.l_shoppeName.Size = new System.Drawing.Size(116, 25);
            this.l_shoppeName.TabIndex = 4;
            this.l_shoppeName.Text = "专柜名称";
            // 
            // t_stock
            // 
            this.t_stock.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_stock.Location = new System.Drawing.Point(20, 238);
            this.t_stock.Name = "t_stock";
            this.t_stock.ReadOnly = true;
            this.t_stock.Size = new System.Drawing.Size(233, 36);
            this.t_stock.TabIndex = 7;
            // 
            // l_stock
            // 
            this.l_stock.AutoSize = true;
            this.l_stock.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_stock.Location = new System.Drawing.Point(15, 207);
            this.l_stock.Name = "l_stock";
            this.l_stock.Size = new System.Drawing.Size(116, 25);
            this.l_stock.TabIndex = 6;
            this.l_stock.Text = "实时库存";
            // 
            // l_issueItemQty
            // 
            this.l_issueItemQty.AutoSize = true;
            this.l_issueItemQty.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_issueItemQty.Location = new System.Drawing.Point(343, 207);
            this.l_issueItemQty.Name = "l_issueItemQty";
            this.l_issueItemQty.Size = new System.Drawing.Size(116, 25);
            this.l_issueItemQty.TabIndex = 8;
            this.l_issueItemQty.Text = "发放数量";
            // 
            // t_issueItemQty
            // 
            this.t_issueItemQty.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_issueItemQty.Location = new System.Drawing.Point(348, 238);
            this.t_issueItemQty.Name = "t_issueItemQty";
            this.t_issueItemQty.ReadOnly = true;
            this.t_issueItemQty.Size = new System.Drawing.Size(233, 36);
            this.t_issueItemQty.TabIndex = 9;
            this.t_issueItemQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_issueItemQty_KeyDown);
            // 
            // issue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.t_issueItemQty);
            this.Controls.Add(this.l_issueItemQty);
            this.Controls.Add(this.t_stock);
            this.Controls.Add(this.l_stock);
            this.Controls.Add(this.t_shoppeName);
            this.Controls.Add(this.l_shoppeName);
            this.Controls.Add(this.t_name);
            this.Controls.Add(this.l_name);
            this.Controls.Add(this.t_barcode);
            this.Controls.Add(this.l_barcode);
            this.Name = "issue";
            this.Size = new System.Drawing.Size(606, 288);
            this.Load += new System.EventHandler(this.issue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_barcode;
        private System.Windows.Forms.TextBox t_barcode;
        private System.Windows.Forms.Label l_name;
        private System.Windows.Forms.TextBox t_name;
        private System.Windows.Forms.TextBox t_shoppeName;
        private System.Windows.Forms.Label l_shoppeName;
        private System.Windows.Forms.TextBox t_stock;
        private System.Windows.Forms.Label l_stock;
        private System.Windows.Forms.Label l_issueItemQty;
        private System.Windows.Forms.TextBox t_issueItemQty;
    }
}
