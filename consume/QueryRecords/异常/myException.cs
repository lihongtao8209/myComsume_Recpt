using System;
using System.Collections.Generic;
using System.Text;

namespace myException
{
    public class IAmCheckException : System.Exception
    {//声明异常
        public IAmCheckException(string msg) : base(msg) { }
        public IAmCheckException() { }
    }
    public class IAmMySqlException : System.Exception
    {//声明异常
        public IAmMySqlException(string msg) : base(msg) { }
        public IAmMySqlException() { }
    }
    public class IAmMyDayTimeQueryException : System.Exception
    {
        public IAmMyDayTimeQueryException(string msg) : base(msg) { }
        public IAmMyDayTimeQueryException() { }
    }
    public class IAmIssueQueryException : System.Exception
    {
        public IAmIssueQueryException(string msg) : base(msg) { }
        public IAmIssueQueryException() { }
    }
}
