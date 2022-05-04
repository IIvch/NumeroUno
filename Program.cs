using System;
using System.Collections.Generic;
using System.Linq;

namespace NumeroUno
{
    internal class Program
    {
        private static readonly Dictionary<char, char> Pairs = new()
        {
            { '{', '}' },
            { '[', ']' },
            { '(', ')' }
        };
        private static void Main(string[] args)
        {
            Console.WriteLine("\nВведите последовательность скобок, либо нажмите 'Enter/ВВод' для отображения тестовых последовательностей");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                input = "{[()]}) }[]{ {()[] {()t.me/i_vch[]} ({)}";
            var data = input.Split(' ')
            .Select(s => new { Input = s, Result = Bracket(s) ? "True" : "False" });

            foreach (var item in data)
            {
                Console.WriteLine("{0,-26} \t--{1,5}", item.Input, item.Result);
            }

            var result = data.Select(i => i.Result).ToArray();

            Console.ReadKey(true);
        }
        private static bool Bracket(string str)
        {

            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            var stack = new Stack<char>();
            foreach (var symbol in str)
            {
                if (Pairs.ContainsKey(symbol))
                {
                    stack.Push(symbol);
                }
                else if (!Pairs.ContainsValue(symbol)) continue;
                else if (stack.Count == 0) return false;
                else if (Pairs[stack.Pop()] != symbol)
                {
                    return false;
                }
            }

            return stack.Count == 0;

        }
    }
}