using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using issueConsume;

namespace detailList
{
    public partial class list : UserControl
    {
        //
        SQL_FLOW.IssueHelper issueHelper = new SQL_FLOW.IssueHelper();
        
        public list()
        {
            InitializeComponent();

        }
        public void Add(string item_no)
        {
            try
            {
                List<string[]> result=new List<string[]>();
                issueHelper.Issue_ListView_Query(item_no, ref result);
                if (result == null || result.Count == 0 || result[0] == null)
                {
                    MessageBox.Show(item_no + "没有查到数据,无法添加！");
                }
                ListViewItem item = new ListViewItem( result[0]);
                listView1.Items.Add(item);
                item.EnsureVisible();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddToList()
        {

        }
    }
}
