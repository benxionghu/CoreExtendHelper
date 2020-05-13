using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnifyResponse.Common;
using UnifyResponse.Model.Request;

namespace UnifyResponse.Controllers
{
    [ApiController]
    [Route("api/Home")]
    public class HomeController : ApiControllerBase
    {
        /// <summary>
        /// 成功的演示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSuccess")]
        public ResponseResult<string> GetSuccess(int id)
        {
            return new ResponseSuccessResult<string>($@"成功的事例{id}");
        }

        [HttpPost("Post")]
        public async Task<string> Post([FromBody] GetErrorRequest value)
        {
            return value.Text;
        }

        [HttpPost("GetError")]
        public ResponseResult<string> GetError([FromBody]GetErrorRequest request)
        {
            var text = $@"失败的实例 请求参数为:{request.Id} {request.Text}";
            return new ResponseSuccessResult<string>(text);
        }

        [HttpGet("GetPageResult")]
        public ResponseResult<PageResult<string>> GetPageResult()
        {
            var result = new List<string>();
            result.Add("这个是分页信息展示");
            result.Add("这个是分页信息展示1");
            result.Add("这个是分页信息展示2");
            return new ResponseSuccessResult<PageResult<string>>(new PageResult<string>
            {
                CurrentIndex = 1,
                TotalCount = 0,
                Result = result
            });
        }

        [HttpGet("Error")]
        public ResponseResult<string> Error()
        {
            throw new Exception("错误的演示");
        }
    }
}