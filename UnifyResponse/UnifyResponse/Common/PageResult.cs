using System.Collections.Generic;

namespace UnifyResponse.Common
{
    public class PageResult<T>
    {
        //
        // 摘要:
        //     /// 总记录数 ///
        public int TotalCount
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 当前页码 ///
        public int CurrentIndex
        {
            get;
            set;
        }


        //
        // 摘要:
        //     /// 返回数据列表 ///
        public IList<T> Result
        {
            get;
            set;
        }
    }
}
