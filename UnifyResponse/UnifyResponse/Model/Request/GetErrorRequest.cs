using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnifyResponse.Model.Request
{
    public class GetErrorRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string Text { get; set; }
    }
}
