using SQL_FLOW;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SqlFlow
{
    public class base_Flow
    {
        protected IssueHelper issueHelp = null;
        public virtual void Do(ref  List<string[]> result)
        {

        }
        public string FormatWorkDateString(string work_date)
        {//2015/9/2 11:27:39
            work_date = work_date.Replace(" ", "");
            work_date = work_date.Replace(":", "");
            work_date = work_date.Replace("/", "");
            work_date = work_date.Replace("-", "");
            //如果是14位 20150904120943 
            //如果是12位 201594120943
            if (work_date.Length == 12)
            {
                work_date = work_date.Insert(4, "0");
                work_date = work_date.Insert(6, "0");
            }
            return work_date;
        }
    }
    public class Query_issue_recordFlow : base_Flow
    {
        public Query_issue_recordFlow(IssueHelper issueHelp)
        {
            base.issueHelp = issueHelp;
        }

        public override void Do(ref  List<string[]> result)
        {
            issueHelp.Query_issue_record(ref result);
        }
    }

    public class Query_recpt_recordFlow : base_Flow
    {
        public Query_recpt_recordFlow(IssueHelper issueHelp)
        {
            base.issueHelp = issueHelp;
        }
        public override void Do(ref  List<string[]> result)
        {
            issueHelp.Query_recpt_record(ref result);
        }
    }
}
