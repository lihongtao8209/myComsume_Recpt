using Macro;
using SQL_FLOW;
using System;
using System.Collections.Generic;
using System.Text;

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
            issueHelp.Camera_Query0(item_no, ref work_date, ref  name, ref shpeName);
            FileName = FormatFileName("issue_" + work_date, name, shpeName);
            issueHelp.Camera_insert(item_no, FileName, work_date);
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
        private string FormatSuffix()
        {
            return ".jpg";
        }
        private string FormatWorkDateString(string work_date)
        {//2015/9/2 11:27:39
            work_date = work_date.Replace(" ", "");
            work_date = work_date.Replace(":", "");
            work_date = work_date.Replace("/", "");
            work_date = work_date.Replace("-", "");
            //如果是14位 20150904120943 
            //如果是12位 201594120943
            string[] work_date_part = work_date.Split('_');
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
