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
            this.记录查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发放查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录入查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issue_name_itemNo1 = new issueConsume.issue_name_itemNo();
            this.camerDriver1 = new cameraDriver.camerDriver();
            this.list1 = new detailList.list();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.耗材管理ToolStripMenuItem,
            this.记录查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1109, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 耗材管理ToolStripMenuItem
            // 
            this.耗材管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.耗材发放ToolStripMenuItem,
            this.耗材录入ToolStripMenuItem});
            this.耗材管理ToolStripMenuItem.Name = "耗材管理ToolStripMenuItem";
            this.耗材管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.耗材管理ToolStripMenuItem.Text = "耗材管理";
            // 
            // 耗材发放ToolStripMenuItem
            // 
            this.耗材发放ToolStripMenuItem.Name = "耗材发放ToolStripMenuItem";
            this.耗材发放ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.耗材发放ToolStripMenuItem.Text = "耗材发放";
            this.耗材发放ToolStripMenuItem.Click += new System.EventHandler(this.耗材发放ToolStripMenuItem_Click);
            // 
            // 耗材录入ToolStripMenuItem
            // 
            this.耗材录入ToolStripMenuItem.Name = "耗材录入ToolStripMenuItem";
            this.耗材录入ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.耗材录入ToolStripMenuItem.Text = "耗材录入";
            this.耗材录入ToolStripMenuItem.Click += new System.EventHandler(this.耗材录入ToolStripMenuItem_Click);
            // 
            // 记录查询ToolStripMenuItem
            // 
            this.记录查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发放查询ToolStripMenuItem,
            this.录入查询ToolStripMenuItem});
            this.记录查询ToolStripMenuItem.Name = "记录查询ToolStripMenuItem";
            this.记录查询ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.记录查询ToolStripMenuItem.Text = "记录查询";
            // 
            // 发放查询ToolStripMenuItem
            // 
            this.发放查询ToolStripMenuItem.Name = "发放查询ToolStripMenuItem";
            this.发放查询ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.发放查询ToolStripMenuItem.Text = "发放查询";
            this.发放查询ToolStripMenuItem.Click += new System.EventHandler(this.发放查询ToolStripMenuItem_Click);
            // 
            // 录入查询ToolStripMenuItem
            // 
            this.录入查询ToolStripMenuItem.Name = "录入查询ToolStripMenuItem";
            this.录入查询ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.录入查询ToolStripMenuItem.Text = "录入查询";
            this.录入查询ToolStripMenuItem.Click += new System.EventHandler(this.录入查询ToolStripMenuItem_Click);
            // 
            // issue_name_itemNo1
            // 
            this.issue_name_itemNo1.Location = new System.Drawing.Point(17, 28);
            this.issue_name_itemNo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.issue_name_itemNo1.Name = "issue_name_itemNo1";
            this.issue_name_itemNo1.Size = new System.Drawing.Size(606, 288);
            this.issue_name_itemNo1.TabIndex = 0;
            // 
            // camerDriver1
            // 
            this.camerDriver1.BackColor = System.Drawing.Color.White;
            this.camerDriver1.ImageDir = null;
            this.camerDriver1.Location = new System.Drawing.Point(676, 38);
            this.camerDriver1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.camerDriver1.Name = "camerDriver1";
            this.camerDriver1.Size = new System.Drawing.Size(379, 271);
            this.camerDriver1.TabIndex = 4;
            // 
            // list1
            // 
            this.list1.AutoScroll = true;
            this.list1.Location = new System.Drawing.Point(0, 321);
            this.list1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(1109, 445);
            this.list1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 762);
            this.Controls.Add(this.issue_name_itemNo1);
            this.Controls.Add(this.camerDriver1);
            this.Controls.Add(this.list1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 耗材管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 耗材发放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 耗材录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 记录查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发放查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 录入查询ToolStripMenuItem;
        private cameraDriver.camerDriver camerDriver1;
        private detailList.list list1;
        private QueryRecords.MainPanel_Query mainPanel_Query1;
        private issueConsume.issue_name_itemNo issue_name_itemNo1;
    }
}

