using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using myException;

namespace QueryRecords
{
    public partial class Daytime_query : UserControl
    {
        const string nullValue = "--";
        const int startYear = 2015;
        List<ComboBox> cbb_List = new List<ComboBox>();
        int[] status = new int[] { 0, 0, 0, 0, 0, 0 };
        public Daytime_query()
        {
            InitializeComponent();
        }

        private void Daytime_query_Load(object sender, EventArgs e)
        {
            Init();
            Init_Year();
            Init_month();
            Init_day();
            Init_hour();
            Init_min();
            Init_sec();
        }

        private void Init()
        {
            cbb_year.Text = nullValue;
            cbb_month.Text = nullValue;
            cbb_day.Text = nullValue;
            cbb_hour.Text = nullValue;
            cbb_min.Text = nullValue;
            cbb_sec.Text = nullValue;
        }

        void Init_Year()
        {
            DateTime t = DateTime.Now;

            for (int i = startYear; i <= t.Year; i++)
            {
                cbb_year.Items.Add(i);
            }
        }
        void Init_month()
        {
            for (int i = 1; i <= 12; i++)
            {
                cbb_month.Items.Add(i);
            }
        }
        void Init_day()
        {
            for (int i = 1; i <= 31; i++)
            {
                cbb_day.Items.Add(i);
            }
        }
        void Init_month_day()
        {
            int maxDay;
            int month = Convert.ToInt32(cbb_month.Text);
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                maxDay = 31;
            }
            else
            {
                maxDay = 30;
            }
            for (int i = 1; i <= maxDay; i++)
            {
                cbb_day.Items.Add(i);
            }
        }
        void Init_hour()
        {
            for (int i = 1; i <= 24; i++)
            {
                cbb_hour.Items.Add(i);
            }
        }
        void Init_min()
        {
            for (int i = 1; i <= 60; i++)
            {
                cbb_min.Items.Add(i);
            }
        }
        void Init_sec()
        {
            for (int i = 1; i <= 60; i++)
            {
                cbb_sec.Items.Add(i);
            }
        }

        private void cbb_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            Init_day();
        }

       
        public string GetDate()
        {
            int sum = 0;
            string dateString = "";
            cbb_List.Clear();
            cbb_List.Add(cbb_year);
            cbb_List.Add(cbb_month);
            cbb_List.Add(cbb_day);
            cbb_List.Add(cbb_hour);
            cbb_List.Add(cbb_min);
            cbb_List.Add(cbb_sec);
            l_showDate.Text=string.Format("{0}-{1}-{2} {3}:{4}:{5}",cbbListText(0),cbbListText(1),cbbListText(2),cbbListText(3),cbbListText(4),cbbListText(5));
            for (int i = 0; i < cbb_List.Count;i++)
            {
                if (IsNotNullValue(cbb_List[i]))
                {
                    status[i] = 1;
                }
                else
                {
                    status[i] = 0;
                }
            }



            for (int i = 0; i < status.Length;i++ )
            {
                if (status[i]==0)
                {
                    for (int j = i + 1; j < status.Length;j++ )
                    {
                        if (status[j] == 1)
                        {
                            throw new IAmMyDayTimeQueryException("日期格式错误!" + l_showDate.Text);
                        }
                    }
                }
                else
                {
                    dateString += cbbListText(i);
                }
                sum += status[i];
            }

            if (sum==0)
            {
                return "";
            }

            return dateString;
            
        }

        private bool IsNotNullValue(ComboBox c)
        {
            if (c.Text == nullValue || c.Text.Trim()=="")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private string cbbListText(int i)
        {
            string text="";
            if (IsNotNullValue(cbb_List[i]))
            {
                 text = string.Format("{0:00}", Convert.ToInt32(cbb_List[i].Text));
            }
            else
            {
                text = cbb_List[i].Text;
            }
            return text;
        }
    }
}
