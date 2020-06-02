namespace UnifyResponse.Convert
{
    /// <summary>
    /// Double转换为int
    /// </summary>
    public class DoubleToIntStep : IConvertType<double, int>
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int Convert(double input)
        {
            int.TryParse(input.ToString(), out var outPutResult);
            return outPutResult;

        }
    }
}