using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using issueConsume;
using recptConsume;
using detailList;

namespace consume
{
    public partial class Form1 : Form
    {
        private recptConsume.recpt recpt1;
        private recpt_list recpt_list1;
        //关闭事件
        private delegate void control_close();
        private event control_close event_control_close;
        //开始事件
        private delegate void control_show();
        private event control_show event_control_show;

        public Form1()
        {
            InitializeComponent();
            initRecptComponent();
            initCameraComponent();
            showRecptComponent();
            issue1.Event_ItemNo += new issue.Del_ItemNo(issue1_Event_ItemNo);
            recpt1.Event_recpt_ItemNo += new recpt.Del_recpt_ItemNo(recpt_Event_ItemNo);
            event_control_close += new control_close(camerDriver1.camerDriver_Closed);
            event_control_show += new control_show(camerDriver1.camerDriver_Open);
        }

        void initRecptComponent()
        {
            //添加耗材录入
            recpt1 = new recptConsume.recpt();
            recpt_list1 = new recpt_list();
            // recpt1
            // 
            this.recpt1.Location = this.issue1.Location;
            this.recpt1.Name = "recpt";
            this.recpt1.Size = this.issue1.Size;
            this.recpt1.TabIndex = 1;
            this.Controls.Add(recpt1);
            // list1
            // 
            this.recpt_list1.Location = this.list1.Location;
            this.recpt_list1.Name = "recpt_list1";
            this.recpt_list1.Size = this.list1.Size;
            this.recpt_list1.TabIndex = 2;
            this.Controls.Add(recpt_list1);
        }

        void initCameraComponent()
        {
            camerDriver1.Setrepository("c:\\");
        }

        void showRecptComponent(bool show=false)
        {
            if (show == false)
            {
                recpt1.Hide();
                recpt_list1.Hide();
            }
            else
            {
                recpt1.Show();
                recpt_list1.Show();
            }
        }


        void showIssueComponent(bool shwo = false)
        {
            if (shwo == false)
            {
                issue1.Hide();
                list1.Hide();
            }
            else
            {
                issue1.Show();
                list1.Show();
            }
        }

        void issue1_Event_ItemNo()
        {//加入list 照相
            camerDriver1.Do(issue1.Item_no);
            list1.Add(issue1.Item_no);
        }

        void recpt_Event_ItemNo()
        {//加入list 照相    
            camerDriver1.Do(recpt1.Item_no,true);
            recpt_list1.Add(recpt1.Item_no);
        }

        private void 耗材录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showIssueComponent(false);
            showRecptComponent(true);
        }

        private void 耗材发放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showRecptComponent(false);
            showIssueComponent(true);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (event_control_close != null)
            {
                event_control_close();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (event_control_show != null)
            {
                event_control_show();
            }
        }
    }
}
