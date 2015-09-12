using Macro;
using myException;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Check
{
    public class DoCheck
    {
        Dictionary<int, int> checkDic = new Dictionary<int, int>();
        Dictionary<string, string> checkDic2 = new Dictionary<string, string>();
        string m_errorMsg = macro.nullValue;
        public void toCheck(string checkFunName, string checkFunRegular, string checkedStr)
        {
            checkDic2.Clear();
            checkDic2.Add(checkFunName, checkFunRegular);
            Check2(checkedStr, checkDic2);
        }
        public void toCheck(int checkFunName, int checkFunRegular, string checkedStr)
        {
            checkDic.Clear();
            checkDic.Add(checkFunName, checkFunRegular);
            Check(checkedStr, checkDic);
        }
        //检查
        public void Check(string checkedStr, Dictionary<int, int> checkDic)
        {
            foreach (KeyValuePair<int, int> checkItem in checkDic)
            {
                if (checkItem.Key == CheckKey.PreConditonCheck)
                {
                    PreConditonCheck(checkedStr, checkItem.Value);
                }

                if (checkItem.Key == CheckKey.EmptyCheck)
                {
                    EmptyCheck(checkedStr, checkItem.Value);
                }

                if (checkItem.Key == CheckKey.NdigitCheck)
                {
                    NdigitCheck(checkedStr, checkItem.Value);
                }

                if (checkItem.Key == CheckKey.MinDigitCheck)
                {
                    MinDigitCheck(checkedStr, checkItem.Value);
                }

                if (checkItem.Key == CheckKey.MaxDigitCheck)
                {
                    MaxDigitCheck(checkedStr, checkItem.Value);
                }

            }

        }

        public void Check2(string checkedStr, Dictionary<string, string> checkDic)
        {
            foreach (KeyValuePair<string, string> checkItem in checkDic)
            {
                if (checkItem.Key == CheckKey.IsNullCheckStr)
                {
                    IsNullCheck(checkedStr, checkItem.Value);
                }
                if (checkItem.Key == CheckKey.IsZeroCheckStr)
                {
                    IsZeroCheck(checkedStr, checkItem.Value);
                }
            }
        }
        //
        public void PreConditonCheck(string checkedStr, int condition)
        {
            string pattern = "";
            if (condition == PreConditonCheck_Value.onlyDigital)
            {
                m_errorMsg = "输入的应该为数字(大于0)";
                pattern = @"^[0-9]*$";
            }
            if (condition == PreConditonCheck_Value.onlyDigitalAndNegative)
            {
                m_errorMsg = "输入的应该为正数,负数,0";
                pattern = @"^(\+?[1-9][0-9]*$|\-[1-9][0-9]*$|0)";
            }

            if (condition == PreConditonCheck_Value.onlyPostiveNumber)
            {
                m_errorMsg = "为非负数";
                pattern = @"(^[1-9][0-9]*$|^0{1}$)";
            }

            bool bresult = Regex.IsMatch(checkedStr, pattern);
            if (bresult == false)
            {
                throw new myException.IAmCheckException(m_errorMsg);
            }
        }
        //
        public void EmptyCheck(string checkedStr, int condition)
        {

            if (condition == EmptyCheck_Value.setEmpty)
            {
                if (checkedStr != "" && checkedStr != null)
                {
                    m_errorMsg = "输入的值不为空";
                    throw new IAmCheckException(m_errorMsg);
                }
            }
            if (condition == EmptyCheck_Value.notSetEmpty)
            {
                if (checkedStr == "" || checkedStr == null)
                {
                    m_errorMsg = "输入的值为空";
                    throw new IAmCheckException(m_errorMsg);
                }
            }
        }
        public void NdigitCheck(string checkedStr, int condition)
        {
            if (checkedStr.Length != condition)
            {
                m_errorMsg = string.Format("输入的位数应为{0}位", condition);
                throw new IAmCheckException(m_errorMsg);
            }
        }

        public void MinDigitCheck(string checkedStr, int condition)
        {
            if (checkedStr.Length < condition)
            {
                m_errorMsg = string.Format("输入的位数小于{0}位", condition);
                throw new IAmCheckException(m_errorMsg);
            }
        }

        public void MaxDigitCheck(string checkedStr, int condition)
        {
            if (checkedStr.Length > condition)
            {
                m_errorMsg = string.Format("输入的位数大于{0}位", condition);
                throw new IAmCheckException(m_errorMsg);
            }
        }
        //是否为空
        public void IsNullCheck(string str, string content)
        {
            if (str == "" || str == "null" || str == null)
            {
                throw new IAmCheckException(string.Format("输入的{0}为空", content));
            }
        }
        //是否为零
        public void IsZeroCheck(string str, string content)
        {
            if (str == "0")
            {
                throw new IAmCheckException(string.Format("输入的{0}为0", content));
            }
        }
    }
}




