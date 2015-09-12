using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Macro;
using Check;
using issue_recpt_Consume;
using Tool;
using myException;

namespace Query_records
{
    public partial class recpt : UserControl
    {
        //代理-事件
        //全部查询
        public delegate void Del_Query_Recpt_Records();
        public event Del_Query_Recpt_Records Event_Query_Recpt_Records;
        //条件查询
        public delegate void Del_Query_Recpt_Records_Filter(List<string> arg);
        public event Del_Query_Recpt_Records_Filter Event_Query_Recpt_Records_Filter;
        //事件的参数 1.时间 2.条码 3.货号 4.品名 5.专柜名称
        List<string> arg = new List<string>();
        public recpt()
        {
            InitializeComponent();
            EnableFilter();
        }



        private void CollectFilterFormula()
        {
            string dateTime = daytime_query1.GetDate();
            /*
            if (t_barcode.Text == "" && t_name.Text == "" && t_shoppeName.Text == "" && dateTime == "")
            {
                throw new IAmIssueQueryException("未设置查询条件");
            }*/
            arg.Clear();
            //1.时间 2.条码 3.货号 4.品名 5.专柜名称
            arg.Add(dateTime);
            arg.Add(t_barcode.Text);
            arg.Add(t_item_no.Text);
            arg.Add(t_name.Text);
            arg.Add("");

            List<string> r = arg.FindAll(delegate(string s)
              {
                  return s.Trim() == "";
              });

            if (r.Count == arg.Count)
            {
                throw new IAmIssueQueryException("未设置查询条件");
            }
        }
        private void EnableFilter(bool show = false)
        {
            tbc_Filter.Enabled = show;
        }

        private void chk_Filter_CheckedChanged(object sender, EventArgs e)
        {
            EnableFilter(true);
        }

        private void btn_doQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_Filter.Checked == true)
                {
                    CollectFilterFormula();
                    Event_Query_Recpt_Records_Filter(arg);
                }
                else
                {
                    Event_Query_Recpt_Records();
                }
            }
            catch (IAmMyDayTimeQueryException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IAmIssueQueryException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





    }
}
