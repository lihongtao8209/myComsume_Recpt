using System;
using System.Collections.Generic;
using System.Text;

namespace Macro
{
    struct macro
    {
        public const string nullValue = "null";
        public const string isShoppeGood = "1";
        public const string isNotShoppeGood = "0";
        public const string affected0Row = "0";
        public const int succeed=1;
        public const int failed = 0;
    }

    struct CheckKey
    {
        public const int PreConditonCheck = 0;
        public const int EmptyCheck = 1;
        public const int NdigitCheck = 2;
        public const int MinDigitCheck = 3;
        public const int MaxDigitCheck = 4;
        public const int PostiveNumberCheck = 5;
        //
        public const string IsNullCheckStr = "0";
        public const string IsZeroCheckStr = "1";
    }

    struct PreConditonCheck_Value
    {
        //只能是数字大于等于0
        public const int onlyDigital = 0;
        //只能是正数或负数
        public const int onlyDigitalAndNegative = 1;
        //只能是正数
        public const int onlyPostiveNumber = 2;
    }
    struct EmptyCheck_Value
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


    struct CheckStr_Vlaue
    {
        public const string realTimeStock="实时库存";
        public const string shoppeName= "专柜商品名称";
        public const string itemNo = "货号";
    }

    public  struct FlowFlag
    {
        public const int query_issue_record = 4;
        public const int query_recpt_record = 5;
        public int Get_query_issue_record() { return query_issue_record; }
        public int Get_query_recpt_record() { return query_recpt_record; }
    }
}
