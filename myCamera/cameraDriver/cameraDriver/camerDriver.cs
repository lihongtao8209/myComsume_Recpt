using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyVideoService;

namespace cameraDriver
{
    public partial class camerDriver : UserControl
    {
        CameraHelper cameraHelper = new CameraHelper();
        cVideo video = null;
        public camerDriver()
        {
            InitializeComponent();
        }

        private void camerDriver_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void camerDriver_Leave(object sender, EventArgs e)
        {//退出
            /*
            try
            {
                video.CloseWebcam();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
             * */
        }

        public void camerDriver_Closed()
        {
            //退出
            try
            {
                video.CloseWebcam();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        public void camerDriver_Open()
        {
            //加载
            try
            {
                video = new cVideo(this.pictureBox1.Handle, this.pictureBox1.Width, this.pictureBox1.Height);
                video.StartWebCam();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        public string ImageDir
        {
            get;
            set;
        }
        public void SaveImage(string ImageDir,string imageName)
        {//拍照并保存
            if (ImageDir == "" || ImageDir==null)
            {
                MessageBox.Show("请输入" + imageName + "的文件路径!");
            }
            else
            {
                string imagePath = ImageDir + "\\" + imageName;
                video.GrabImage(this.pictureBox1.Handle, imagePath);
            }
        }

        private void camerDriver_Enter(object sender, EventArgs e)
        {
            //加载
            /*
            try
            {
                video = new cVideo(this.pictureBox1.Handle, this.pictureBox1.Width, this.pictureBox1.Height);
                video.StartWebCam();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
            */
        }

 
        public void Do(string item_no, bool isRecpt = false)
        {
            if(isRecpt==false)
            {
                cameraHelper.Do(item_no);
            }
            else
            {
                cameraHelper.Do_Recpt(item_no);
            }
            SaveImage("c:",cameraHelper.FileName);
        }





 
    }
}
