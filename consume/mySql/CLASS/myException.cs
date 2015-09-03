using System;
using System.Collections.Generic;
using System.Text;

namespace mySql.CLASS
{
        public class IAmMySqlException : System.Exception
        {//声明异常
            public IAmMySqlException(string msg) : base(msg) { }
            public IAmMySqlException() { }
        }
}
