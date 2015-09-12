namespace QueryRecords
{
    partial class Daytime_query
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
            this.l_sec = new System.Windows.Forms.Label();
            this.l_min = new System.Windows.Forms.Label();
            this.l_hour = new System.Windows.Forms.Label();
            this.cbb_sec = new System.Windows.Forms.ComboBox();
            this.cbb_min = new System.Windows.Forms.ComboBox();
            this.cbb_hour = new System.Windows.Forms.ComboBox();
            this.l_day = new System.Windows.Forms.Label();
            this.l_month = new System.Windows.Forms.Label();
            this.l_year = new System.Windows.Forms.Label();
            this.cbb_day = new System.Windows.Forms.ComboBox();
            this.cbb_month = new System.Windows.Forms.ComboBox();
            this.cbb_year = new System.Windows.Forms.ComboBox();
            this.l_showDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // l_sec
            // 
            this.l_sec.AutoSize = true;
            this.l_sec.Location = new System.Drawing.Point(444, 35);
            this.l_sec.Name = "l_sec";
            this.l_sec.Size = new System.Drawing.Size(22, 15);
            this.l_sec.TabIndex = 23;
            this.l_sec.Text = "秒";
            // 
            // l_min
            // 
            this.l_min.AutoSize = true;
            this.l_min.Location = new System.Drawing.Point(289, 36);
            this.l_min.Name = "l_min";
            this.l_min.Size = new System.Drawing.Size(22, 15);
            this.l_min.TabIndex = 22;
            this.l_min.Text = "分";
            // 
            // l_hour
            // 
            this.l_hour.AutoSize = true;
            this.l_hour.Location = new System.Drawing.Point(134, 35);
            this.l_hour.Name = "l_hour";
            this.l_hour.Size = new System.Drawing.Size(22, 15);
            this.l_hour.TabIndex = 21;
            this.l_hour.Text = "时";
            // 
            // cbb_sec
            // 
            this.cbb_sec.FormattingEnabled = true;
            this.cbb_sec.Location = new System.Drawing.Point(317, 32);
            this.cbb_sec.Name = "cbb_sec";
            this.cbb_sec.Size = new System.Drawing.Size(121, 23);
            this.cbb_sec.TabIndex = 20;
            // 
            // cbb_min
            // 
            this.cbb_min.FormattingEnabled = true;
            this.cbb_min.Location = new System.Drawing.Point(162, 32);
            this.cbb_min.Name = "cbb_min";
            this.cbb_min.Size = new System.Drawing.Size(121, 23);
            this.cbb_min.TabIndex = 19;
            // 
            // cbb_hour
            // 
            this.cbb_hour.FormattingEnabled = true;
            this.cbb_hour.Location = new System.Drawing.Point(7, 30);
            this.cbb_hour.Name = "cbb_hour";
            this.cbb_hour.Size = new System.Drawing.Size(121, 23);
            this.cbb_hour.TabIndex = 18;
            // 
            // l_day
            // 
            this.l_day.AutoSize = true;
            this.l_day.Location = new System.Drawing.Point(444, 6);
            this.l_day.Name = "l_day";
            this.l_day.Size = new System.Drawing.Size(22, 15);
            this.l_day.TabIndex = 17;
            this.l_day.Text = "日";
            // 
            // l_month
            // 
            this.l_month.AutoSize = true;
            this.l_month.Location = new System.Drawing.Point(289, 7);
            this.l_month.Name = "l_month";
            this.l_month.Size = new System.Drawing.Size(22, 15);
            this.l_month.TabIndex = 16;
            this.l_month.Text = "月";
            // 
            // l_year
            // 
            this.l_year.AutoSize = true;
            this.l_year.Location = new System.Drawing.Point(134, 6);
            this.l_year.Name = "l_year";
            this.l_year.Size = new System.Drawing.Size(22, 15);
            this.l_year.TabIndex = 15;
            this.l_year.Text = "年";
            // 
            // cbb_day
            // 
            this.cbb_day.FormattingEnabled = true;
            this.cbb_day.Location = new System.Drawing.Point(317, 3);
            this.cbb_day.Name = "cbb_day";
            this.cbb_day.Size = new System.Drawing.Size(121, 23);
            this.cbb_day.TabIndex = 14;
            // 
            // cbb_month
            // 
            this.cbb_month.FormattingEnabled = true;
            this.cbb_month.Location = new System.Drawing.Point(162, 3);
            this.cbb_month.Name = "cbb_month";
            this.cbb_month.Size = new System.Drawing.Size(121, 23);
            this.cbb_month.TabIndex = 13;
            this.cbb_month.SelectedIndexChanged += new System.EventHandler(this.cbb_month_SelectedIndexChanged);
            // 
            // cbb_year
            // 
            this.cbb_year.FormattingEnabled = true;
            this.cbb_year.Location = new System.Drawing.Point(7, 1);
            this.cbb_year.Name = "cbb_year";
            this.cbb_year.Size = new System.Drawing.Size(121, 23);
            this.cbb_year.TabIndex = 12;
            // 
            // l_showDate
            // 
            this.l_showDate.AutoSize = true;
            this.l_showDate.Location = new System.Drawing.Point(4, 56);
            this.l_showDate.Name = "l_showDate";
            this.l_showDate.Size = new System.Drawing.Size(159, 15);
            this.l_showDate.TabIndex = 24;
            this.l_showDate.Text = "0000-00-00 00:00:00";
            // 
            // Daytime_query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.l_showDate);
            this.Controls.Add(this.l_sec);
            this.Controls.Add(this.l_min);
            this.Controls.Add(this.l_hour);
            this.Controls.Add(this.cbb_sec);
            this.Controls.Add(this.cbb_min);
            this.Controls.Add(this.cbb_hour);
            this.Controls.Add(this.l_day);
            this.Controls.Add(this.l_month);
            this.Controls.Add(this.l_year);
            this.Controls.Add(this.cbb_day);
            this.Controls.Add(this.cbb_month);
            this.Controls.Add(this.cbb_year);
            this.Name = "Daytime_query";
            this.Size = new System.Drawing.Size(466, 75);
            this.Load += new System.EventHandler(this.Daytime_query_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_sec;
        private System.Windows.Forms.Label l_min;
        private System.Windows.Forms.Label l_hour;
        private System.Windows.Forms.ComboBox cbb_sec;
        private System.Windows.Forms.ComboBox cbb_min;
        private System.Windows.Forms.ComboBox cbb_hour;
        private System.Windows.Forms.Label l_day;
        private System.Windows.Forms.Label l_month;
        private System.Windows.Forms.Label l_year;
        private System.Windows.Forms.ComboBox cbb_day;
        private System.Windows.Forms.ComboBox cbb_month;
        private System.Windows.Forms.ComboBox cbb_year;
        private System.Windows.Forms.Label l_showDate;
    }
}
