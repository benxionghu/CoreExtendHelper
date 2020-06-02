namespace UnifyResponse.Convert
{
    /// <summary>
    /// 转换扩展
    /// </summary>
    public static class ConvertExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="InputRequest">当前参数的类型</typeparam>
        /// <typeparam name="OutPutResult">返回的类型</typeparam>
        /// <param name="input"></param>
        /// <param name="step">接口信息</param>
        /// <returns></returns>
        public static OutPutResult ConvertType<InputRequest, OutPutResult>(this InputRequest input, IConvertType<InputRequest, OutPutResult> step)
        {
            return step.Convert(input);
        }
    }
}