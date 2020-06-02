namespace UnifyResponse.Convert
{
    /// <summary>
    /// int转换为Double
    /// </summary>
    public class IntToDoubleStep : IConvertType<int, double>
    {
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public double Convert(int input)
        {
            double.TryParse(input.ToString(), out var outPutResult);
            return outPutResult;
        }
    }
}