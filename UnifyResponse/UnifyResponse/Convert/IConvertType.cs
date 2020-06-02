namespace UnifyResponse.Convert
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="IntputRequest">请求参数类型</typeparam>
    /// <typeparam name="OutPutResult">返回参数类型</typeparam>
    public interface IConvertType<IntputRequest, OutPutResult>
    {
        /// <summary>
        /// 参数转换
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        OutPutResult Convert(IntputRequest input);
    }
}