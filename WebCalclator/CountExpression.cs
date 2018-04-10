using System;
using System.Collections.Generic;


namespace WebCalclator
{
    public class CountExpression
    {
        bool is_op(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
        int prior(char v)
        {
            switch (v)
            {
                case '+':
                case '-': return 2;
                case '*':
                case '/': return 3;
                default:
                    return 0;
            }
        }
        bool isDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
        string getPolishNotation(string expression)
        {
            string result = "";
            bool wasOperation = true;
            Stack<char> operators = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == ' ')
                    continue;
                if (isDigit(expression[i]) || expression[i] == ',')
                {
                    result += expression[i];
                    wasOperation = false;
                }
                else
                {
                    if (expression[i] == '-' && i + 2 < expression.Length && isDigit(expression[i + 2]))
                        if (wasOperation)
                        {
                            result += '-';
                            continue;
                        }
                    result += ' ';
                    wasOperation = true;
                    if (operators.Count == 0 || prior(operators.Peek()) < prior(expression[i]))
                        operators.Push(expression[i]);

                    else
                    {
                        while (operators.Count != 0 && prior(operators.Peek()) >= prior(expression[i]))
                        {
                            result += ' ';
                            result += operators.Peek();
                            operators.Pop();
                        }

                        operators.Push(expression[i]);
                    }
                    result += ' ';

                }
            }

            while (operators.Count != 0)
            {
                result += ' ';
                result += operators.Peek();
                operators.Pop();
            }

            return result;
        }

        string convertPolishNotation(string temp)
        {
            string[] polishNotationArray= temp.Split(' ');

            Stack<double> numbers = new Stack<double>();
            foreach (string el in polishNotationArray)
            {
                double isNum;
                if (double.TryParse(el, out isNum))
                    numbers.Push(isNum);
                else
                {
                    switch(el)
                    {
                        case "+":
                            numbers.Push(numbers.Pop() + numbers.Pop());
                            break;
                        case "*":
                            numbers.Push(numbers.Pop() * numbers.Pop());
                            break;
                        case "-":
                            numbers.Push(-numbers.Pop() + numbers.Pop());
                            break;
                        case "/":
                            double lastNumber = numbers.Pop();
                            double firstNumber = numbers.Pop();
                            numbers.Push(firstNumber / lastNumber);
                            break;
                    }
                }
            }
            if (numbers.Count == 0)
                return "";
            string res = numbers.Pop().ToString();

            return res[0] == '-' ? "- " + res.Substring(1) : res;
        }
        public string Counting(string expression)
        {
            string temp = getPolishNotation(expression);
            string result = convertPolishNotation(temp);

            return result;
        }
    }
}