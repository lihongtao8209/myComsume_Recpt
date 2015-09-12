using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SqlFlow;
using System.Collections;
using Tools;



namespace Query_records
{
    public partial class list : UserControl
    {
        Flow flow = null;
        base_Flow bf = null;
        FileHelper fileHelp = new FileHelper();
        DoCheck doCheck = new DoCheck();
        //代理-事件
        //全部查询
        public delegate void Del_ShowImage_Issue_Records(string imageFullFileName);
        public event Del_ShowImage_Issue_Records Event_ShowImage_Issue_Records;
        public list()
        {
            InitializeComponent();
            flow = new Flow();
        }


        public void AddToList()
        {
            listView1.Items.Clear();
            try
            {
                string item_no = "";
                string item_name = "";
                string shoppe_name = "";
                string barcode = "";
                string issue_qty = "";
                string rt_stock = "";
                string work_date = "";
                string imageName = "";
                ListViewItem item = null;
                List<string[]> result = new List<string[]>();
                Flow flow = new Flow();
                base_Flow bf = flow.InitFlow(flow.flowFlag.Get_query_issue_record());
                //"品名", "专柜商品名称", "条码", "货号", "发货量", "库存", "更新时间" ,"图像文件名"
                bf.Do(ref result);
                //
                for (int i = 0; i < result.Count; i++)
                {
                    item_name = result[i][0];
                    shoppe_name = result[i][1];
                    barcode = result[i][2];
                    item_no = result[i][3];
                    issue_qty = result[i][4];
                    rt_stock = result[i][5];
                    work_date = result[i][6];
                    imageName = result[i][7];
                    item = new ListViewItem(new string[] { item_name, shoppe_name, barcode, item_no, issue_qty, rt_stock, work_date, imageName });
                    listView1.Items.Add(item);
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddToList_Filter(ref List<string> arg)
        {
            listView1.Items.Clear();
            try
            {
                string item_no = "";
                string item_name = "";
                string shoppe_name = "";
                string barcode = "";
                string issue_qty = "";
                string rt_stock = "";
                string work_date = "";
                string imageName = "";
                ListViewItem item = null;
                List<string[]> result = new List<string[]>();
                bf = flow.InitFlow(flow.flowFlag.Get_query_issue_record());
                bf.Do(ref result);
                //
                Filter(ref arg, ref result);
                //
                for (int i = 0; i < result.Count; i++)
                {
                    item_name = result[i][0];
                    shoppe_name = result[i][1];
                    barcode = result[i][2];
                    item_no = result[i][3];
                    issue_qty = result[i][4];
                    rt_stock = result[i][5];
                    work_date = result[i][6];
                    imageName = result[i][7];
                    item = new ListViewItem(new string[] { item_name, shoppe_name, barcode, item_no, issue_qty, rt_stock, work_date, imageName });
                    listView1.Items.Add(item);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Filter(ref List<string> arg, ref List<string[]> result)
        {
            //arg       可查询条件：0.时间 1.条码 2.货号 3 .品名 4.专柜名称
            //result    结果集    : 0.品名,1.专柜商品名称,2.条码,3.货号,4.发货量,5.库存,6.更新时间,7.图像文件名
            int[] match = new int[] { 0, 0, 0, 0, 0 };
            string[] filterArray = new string[arg.Count];
            arg.CopyTo(filterArray);
            //如果带外参就要使用闭包
            result = result.FindAll(s =>
             {
                 if (filterArray[0].Trim() != "")
                 {
                     if (bf.FormatWorkDateString(s[6]).Contains(filterArray[0]))
                     {
                         match[0] = 1;
                     }
                     else
                     {
                         match[0] = 2;
                     }
                 }
                 if (filterArray[1].Trim() != "")
                 {
                     if (filterArray[1] == s[2])
                     {
                         match[1] = 1;
                     }
                     else
                     {
                         match[1] = 2;
                     }
                 }
                 if (filterArray[2].Trim() != "")
                 {
                     if (filterArray[2] == s[3])
                     {
                         match[2] = 1;
                     }
                     else
                     {
                         match[2] = 2;
                     }
                 }
                 if (filterArray[3].Trim() != "")
                 {
                     if (filterArray[3] == s[0])
                     {
                         match[3] = 1;
                     }
                     else
                     {
                         match[3] = 2;
                     }
                 }
                 if (filterArray[4].Trim() != "")
                 {
                     if (filterArray[4] == s[1])
                     {
                         match[4] = 1;
                     }
                     else
                     {
                         match[4] = 2;
                     }
                 }
                 if (match[0] == 2 || match[1] == 2 || match[2] == 2 || match[3] == 2 || match[4] == 2)
                 {
                     return false;
                 }


                 return true;

             });
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {//单击
            try
            {
                int thisRow = listView1.FocusedItem.Index;
                if (e.Button == MouseButtons.Left && this.listView1.Items.Count > 0)
                {//查找文件名
                    string imageFileName = listView1.SelectedItems[0].SubItems[7].Text;
                    //文件名不能为空
                    doCheck.toCheck(Tools.CheckKey.EmptyCheck, Tools.EmptyCheck_Value.notSetEmpty, imageFileName);
                    //设置根目录,应该可以改变
                    fileHelp.SetrepositoryPath("c:\\");
                    //分析文件名以得到其路径 c:\list\1.txt => c:\list
                    fileHelp.JudgeDirName(imageFileName);
                    string imageFilepath = fileHelp.DateTimeDir + "\\" + imageFileName;
                    //后缀是JPG
                    doCheck.toCheck(Tools.CheckKey.FileCheck, Tools.FileCheck_Value.onlyPathRight_JpgSuffix, imageFilepath);
                    //是否在硬盘上存在
                    doCheck.toCheck(Tools.CheckKey.FileCheck, Tools.FileCheck_Value.onlyFileExist, imageFilepath);
                    //发送显示图片示件
                    Event_ShowImage_Issue_Records(imageFilepath);
                    //MessageBox.Show(path);
                }
            }
            catch (IAmCheckException ex)
            {
                MessageBox.Show(ex.Message+"\n"+ex.StackTrace);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
