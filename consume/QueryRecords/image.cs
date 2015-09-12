using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QueryRecords
{
    public partial class image : UserControl
    {
        public image()
        {
            InitializeComponent();
        }
        public void ShowImage(string imageFilepath)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(imageFilepath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("打开文件失败:" + imageFilepath + "\n" + ex.Message + "\n" + ex.StackTrace);
            }
           
        }
    }
}
