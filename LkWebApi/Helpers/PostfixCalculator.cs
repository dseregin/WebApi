using System;
using System.Collections;
using System.Collections.Generic;

namespace LkWebApi.Helpers
{
    /// <summary>
    /// Класс для вычисления постфиксного выражения
    /// </summary>
    public class PostfixCalculator
    {
        public double Calculate(string expression)
        {
            var items = expression.TrimStart().TrimEnd().Split(' ');
            var stack = new Stack<double>();
            double result;

            try
            {
                foreach (var item in items)
                {
                    if (double.TryParse(item, out double number))
                    {
                        stack.Push(number);
                    }
                    else
                    {
                        double number2;
                        switch (item)
                        {

                            case "+":
                                stack.Push(stack.Pop() + stack.Pop());
                                break;

                            case "*":
                                stack.Push(stack.Pop() * stack.Pop());
                                break;

                            case "-":
                                number2 = stack.Pop();
                                stack.Push(stack.Pop() - number2);
                                break;

                            case "/":
                                number2 = stack.Pop();
                                if (number2 == 0)
                                    throw new DivideByZeroException("В Выражении присутствует деление на 0");

                                stack.Push(stack.Pop() / number2);
                                break;

                            case "^":
                                number2 = stack.Pop();
                                stack.Push(Math.Pow(stack.Pop(), number2));
                                break;

                            default:
                                throw new IncorrectSymbolException("Выражение содержит неизвестный оператор");
                        }
                    }
                }

                result = stack.Pop();
                if (stack.Count > 0)
                {
                    throw new IncorrectExpressionlException("Некорректное выражение");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public class IncorrectSymbolException : Exception
        {
            public IncorrectSymbolException(string message) : base(message)
            {
            }
        }
        public class IncorrectExpressionlException : Exception
        {
            public IncorrectExpressionlException(string message) : base(message)
            {
            }
        }
    }
}
