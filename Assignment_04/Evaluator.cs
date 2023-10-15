using System.Collections.Generic;
using System;

namespace Calculator
{
    public class Evaluator
    {
        public string stringSolve(string equation)
        {
            Stack<char> operators = new Stack<char>();
            Stack<decimal> operands = new Stack<decimal>();

            int i = 0;
            int length = equation.Length;
            int openBracketCount = 0;
            int closeBracketCount = 0;
            char prevChar = ' ';
            bool negOperator = false;
            while (i < length)
            {
                if (char.IsDigit(equation[i]) || equation[i] == '.')
                {
                    if (equation[i] == '.' && prevChar == '.')
                    {
                        Console.WriteLine("Invalid expression: Expression should be clear");
                        return "";
                    }
                    if (prevChar == ')')
                    {
                        Console.WriteLine("Invalid expression: Expression should be clear");
                        return "";
                    }
                    decimal number = 0;
                    decimal decimalPart = 0;
                    decimal decimalMultiplier = 0.1m;
                    bool isDecimal = false;
                    while (i < length && (char.IsDigit(equation[i]) || equation[i] == '.'))
                    {
                        if (equation[i] == '.')
                        {
                            isDecimal = true;
                        }
                        else if (!isDecimal)
                        {
                            number = number * 10 + (equation[i] - '0');
                        }
                        else
                        {
                            decimalPart += (equation[i] - '0') * decimalMultiplier;
                            decimalMultiplier *= 0.1m;
                        }
                        i++;
                    }
                    i--;
                    decimal result = isDecimal ? number + decimalPart : number;
                    if (negOperator)
                    {
                        result = -result;
                        negOperator = false;
                    }
                    operands.Push(result);
                }
                else if (equation[i] == '(')
                {
                    if (!IsOperator(prevChar) && prevChar != ' ' && prevChar != '(')
                    {
                        return ("Invalid expression: Expression should be clear");
                    }
                    operators.Push(equation[i]);
                    openBracketCount++;
                }
                else if (equation[i] == ')')
                {
                    closeBracketCount++;
                    if (closeBracketCount > openBracketCount)
                    {
                        return ("Invalid expression: Unmatched closing bracket");
                    }
                    else if (IsOperator(prevChar) || prevChar == '(')
                    {
                        return ("Invalid expression");
                    }
                    while (operators.Peek() != '(')
                    {
                        decimal result;
                        bool flag;
                        (result, flag) = Evaluate(operands, operators);
                        if (!flag)
                        {
                            return "Division by zero is not allowed";
                        }
                        operands.Push(result);
                    }
                    operators.Pop();
                }
                else if (IsOperator(equation[i]))
                {
                    if (prevChar == '(' || IsOperator(prevChar) || prevChar == ' ')
                    {
                        if ((prevChar == 'x' || prevChar == 'X') && (equation[i] == '-'))
                        {
                            negOperator = true;
                            i++;
                            continue;
                        }
                        else if ((equation[i] == '-') && prevChar == '/')
                        {
                            negOperator = true;
                            i++;
                            continue;
                        }
                        else
                        {
                            return ("Invalid Expression");
                        }
                    }
                    while (operators.Count > 0 && Precedence(equation[i]) <= Precedence(operators.Peek()))
                    {
                        decimal result;
                        bool flag;
                        (result, flag) = Evaluate(operands, operators);
                        if (!flag)
                        {
                            return "Division by zero is not allowed";
                        }
                        operands.Push(result);
                    }
                    operators.Push(equation[i]);
                }
                else if (equation[i] == ' ' || equation[i] == '\r' || equation[i] == '\n')
                {
                    i++;
                    continue;
                }
                else
                {
                    return "Invalid Expression";
                }
                prevChar = equation[i];
                i++;
            }
            if (openBracketCount != closeBracketCount)
            {
                return "Unbalanced brackets";
            }
            if (IsOperator(prevChar) || prevChar == '(')
            {
                return "Invalid expression";
            }
            while (operators.Count > 0)
            {
                decimal result;
                bool flag;
                (result, flag) = Evaluate(operands, operators);
                if (!flag)
                {
                    return "Division by zero is not allowed";
                }
                operands.Push(result);
            }
            return (operands.Pop()).ToString();
        }
        private bool IsOperator(char c)
        {
            return (c == '+' || c == '-' || c == '/' || c == 'x' || c == 'X');
        }

        private int Precedence(char c)
        {
            if (c == '+')
            {
                return 1;
            }
            if (c == '-')
            {
                return 2;
            }
            if (c == 'x' || c == 'X')
            {
                return 3;
            }
            if (c == '/')
            {
                return 4;
            }
            return -1;
        }

        private (decimal, bool) Evaluate(Stack<decimal> operands, Stack<char> operators)
        {
            decimal a = operands.Pop();
            decimal b = operands.Pop();
            char op = operators.Pop();
            if (op == '+')
            {
                return (b + a, true);
            }
            if (op == '-')
            {
                return (b - a, true);
            }
            if (op == 'x' || op == 'X')
            {
                return (b * a, true);
            }
            if (op == '/')
            {
                try
                {
                    decimal res = b / a;
                    return (res, true);
                }
                catch (DivideByZeroException ex)
                {
                    return (0, false);
                }
            }
            return (0, false);
        }
    }
}
