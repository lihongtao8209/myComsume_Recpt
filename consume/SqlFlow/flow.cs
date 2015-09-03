using SQL_FLOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlFlow
{
    public class Flow
    {
        IssueHelper issueHelp = new IssueHelper();
        public string FileName
        {
            get;
            set;
        }
        public void CameraFlow(string item_no)
        {
            string work_date="";
            string name="";
            string shpeName="";
            issueHelp.Camera_Query0(item_no,ref work_date,ref  name,ref shpeName);
            FileName = FormatFileName("isssue_"+ work_date, name, shpeName);
            issueHelp.Camera_insert(item_no, FileName, work_date);
        }
        public void CameraRecptFlow(string item_no)
        {
            string work_date = "";
            string name = "";
            issueHelp.Camera_Recpt_Query0(item_no, ref work_date, ref  name);
            FileName = FormatFileName("recpt_"+work_date, name, "null");
            issueHelp.Camera_insert(item_no, FileName, work_date,true);
        }
        private string FormatFileName(string work_date,string name, string shpeName)
        {
            string fileName = "";
            string first=WorkDateString(work_date);
            string second = name;
            string third = shpeName;
            fileName = string.Format("{0}_{1}_{2}{3}", first, second, third, FormatSuffix());
            return fileName;
        }
        private string FormatSuffix()
        {
            return ".jpg";
        }
        private string WorkDateString(string work_date)
        {//2015/9/2 11:27:39
            work_date = work_date.Replace(" ", "");
            work_date = work_date.Replace(":", "");
            work_date = work_date.Replace("/", "");
            work_date = work_date.Replace("-", "");
            return work_date;
        }
    }
}
