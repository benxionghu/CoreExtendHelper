using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UnifyResponse.Common
{
    public class ApiControllerBase : ControllerBase
    {

        /// <summary>
        /// 出现逻辑错误时，使用ReponseErrorResult进行往上传递信息
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMessageDic">错误消息字典</param>
        /// <returns></returns>
        [System.Web.Http.NonAction]
        protected virtual ResponseResult<object> ExitWithReponseErrorResult(int errorCode, IDictionary<int, string> errorMessageDic = null)
        {
            return ExitWithReponseErrorResult<object>(errorCode, errorMessageDic);
        }


        /// <summary>
        /// 出现逻辑错误时，使用ReponseErrorResult进行往上传递信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMessageDic">错误消息字典</param>
        /// <returns></returns>
        [System.Web.Http.NonAction]
        protected virtual ResponseResult<T> ExitWithReponseErrorResult<T>(int errorCode,
            IDictionary<int, string> errorMessageDic = null)
        {
            var errorMessage = "请输入错误信息";
            if (errorMessageDic?.ContainsKey(errorCode) == true)
            {
                errorMessage = errorMessageDic[errorCode];
            }
            return new ResponseErrorResult<T>(errorCode, errorMessage);
        }

        /// <summary>
        /// 执行成功时，使用ResponseSuccessResult进行传递信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual ResponseResult<T> ExitWithReponseSuccessResult<T>(T data)
        {
            return new ResponseSuccessResult<T>(data);
        }
    }
}
