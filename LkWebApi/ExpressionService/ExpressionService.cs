using LkWebApi.Helpers;

namespace LkWebApi.ExpressionService
{
    public class ExpressionService
    {
        public double Calculate(string expression)
        {
            PostfixCalculator postfixCalculator = new PostfixCalculator();
            return postfixCalculator.Calculate(expression);
        }
    }
}
