using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnifyResponse.Common;
using UnifyResponse.Convert;
using UnifyResponse.Middlewar;
using UnifyResponse.Model.Request;
using UnifyResponse.Unitl;

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
            var i = 10;
            var b = i.ConvertType(new IntToDoubleStep());
            return new ResponseSuccessResult<string>($@"成功的事例{id}");
        }

        [HttpPost("Error")]
        public async Task<string> Post([FromBody] GetErrorRequest value)
        {
            throw new Exception("错误消息");
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
            var result = new List<string> { "这个是分页信息展示", "这个是分页信息展示1", "这个是分页信息展示2" };
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