namespace QueryRecords
{
    partial class MainPanel_Query
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
            this.list1 = new Query_records.list();
            this.image1 = new QueryRecords.image();
            this.issue1 = new Query_records.issue();
            this.SuspendLayout();
            // 
            // list1
            // 
            this.list1.Location = new System.Drawing.Point(-3, 287);
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(1109, 445);
            this.list1.TabIndex = 2;
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(669, 10);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(379, 271);
            this.image1.TabIndex = 1;
            // 
            // issue1
            // 
            this.issue1.Location = new System.Drawing.Point(3, 3);
            this.issue1.Name = "issue1";
            this.issue1.Size = new System.Drawing.Size(612, 278);
            this.issue1.TabIndex = 0;
            // 
            // MainPanel_Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.list1);
            this.Controls.Add(this.image1);
            this.Controls.Add(this.issue1);
            this.Name = "MainPanel_Query";
            this.Size = new System.Drawing.Size(1109, 735);
            this.ResumeLayout(false);

        }

        #endregion

        private Query_records.issue issue1;
        private image image1;
        private Query_records.list list1;

    }
}
