using Macro;
using SQL_FLOW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace SqlFlow
{

    public class Flow
    {
        IssueHelper issueHelp = new IssueHelper();
        base_Flow flow = new base_Flow();
        public string FileName
        {
            get;
            set;
        }

        public base_Flow InitFlow(int flag)
        {
            if (flag == Macro.FlowFlag.query_issue_record)
            {
                flow = new Query_issue_recordFlow(issueHelp);
            }

            if (flag == Macro.FlowFlag.query_recpt_record)
            {
                flow = new Query_recpt_recordFlow(issueHelp);
            }
            return flow;
        }

        public FlowFlag flowFlag
        {
            get;
            set;
        }

        public void CameraFlow(string item_no)
        {
            string work_date = "";
            string name = "";
            string shpeName = "";
            string[] format_work_date = new string[2];
            issueHelp.Camera_Query0(item_no, ref work_date, ref  name, ref shpeName);
            format_work_date = DeleteDateTimeChineseIdeograph(work_date);
            FileName = FormatFileName("issue_" + format_work_date[0], name, shpeName);
            issueHelp.Camera_insert(item_no, FileName, format_work_date[1]);
        }
        public void CameraRecptFlow(string item_no)
        {
            string work_date = "";
            string name = "";
            issueHelp.Camera_Recpt_Query0(item_no, ref work_date, ref  name);
            FileName = FormatFileName("recpt_" + work_date, name, "null");
            issueHelp.Camera_insert(item_no, FileName, work_date, true);
        }
        private string FormatFileName(string work_date, string name, string shpeName)
        {
            string fileName = "";
            string first = FormatWorkDateString(work_date);
            string second = name;
            string third = shpeName;
            fileName = string.Format("{0}_{1}_{2}{3}", first, second, third, FormatSuffix());
            return fileName;
        }
        private string[] DeleteDateTimeChineseIdeograph(string work_date)
        {
            //
            string [] format_work_date=new string [2];
            string format_work_date1 = "";
            string format_work_date2 = "";
            string[] work_date_part;
            work_date_part = work_date.Split(' ');
            if (work_date_part[3] != null)
            {
                string[] hourMinuteSecond;
                hourMinuteSecond = work_date_part[3].Split(':');
                for (int i = 0; i < hourMinuteSecond.Length; i++)
                {
                    if (hourMinuteSecond[i].Length == 1 && i==0)
                    {//小时
                        hourMinuteSecond[i] = (12 + Convert.ToInt32(hourMinuteSecond[i])).ToString();
                    }
                    if (hourMinuteSecond[i].Length == 1)
                    {
                        hourMinuteSecond[i] = "0" + hourMinuteSecond[i];
                    }
                }
                string[] YearMonthDay;
                YearMonthDay=work_date_part[0].Split('/');
                for (int i = 0; i < YearMonthDay.Length; i++)
                {
                    if (YearMonthDay[i].Length == 1)
                    {
                        YearMonthDay[i] = "0" + YearMonthDay[i];
                    }
                }
                format_work_date1 = YearMonthDay[0] + YearMonthDay[1] + YearMonthDay[2] + hourMinuteSecond[0] + hourMinuteSecond[1] + hourMinuteSecond[2];
                format_work_date2 = string.Format("{0}/{1}/{2} {3}:{4}:{5}", YearMonthDay[0], YearMonthDay[1], YearMonthDay[2], hourMinuteSecond[0], hourMinuteSecond[1], hourMinuteSecond[2]);
                format_work_date[0] = format_work_date1;
                format_work_date[1] = format_work_date2;
            }
            //
            return format_work_date;
        }
        private string FormatSuffix()
        {
            return ".jpg";
        }
        private string FormatWorkDateString(string work_date)
        {//2015/9/2 11:27:39
            string[] work_date_part;
            work_date = work_date.Replace(" ", "");
            work_date = work_date.Replace(":", "");
            work_date = work_date.Replace("/", "");
            work_date = work_date.Replace("-", "");
            //如果是14位 20150904120943 
            //如果是12位 201594120943
            //string[] work_date_part = work_date.Split('_');
            work_date_part = work_date.Split('_');
            if (work_date_part[0] != null && work_date_part[1] != null && work_date_part[1].Length == 12)
            {
                work_date_part[1] = work_date_part[1].Insert(4, "0");
                work_date_part[1] = work_date_part[1].Insert(6, "0");
            }
            work_date = work_date_part[0] + "_" + work_date_part[1];
            return work_date;
        }



    }



}
