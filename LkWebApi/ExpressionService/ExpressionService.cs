using LkWebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
