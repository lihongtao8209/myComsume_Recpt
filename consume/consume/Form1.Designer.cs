namespace consume
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.耗材管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.耗材发放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.耗材录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.list1 = new detailList.list();
            this.issue1 = new issueConsume.issue();
            this.camerDriver1 = new cameraDriver.camerDriver();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.耗材管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(832, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 耗材管理ToolStripMenuItem
            // 
            this.耗材管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.耗材发放ToolStripMenuItem,
            this.耗材录入ToolStripMenuItem});
            this.耗材管理ToolStripMenuItem.Name = "耗材管理ToolStripMenuItem";
            this.耗材管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.耗材管理ToolStripMenuItem.Text = "耗材管理";
            // 
            // 耗材发放ToolStripMenuItem
            // 
            this.耗材发放ToolStripMenuItem.Name = "耗材发放ToolStripMenuItem";
            this.耗材发放ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.耗材发放ToolStripMenuItem.Text = "耗材发放";
            this.耗材发放ToolStripMenuItem.Click += new System.EventHandler(this.耗材发放ToolStripMenuItem_Click);
            // 
            // 耗材录入ToolStripMenuItem
            // 
            this.耗材录入ToolStripMenuItem.Name = "耗材录入ToolStripMenuItem";
            this.耗材录入ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.耗材录入ToolStripMenuItem.Text = "耗材录入";
            this.耗材录入ToolStripMenuItem.Click += new System.EventHandler(this.耗材录入ToolStripMenuItem_Click);
            // 
            // list1
            // 
            this.list1.AutoScroll = true;
            this.list1.Location = new System.Drawing.Point(0, 257);
            this.list1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(832, 356);
            this.list1.TabIndex = 2;
            // 
            // issue1
            // 
            this.issue1.Location = new System.Drawing.Point(13, 22);
            this.issue1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.issue1.Name = "issue1";
            this.issue1.Size = new System.Drawing.Size(453, 231);
            this.issue1.TabIndex = 1;
            // 
            // camerDriver1
            // 
            this.camerDriver1.BackColor = System.Drawing.Color.White;
            this.camerDriver1.ImageDir = null;
            this.camerDriver1.Location = new System.Drawing.Point(507, 40);
            this.camerDriver1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.camerDriver1.Name = "camerDriver1";
            this.camerDriver1.Size = new System.Drawing.Size(280, 198);
            this.camerDriver1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 610);
            this.Controls.Add(this.list1);
            this.Controls.Add(this.issue1);
            this.Controls.Add(this.camerDriver1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private cameraDriver.camerDriver camerDriver1;
        private issueConsume.issue issue1;
        private detailList.list list1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 耗材管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 耗材发放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 耗材录入ToolStripMenuItem;
    }
}

