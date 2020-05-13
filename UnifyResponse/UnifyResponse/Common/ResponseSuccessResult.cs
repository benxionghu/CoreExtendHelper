using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnifyResponse.Common
{
    public class ResponseSuccessResult<T> : ResponseResult<T>
    {
        //
        // 摘要:
        //     /// 初始化 ///
        public ResponseSuccessResult()
        {
        }

        //
        // 摘要:
        //     /// 初始化 ///
        //
        // 参数:
        //   td:
        public ResponseSuccessResult(T td)
            : base(td)
        {
        }
    }
}
