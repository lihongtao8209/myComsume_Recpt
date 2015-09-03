namespace Test
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
        	this.camerDriver1 = new cameraDriver.camerDriver();
        	this.SuspendLayout();
        	// 
        	// camerDriver1
        	// 
        	this.camerDriver1.BackColor = System.Drawing.Color.White;
        	this.camerDriver1.ImageDir = null;
        	this.camerDriver1.Location = new System.Drawing.Point(278, 11);
        	this.camerDriver1.Margin = new System.Windows.Forms.Padding(2);
        	this.camerDriver1.Name = "camerDriver1";
        	this.camerDriver1.Size = new System.Drawing.Size(198, 153);
        	this.camerDriver1.TabIndex = 0;
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(487, 316);
        	this.Controls.Add(this.camerDriver1);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "Form1";
        	this.Text = "Form1";
        	this.ResumeLayout(false);
        }

        #endregion

        private cameraDriver.camerDriver camerDriver1;
    }
}

