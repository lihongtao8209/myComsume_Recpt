namespace issueConsume
{
    partial class ctrl_name_itemNo
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
            this.t_name_itemNo = new System.Windows.Forms.TextBox();
            this.lb_result = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // t_name_itemNo
            // 
            this.t_name_itemNo.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold);
            this.t_name_itemNo.Location = new System.Drawing.Point(0, 0);
            this.t_name_itemNo.Name = "t_name_itemNo";
            this.t_name_itemNo.Size = new System.Drawing.Size(422, 30);
            this.t_name_itemNo.TabIndex = 0;
            this.t_name_itemNo.TextChanged += new System.EventHandler(this.t_name_itemNo_TextChanged);
            this.t_name_itemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_name_itemNo_KeyDown);
            // 
            // lb_result
            // 
            this.lb_result.FormattingEnabled = true;
            this.lb_result.ItemHeight = 12;
            this.lb_result.Location = new System.Drawing.Point(0, 35);
            this.lb_result.Name = "lb_result";
            this.lb_result.Size = new System.Drawing.Size(422, 196);
            this.lb_result.TabIndex = 1;
            this.lb_result.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lb_result_MouseClick);
            // 
            // ctrl_name_itemNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_result);
            this.Controls.Add(this.t_name_itemNo);
            this.Name = "ctrl_name_itemNo";
            this.Size = new System.Drawing.Size(425, 234);
            this.Load += new System.EventHandler(this.ctrl_name_itemNo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_name_itemNo;
        private System.Windows.Forms.ListBox lb_result;
    }
}
