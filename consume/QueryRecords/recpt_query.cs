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
        //事件的参数 1.时间 2.货号
        List<string> arg = new List<string>();
        //
        ControlTool controlTool = new ControlTool();
        //
        string m_item_no;

        public recpt()
        {
            InitializeComponent();
            ctrl_name_itemNo1.Event_ctrl_name_itemNo_List_Selected += new ctrl_name_itemNo.Del_ctrl_name_itemNo(ctrl_name_itemNo_List_Selected);
            EnableFilter();
        }



        private void CollectFilterFormula()
        {
            string dateTime = daytime_query1.GetDate();
            if (ctrl_name_itemNo1.inPutData == "" && dateTime == "")
            {
                throw new IAmIssueQueryException("未设置查询条件");
            }
            arg.Clear();
            //1.时间  2.货号 
            arg.Add(dateTime);
            arg.Add(m_item_no);
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

        private void ctrl_name_itemNo_List_Selected(object sender, object e)
        {
            try
            {
                //查询
                Query0();
                controlTool.Focus(btn_doQuery);

            }
            catch (IAmCheckException ex)
            {
                MessageBox.Show(ex.Message);
                //清空
                ctrl_name_itemNo1.Empty_ListBox();
            }
            catch (Tools.IAmMySqlException ex)
            {
                MessageBox.Show(ex.Message);
                //清空
                ctrl_name_itemNo1.Empty_ListBox();
            }
            finally
            {

            }
        }

        private void Query0()
        {
            List<string[]> r = null;
            if (ctrl_name_itemNo1.inPutType == Tools.macro.isInputItemNo)
            {
                r = ctrl_name_itemNo1.consume_items_supplier_result.FindAll(s =>
                {
                    if (s[0] == ctrl_name_itemNo1.inPutData)
                    {
                        return true;
                    }
                    return false;
                }

               );
                if (r.Count != 1)
                {
                    throw new Tools.IAmMySqlException("得到的数据不正确" + r.Count.ToString());
                }
            }
            if (ctrl_name_itemNo1.inPutType == Tools.macro.isInputItemName)
            {
                r = ctrl_name_itemNo1.consume_items_supplier_result.FindAll(s =>
                {
                    if (s[1] == ctrl_name_itemNo1.inPutData)
                    {
                        return true;
                    }
                    return false;
                }

               );
                if (r.Count != 1)
                {
                    throw new Tools.IAmMySqlException("得到的数据不正确" + r.Count.ToString());
                }
            }
            m_item_no = r[0][0];
        }

        public string Item_no
        {
            get
            {
                return m_item_no;
            }
        }

        public void SetResult(ref List<string[]> result)
        {
            ctrl_name_itemNo1.consume_items_supplier_result = result;
        }





    }
}
