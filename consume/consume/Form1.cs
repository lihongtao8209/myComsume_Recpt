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
using QueryRecords;
using ConnectMySql;

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
            initMainPanelQueryComponent();
            showRecptComponent();
            issue_name_itemNo1.Event_ItemNo += new issue_name_itemNo.Del_ItemNo(issue1_Event_ItemNo);
            recpt1.Event_recpt_ItemNo += new recpt.Del_recpt_ItemNo(recpt_Event_ItemNo);
            event_control_close += new control_close(camerDriver1.camerDriver_Closed);
            event_control_show += new control_show(camerDriver1.camerDriver_Open);
            MySqlSimpleOper.SetServerIp("127.0.0.1");
            //
            preMySql();
        }

        void initRecptComponent()
        {
            //添加耗材录入
            recpt1 = new recptConsume.recpt();
            recpt_list1 = new recpt_list();
            // recpt1
            // 
            this.recpt1.Location = this.issue_name_itemNo1.Location;
            this.recpt1.Name = "recpt";
            this.recpt1.Size = this.issue_name_itemNo1.Size;
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

        void initMainPanelQueryComponent()
        {
            this.mainPanel_Query1 = new QueryRecords.MainPanel_Query();
            this.mainPanel_Query1.Location = new System.Drawing.Point(0, 28);
            this.mainPanel_Query1.Name = "mainPanel_Query1";
            this.mainPanel_Query1.Size = new System.Drawing.Size(1109, 735);
            this.mainPanel_Query1.TabIndex = 5;
            this.Controls.Add(this.mainPanel_Query1);
            mainPanel_Query1.Hide();
        }

        void initCameraComponent()
        {
            camerDriver1.Setrepository("c:\\");
        }

        void showRecptComponent(bool show = false)
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

        void showMainPanelQueryComponent(bool isRecptShow = false, bool show = false)
        {
            if (show == true)
            {
                if (isRecptShow == false)
                {
                    mainPanel_Query1.showIssueComponent(true);
                }
                else
                {
                    mainPanel_Query1.showRecptComponent(true);
                }
                mainPanel_Query1.Show();
            }
            else
            {
                mainPanel_Query1.Hide();
            }

        }

        void showIssueComponent(bool show = false)
        {
            if (show == false)
            {
                issue_name_itemNo1.Hide();
                list1.Hide();
            }
            else
            {
                issue_name_itemNo1.Show();
                list1.Show();
            }
        }

        void showcamerDriver(bool show = false)
        {
            if (show == false)
            {
                if (camerDriver1.Visible == true)
                    camerDriver1.Hide();
            }
            else
            {
                if (camerDriver1.Visible == false)
                    camerDriver1.Show();
            }
        }

        void issue1_Event_ItemNo()
        {//加入list 照相
            camerDriver1.Do(issue_name_itemNo1.Item_no);
            list1.Add(issue_name_itemNo1.Item_no);
        }

        void recpt_Event_ItemNo()
        {//加入list 照相    
            camerDriver1.Do(recpt1.Item_no, true);
            recpt_list1.Add(recpt1.Item_no);
        }

        private void 耗材录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showcamerDriver(true);
            showIssueComponent(false);
            showRecptComponent(true);
            showMainPanelQueryComponent();
        }

        private void 耗材发放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showcamerDriver(true);
            showRecptComponent(false);
            showIssueComponent(true);
            showMainPanelQueryComponent();
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

        private void 发放查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {// 发放记录 图像查询
            showcamerDriver();
            showIssueComponent();
            showRecptComponent();
            showMainPanelQueryComponent(false, true);
        }

        private void 录入查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showcamerDriver();
            showIssueComponent();
            showRecptComponent();
            showMainPanelQueryComponent(true, true);
        }

        private void preMySql()
        {
            SQL_FLOW.IssueHelper issueHelper= new SQL_FLOW.IssueHelper();
            List<string[]> result=new List<string[]>();
            issueHelper.Query0(ref result);
            issue_name_itemNo1.SetResult(ref result);
        }
    }
}
