
namespace recptConsume
{
    partial class recpt_name_itemNo
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
            this.t_recptItemQty = new System.Windows.Forms.TextBox();
            this.l_recptItemQty = new System.Windows.Forms.Label();
            this.t_stock = new System.Windows.Forms.TextBox();
            this.l_stock = new System.Windows.Forms.Label();
            this.t_spc = new System.Windows.Forms.TextBox();
            this.l_spc = new System.Windows.Forms.Label();
            this.t_itemNo_name = new System.Windows.Forms.TextBox();
            this.l_itemNo_name = new System.Windows.Forms.Label();
            this.l_name_itemNo = new System.Windows.Forms.Label();
            this.ctrl_name_itemNo1 = new issue_recpt_Consume.ctrl_name_itemNo();
            this.SuspendLayout();
            // 
            // t_recptItemQty
            // 
            this.t_recptItemQty.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_recptItemQty.Location = new System.Drawing.Point(353, 237);
            this.t_recptItemQty.Name = "t_recptItemQty";
            this.t_recptItemQty.ReadOnly = true;
            this.t_recptItemQty.Size = new System.Drawing.Size(233, 36);
            this.t_recptItemQty.TabIndex = 19;
            this.t_recptItemQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_recptItemQty_KeyDown);
            // 
            // l_recptItemQty
            // 
            this.l_recptItemQty.AutoSize = true;
            this.l_recptItemQty.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_recptItemQty.Location = new System.Drawing.Point(348, 206);
            this.l_recptItemQty.Name = "l_recptItemQty";
            this.l_recptItemQty.Size = new System.Drawing.Size(116, 25);
            this.l_recptItemQty.TabIndex = 18;
            this.l_recptItemQty.Text = "收货数量";
            // 
            // t_stock
            // 
            this.t_stock.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_stock.Location = new System.Drawing.Point(25, 237);
            this.t_stock.Name = "t_stock";
            this.t_stock.ReadOnly = true;
            this.t_stock.Size = new System.Drawing.Size(233, 36);
            this.t_stock.TabIndex = 17;
            // 
            // l_stock
            // 
            this.l_stock.AutoSize = true;
            this.l_stock.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_stock.Location = new System.Drawing.Point(20, 206);
            this.l_stock.Name = "l_stock";
            this.l_stock.Size = new System.Drawing.Size(116, 25);
            this.l_stock.TabIndex = 16;
            this.l_stock.Text = "实时库存";
            // 
            // t_spc
            // 
            this.t_spc.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_spc.Location = new System.Drawing.Point(25, 166);
            this.t_spc.Name = "t_spc";
            this.t_spc.ReadOnly = true;
            this.t_spc.Size = new System.Drawing.Size(561, 36);
            this.t_spc.TabIndex = 15;
            // 
            // l_spc
            // 
            this.l_spc.AutoSize = true;
            this.l_spc.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_spc.Location = new System.Drawing.Point(20, 138);
            this.l_spc.Name = "l_spc";
            this.l_spc.Size = new System.Drawing.Size(64, 25);
            this.l_spc.TabIndex = 14;
            this.l_spc.Text = "规格";
            // 
            // t_itemNo_name
            // 
            this.t_itemNo_name.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_itemNo_name.Location = new System.Drawing.Point(25, 100);
            this.t_itemNo_name.Name = "t_itemNo_name";
            this.t_itemNo_name.ReadOnly = true;
            this.t_itemNo_name.Size = new System.Drawing.Size(561, 36);
            this.t_itemNo_name.TabIndex = 13;
            // 
            // l_itemNo_name
            // 
            this.l_itemNo_name.AutoSize = true;
            this.l_itemNo_name.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_itemNo_name.Location = new System.Drawing.Point(20, 72);
            this.l_itemNo_name.Name = "l_itemNo_name";
            this.l_itemNo_name.Size = new System.Drawing.Size(64, 25);
            this.l_itemNo_name.TabIndex = 12;
            this.l_itemNo_name.Text = "信息";
            // 
            // l_name_itemNo
            // 
            this.l_name_itemNo.AutoSize = true;
            this.l_name_itemNo.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_name_itemNo.Location = new System.Drawing.Point(20, 6);
            this.l_name_itemNo.Name = "l_name_itemNo";
            this.l_name_itemNo.Size = new System.Drawing.Size(286, 25);
            this.l_name_itemNo.TabIndex = 10;
            this.l_name_itemNo.Text = "耗材名或货号-耗材录入";
            // 
            // ctrl_name_itemNo1
            // 
            this.ctrl_name_itemNo1.consume_items_supplier_result = null;
            this.ctrl_name_itemNo1.inPutType = 0;
            this.ctrl_name_itemNo1.Location = new System.Drawing.Point(20, 31);
            this.ctrl_name_itemNo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_name_itemNo1.Name = "ctrl_name_itemNo1";
            this.ctrl_name_itemNo1.Size = new System.Drawing.Size(567, 36);
            this.ctrl_name_itemNo1.TabIndex = 0;
            // 
            // recpt_name_itemNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrl_name_itemNo1);
            this.Controls.Add(this.t_recptItemQty);
            this.Controls.Add(this.l_recptItemQty);
            this.Controls.Add(this.t_stock);
            this.Controls.Add(this.l_stock);
            this.Controls.Add(this.t_spc);
            this.Controls.Add(this.l_spc);
            this.Controls.Add(this.t_itemNo_name);
            this.Controls.Add(this.l_itemNo_name);
            this.Controls.Add(this.l_name_itemNo);
            this.Name = "recpt_name_itemNo";
            this.Size = new System.Drawing.Size(606, 280);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_recptItemQty;
        private System.Windows.Forms.Label l_recptItemQty;
        private System.Windows.Forms.TextBox t_stock;
        private System.Windows.Forms.Label l_stock;
        private System.Windows.Forms.TextBox t_spc;
        private System.Windows.Forms.Label l_spc;
        private System.Windows.Forms.TextBox t_itemNo_name;
        private System.Windows.Forms.Label l_itemNo_name;
        private System.Windows.Forms.Label l_name_itemNo;
        private issue_recpt_Consume.ctrl_name_itemNo ctrl_name_itemNo1;
    }
}
