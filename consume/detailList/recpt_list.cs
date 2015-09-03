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
    public partial class recpt_list : UserControl
    {
        IssueHelper issueHelper = new IssueHelper();
        public recpt_list()
        {
            InitializeComponent();
        }
        public void Add(string item_no)
        {
            try
            {
                string item_name = "";
                string barcode = "";
                string realTimeStock = "";
                string recptQty = "";
                string work_date = "";
                issueHelper.Recpt_Query0(item_no, ref item_name, ref barcode, ref recptQty, ref realTimeStock, ref work_date);
                ListViewItem item = new ListViewItem(new string[] { item_name, barcode, item_no.ToString(), recptQty, realTimeStock, work_date });
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
