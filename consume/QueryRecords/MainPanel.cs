using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Query_records;

namespace QueryRecords
{
    public partial class MainPanel_Query : UserControl
    {
        recpt recpt1 = null;
        recpt_list recpt_list1 = null;
        public MainPanel_Query()
        {

            InitializeComponent();
            initRecptComponent();
            showRecptComponent();
            showImageComponent(true);
            issue1.Event_Query_Issue_Records += new issue.Del_Query_Issue_Records(Query_Issue_Records);
            issue1.Event_Query_Issue_Records_Filter += new issue.Del_Query_Issue_Records_Filter(Query_Issue_Records_Filter);
            list1.Event_ShowImage_Issue_Records += new list.Del_ShowImage_Issue_Records(ShowImage);
            recpt1.Event_Query_Recpt_Records += new recpt.Del_Query_Recpt_Records(Query_Recpt_Records);
            recpt1.Event_Query_Recpt_Records_Filter += new recpt.Del_Query_Recpt_Records_Filter(Query_Recpt_Records_Filter);
        }

        void Query_Issue_Records()
        {
            list1.AddToList();
        }

        void Query_Issue_Records_Filter(List<string> arg)
        {
            list1.AddToList_Filter(ref arg);
        }

        void Query_Recpt_Records_Filter(List<string> arg)
        {
            recpt_list1.AddToList_Filter(ref arg);
        }

        void Query_Recpt_Records()
        {
            recpt_list1.AddToList();
        }

        void ShowImage(string imageFilepath)
        {
            image1.ShowImage(imageFilepath);
        }

        void initRecptComponent()
        {
            //添加耗材录入
            recpt1 = new recpt();
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

        public void showRecptComponent(bool show = false)
        {
           // if (show == true && issue1.Visible == true && list1.Visible == true)
            {
                showComponent(issue1, false);
                showComponent(list1, false);
                showComponent(recpt1, show);
                showComponent(recpt_list1, show);
                showImageComponent(show);
            }
            /*
            else
            {
                showComponent(issue1, false);
                showComponent(list1, false);
                showComponent(recpt1, show);
                showComponent(recpt_list1, show);
                showImageComponent(show);

            }*/
        }

        public void showIssueComponent(bool show = false)
        {
            if (show == true && recpt1.Visible == true && recpt_list1.Visible == true)
            {
                showComponent(recpt1, false);
                showComponent(recpt_list1, false);
            }
            showComponent(issue1, show);
            showComponent(list1, show);
            showImageComponent(show);
        }



        public void showImageComponent(bool show)
        {
            if (show == true)
            {
                if (image1.Visible == false)
                    showComponent(image1, true);
            }
            else
            {
                if (image1.Visible == true)
                    showComponent(image1, false);
            }
        }

        void showComponent(Control c, bool show = false)
        {
            if (show == false)
            {
                c.Hide();
            }
            else
            {
                c.Show();
            }
        }

        public void SetResult(ref List<string[]> result)
        {

            issue1.SetResult(ref result);
            recpt1.SetResult(ref result);
        }


    }
}
