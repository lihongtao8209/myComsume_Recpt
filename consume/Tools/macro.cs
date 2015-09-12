using System;
using System.Collections.Generic;
using System.Text;

namespace Tools
{
    public struct macro
    {
        public const string nullValue = "null";
        public const string isShoppeGood = "1";
        public const string isNotShoppeGood = "0";
        public const string affected0Row = "0";
        public const int succeed=1;
        public const int failed = 0;
        public const int isInputItemNo = 0;
        public const int isInputItemName = 1;
    }

    public struct CheckKey
    {
        public const int PreConditonCheck = 0;
        public const int EmptyCheck = 1;
        public const int NdigitCheck = 2;
        public const int MinDigitCheck = 3;
        public const int MaxDigitCheck = 4;
        public const int PostiveNumberCheck = 5;
        public const int FileCheck = 6;
        public const int StrTypeCheck = 7;
        //
        public const string IsNullCheckStr = "0";
        public const string IsZeroCheckStr = "1";
    }

    public struct PreConditonCheck_Value
    {
        //只能是数字大于等于0
        public const int onlyDigital = 0;
        //只能是正数或负数
        public const int onlyDigitalAndNegative = 1;
        //只能是正数
        public const int onlyPostiveNumber = 2;
    }
   public struct EmptyCheck_Value
    {
        //是空
        public const int setEmpty = 0;
        //非空
        public const int notSetEmpty = 1;
    }
    struct NdigitCheck_Value
    {
        //条码的位数
        public const int barCodeMaxDigit = 14;
        //发货数量的位数
        public const int issueItemQtyDigit = 4;
    }
    struct MinDigitCheck_Value
    {
        public const int  barCodeMinDigit = 8;
        public const int issueItemQtyDigit = 1;
    }
    struct MaxDigitCheck_Value
    {
        public const int barCodeMaxDigit = 13;
        public const int issueItemQtyDigit = 4;
        public const int name = 33;
    }

    public struct FileCheck_Value
    {
        //路径正确 
        public const int onlyPathRight = 0;
        public const int onlyPathRight_JpgSuffix = 1;
        public const int onlySuffix_Jpg = 10;
        public const int onlyFileExist = 11;
        public const string Jpg=".JPG";
    }

    public struct StrTypeCheck_Value
    {
        public const int onlyDigit = 0;
        public const int onlyAlphabet = 1;
        public const int onlyChineseIdeograph = 2;
    }

    public struct CheckStr_Vlaue
    {
        public const string inputData = "输入的数据";
        public const string realTimeStock="实时库存";
        public const string shoppeName= "专柜商品名称";
        public const string itemNo = "货号";
    }
}
