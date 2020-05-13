using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnifyResponse.Common
{
    /// <summary>
    /// 统一返回值
    /// </summary>
    public interface IResponse
    {
        //
        // 摘要:
        //     /// 执行成功与否。 ///
        bool Status
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 错误编码。默认为0，表示没有错误。 /// 定义在统一的地方。 ///
        int ErrorCode
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 错误文案。默认为空字符串。 /// 直接由后端返回错误原因，一般直接是error对应的错误文案，将来可以由前端再次定义。 ///
        string ErrorMessage
        {
            get;
            set;
        }
    }
}
