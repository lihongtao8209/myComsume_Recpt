namespace issueConsume
{
    partial class issue_name_itemNo
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
            this.t_issueItemQty = new System.Windows.Forms.TextBox();
            this.l_issueItemQty = new System.Windows.Forms.Label();
            this.t_stock = new System.Windows.Forms.TextBox();
            this.l_stock = new System.Windows.Forms.Label();
            this.t_itemNo_name = new System.Windows.Forms.TextBox();
            this.l_itemNo_name = new System.Windows.Forms.Label();
            this.l_name_itemNo = new System.Windows.Forms.Label();
            this.l_spc = new System.Windows.Forms.Label();
            this.t_spc = new System.Windows.Forms.TextBox();
            this.ctrl_name_itemNo1 = new issueConsume.ctrl_name_itemNo();
            this.SuspendLayout();
            // 
            // t_issueItemQty
            // 
            this.t_issueItemQty.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_issueItemQty.Location = new System.Drawing.Point(261, 190);
            this.t_issueItemQty.Margin = new System.Windows.Forms.Padding(2);
            this.t_issueItemQty.Name = "t_issueItemQty";
            this.t_issueItemQty.ReadOnly = true;
            this.t_issueItemQty.Size = new System.Drawing.Size(176, 30);
            this.t_issueItemQty.TabIndex = 17;
            this.t_issueItemQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_issueItemQty_KeyDown);
            // 
            // l_issueItemQty
            // 
            this.l_issueItemQty.AutoSize = true;
            this.l_issueItemQty.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_issueItemQty.Location = new System.Drawing.Point(257, 166);
            this.l_issueItemQty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_issueItemQty.Name = "l_issueItemQty";
            this.l_issueItemQty.Size = new System.Drawing.Size(93, 20);
            this.l_issueItemQty.TabIndex = 16;
            this.l_issueItemQty.Text = "发放数量";
            // 
            // t_stock
            // 
            this.t_stock.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_stock.Location = new System.Drawing.Point(15, 190);
            this.t_stock.Margin = new System.Windows.Forms.Padding(2);
            this.t_stock.Name = "t_stock";
            this.t_stock.ReadOnly = true;
            this.t_stock.Size = new System.Drawing.Size(176, 30);
            this.t_stock.TabIndex = 15;
            // 
            // l_stock
            // 
            this.l_stock.AutoSize = true;
            this.l_stock.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_stock.Location = new System.Drawing.Point(11, 166);
            this.l_stock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_stock.Name = "l_stock";
            this.l_stock.Size = new System.Drawing.Size(93, 20);
            this.l_stock.TabIndex = 14;
            this.l_stock.Text = "实时库存";
            // 
            // t_itemNo_name
            // 
            this.t_itemNo_name.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_itemNo_name.Location = new System.Drawing.Point(15, 80);
            this.t_itemNo_name.Margin = new System.Windows.Forms.Padding(2);
            this.t_itemNo_name.Name = "t_itemNo_name";
            this.t_itemNo_name.ReadOnly = true;
            this.t_itemNo_name.Size = new System.Drawing.Size(422, 30);
            this.t_itemNo_name.TabIndex = 13;
            // 
            // l_itemNo_name
            // 
            this.l_itemNo_name.AutoSize = true;
            this.l_itemNo_name.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_itemNo_name.Location = new System.Drawing.Point(11, 58);
            this.l_itemNo_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_itemNo_name.Name = "l_itemNo_name";
            this.l_itemNo_name.Size = new System.Drawing.Size(51, 20);
            this.l_itemNo_name.TabIndex = 12;
            this.l_itemNo_name.Text = "信息";
            // 
            // l_name_itemNo
            // 
            this.l_name_itemNo.AutoSize = true;
            this.l_name_itemNo.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_name_itemNo.Location = new System.Drawing.Point(11, 3);
            this.l_name_itemNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_name_itemNo.Name = "l_name_itemNo";
            this.l_name_itemNo.Size = new System.Drawing.Size(135, 20);
            this.l_name_itemNo.TabIndex = 10;
            this.l_name_itemNo.Text = "耗材名或货号";
            // 
            // l_spc
            // 
            this.l_spc.AutoSize = true;
            this.l_spc.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_spc.Location = new System.Drawing.Point(11, 111);
            this.l_spc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_spc.Name = "l_spc";
            this.l_spc.Size = new System.Drawing.Size(51, 20);
            this.l_spc.TabIndex = 18;
            this.l_spc.Text = "规格";
            // 
            // t_spc
            // 
            this.t_spc.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_spc.Location = new System.Drawing.Point(15, 134);
            this.t_spc.Margin = new System.Windows.Forms.Padding(2);
            this.t_spc.Name = "t_spc";
            this.t_spc.ReadOnly = true;
            this.t_spc.Size = new System.Drawing.Size(422, 30);
            this.t_spc.TabIndex = 19;
            // 
            // ctrl_name_itemNo1
            // 
            this.ctrl_name_itemNo1.consume_items_supplier_result = null;
            this.ctrl_name_itemNo1.inPutType = 0;
            this.ctrl_name_itemNo1.Location = new System.Drawing.Point(15, 25);
            this.ctrl_name_itemNo1.Name = "ctrl_name_itemNo1";
            this.ctrl_name_itemNo1.Size = new System.Drawing.Size(425, 30);
            this.ctrl_name_itemNo1.TabIndex = 20;
            // 
            // issue_name_itemNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrl_name_itemNo1);
            this.Controls.Add(this.t_spc);
            this.Controls.Add(this.l_spc);
            this.Controls.Add(this.t_issueItemQty);
            this.Controls.Add(this.l_issueItemQty);
            this.Controls.Add(this.t_stock);
            this.Controls.Add(this.l_stock);
            this.Controls.Add(this.t_itemNo_name);
            this.Controls.Add(this.l_itemNo_name);
            this.Controls.Add(this.l_name_itemNo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "issue_name_itemNo";
            this.Size = new System.Drawing.Size(454, 230);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_issueItemQty;
        private System.Windows.Forms.Label l_issueItemQty;
        private System.Windows.Forms.TextBox t_stock;
        private System.Windows.Forms.Label l_stock;
        private System.Windows.Forms.TextBox t_itemNo_name;
        private System.Windows.Forms.Label l_itemNo_name;
        private System.Windows.Forms.Label l_name_itemNo;
        private System.Windows.Forms.Label l_spc;
        private System.Windows.Forms.TextBox t_spc;
        private ctrl_name_itemNo ctrl_name_itemNo1;
    }
}
