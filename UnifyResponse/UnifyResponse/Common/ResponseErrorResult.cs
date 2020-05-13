using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnifyResponse.Common
{
    public class ResponseErrorResult<T> : ResponseResult<T>
    {
        //
        // 摘要:
        //     /// 初始化 ///
        public ResponseErrorResult()
            : this(1, "操作失败！")
        {
        }

        //
        // 摘要:
        //     /// 初始化 ///
        //
        // 参数:
        //   errorCode:
        //     错误编码
        //
        //   errorMessage:
        //     错误文案
        public ResponseErrorResult(int errorCode, string errorMessage)
            : this(status: false, errorCode, errorMessage)
        {
        }

        //
        // 摘要:
        //     /// 初始化 ///
        //
        // 参数:
        //   status:
        //     状态
        //
        //   errorCode:
        //     错误编码
        //
        //   errorMessage:
        //     错误文案
        public ResponseErrorResult(bool status, int errorCode, string errorMessage)
            : base(status, errorCode, errorMessage)
        {
        }
    }
}
