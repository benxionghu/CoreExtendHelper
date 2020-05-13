using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnifyResponse.Common
{
    public class ResponseResult<T> : IResponse
    {
        /// <summary>
        ///  当前请求执行成功与否。
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 错误编码。默认为0，表示没有错误。 /// 定义在统一的地方。
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 错误文案。默认为空字符串。 /// 直接由后端返回错误原因，一般直接是error对应的错误文案，将来可以由前端再次定义
        /// </summary>
        public string ErrorMessage { get; set; }


        /// <summary>
        /// 最重要的返回数据。 /// 可以是number,bool,string,array,object
        /// </summary>
        public T Data
        {
            get;
            set;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected ResponseResult()
        {
            Status = true;
            ErrorCode = 0;
            ErrorMessage = string.Empty;
        }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="result"></param>
        protected ResponseResult(T result)
        {
            Status = true;
            ErrorCode = 0;
            ErrorMessage = string.Empty;
            Data = result;
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
        protected ResponseResult(bool status, int errorCode, string errorMessage)
        {
            Status = status;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}
