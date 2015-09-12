
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace Tools
{
    public class DoCheck
    {
        Dictionary<int, int> checkDic = new Dictionary<int, int>();
        Dictionary<string, string> checkDic2 = new Dictionary<string, string>();
        string m_errorMsg = macro.nullValue;
        bool isThrowError=false;
        public bool IsThrowError
        {
            set
            {
                isThrowError = value;
            }
        }
        public DoCheck_Result doCheck_Result = new DoCheck_Result();
        /// <summary>
        /// 异常 IAmCheckException
        /// </summary>
        /// <param name="checkFunName"></param>
        /// <param name="checkFunRegular"></param>
        /// <param name="checkedStr"></param>
        public void toCheck(string checkFunName, string checkFunRegular, string checkedStr)
        {
            checkDic2.Clear();
            checkDic2.Add(checkFunName, checkFunRegular);
            Check2(checkedStr, checkDic2);
        }
        /// <summary>
        /// 异常 IAmCheckException
        /// </summary>
        /// <param name="checkFunName"></param>
        /// <param name="checkFunRegular"></param>
        /// <param name="checkedStr"></param>
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

                if (checkItem.Key == CheckKey.FileCheck)
                {
                    FilePathCheck(checkedStr, checkItem.Value);
                }

                if (checkItem.Key == CheckKey.StrTypeCheck)
                {
                    doCheck_Result.IsStrTypeCheck_Result=IsStrTypeCheck(checkedStr, checkItem.Value);
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
                throw new IAmCheckException(m_errorMsg);
            }
        }
        //
        public void FilePathCheck(string checkedStr, int condition)
        {
            Regex regex = null;
            string pattern = "";
            if (condition == FileCheck_Value.onlyPathRight)
            {
                m_errorMsg = "["+checkedStr+"]路径不正确";
                pattern = @"^(?<fpath>([a-zA-Z]:\\)([\s\.\-\w]+\\)*)(?<fname>[\w]+)(?<namext>(\.[\w]+)*)(?<suffix>\.[\w]+)";
                regex = new Regex(pattern);
            }
            if (condition == FileCheck_Value.onlyPathRight_JpgSuffix || condition ==FileCheck_Value.onlySuffix_Jpg)
            {
                m_errorMsg = "[" + checkedStr + "]非JPG文件";
                pattern = @"^(?<fpath>([a-zA-Z]:\\)([\s\.\-\w]+\\)*)(?<fname>[\w]+)(?<namext>(\.[\w]+)*)(?<suffix>\.[\w]+)";
                regex = new Regex(pattern);
            }
           if (condition == FileCheck_Value.onlyFileExist)
           {
               m_errorMsg = "不存在[" + checkedStr + "]JPG文件";
               pattern = @"^(?<fpath>([a-zA-Z]:\\)([\s\.\-\w]+\\)*)(?<fname>[\w]+)(?<namext>(\.[\w]+)*)(?<suffix>\.[\w]+)";
               regex = new Regex(pattern);
           }


            Match result = regex.Match(checkedStr);
            if (result.Success == false)
            {
                throw new IAmCheckException(m_errorMsg);
            }
            if (condition == FileCheck_Value.onlyPathRight_JpgSuffix || condition == FileCheck_Value.onlySuffix_Jpg)
            {
                if (result.Result("${suffix}").ToUpper() != FileCheck_Value.Jpg)
                {
                    throw new IAmCheckException(m_errorMsg);
                }
            }
            if (condition == FileCheck_Value.onlyFileExist)
            {
                string dirPath = result.Result("${fpath}");
                string FileName = checkedStr;
                if (!FileCheck_Value_onlyFileExist.Exist(dirPath, FileName))
                {
                    throw new IAmCheckException(m_errorMsg);
                }
            }
        }

        public void FileFormatCheck(string checkedStr, int condition)
        {
              
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

         //判断是符串是否为数字,字母,汉字
        public bool IsStrTypeCheck(string str, int condition)
        {
            string pattern = "";
            if (condition == StrTypeCheck_Value.onlyDigit)
            {
                pattern = @"^[0-9]*$";
            }
            if (condition == StrTypeCheck_Value.onlyAlphabet)
            {
                pattern = @"^[a-zA-Z]*$";
            }
            if (condition == StrTypeCheck_Value.onlyChineseIdeograph)
            {
                pattern = @"^[\u4e00-\u9fa5]+$";
            }
            return Regex.IsMatch(str, pattern);
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
    public class DoCheck_Result
    {
        public bool IsStrTypeCheck_Result
        {
            get;
            set;
        }
    }
    class FileCheck_Value_onlyFileExist
    {
        //查询 c:\list\1.txt 在 c:\list 是否存在
       public static bool Exist(string fullDirPath,string fullFileName)
        {
            string[] files = Directory.GetFiles(fullDirPath);//得到文件
            foreach (string file in files)//循环文件
            {
                if (file.ToUpper().Trim() == fullFileName.ToUpper().Trim())
                {
                    return true;
                }
            }
            return false;
        }
    }
}




