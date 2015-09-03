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
        IssueHelper issueHelper = new IssueHelper();
        public list()
        {
            InitializeComponent();
        }
        public void Add(string item_no)
        {
            try
            {
                string item_name = "";
                string shoppe_name = "";
                string barcode = "";
                string realTimeStock = "";
                string rt_stock = "";
                string work_date = "";
                issueHelper.Query0(item_no, ref item_name, ref shoppe_name, ref barcode, ref realTimeStock, ref rt_stock, ref work_date);
                ListViewItem item = new ListViewItem(new string[] { item_name, shoppe_name, barcode, item_no.ToString(), realTimeStock, rt_stock, work_date });
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
