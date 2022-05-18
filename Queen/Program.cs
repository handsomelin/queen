using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queen
{
    public class Solution
    {
        public bool Validate(IList<int> queen)
        {
            int n = queen.Count;
            int x = n - 1;
            int y = queen[n - 1];
            for (int i = 0; i < n - 1; i++)
            {
                int j = queen[i];
                if (i == x || j == y)
                    return false;
                if (Math.Abs(i - x) == Math.Abs(j - y))
                    return false;
            }
            return true;
        }
        public IList<string> Transfer(List<int> queen)
        {
            IList<string> output = new List<string>();
            foreach (var q in queen)
            {
                var row = string.Empty;
                for (int i = 0; i < queen.Count; i++)
                {
                    if (i == q)
                        row += "Q";
                    else
                        row += ".";
                }
                row += "\n";
                output.Add(row);
            }
            return output;
        }
        public int GoBack(List<int> queen, int n)
        {
            int next = 0;
            queen.RemoveAt(queen.Count - 1);
            if (queen.Any() == false)
                return -1;
            next = queen.Last() + 1;
            while (next >= n)
            {
                queen.RemoveAt(queen.Count - 1);
                if (queen.Any() == false)
                    return -1;
                next = queen.Last() + 1;
            }
            queen.RemoveAt(queen.Count - 1);
            return next;
        }
        public void Print(IList<int> queen)
        {
            Console.Write("Queen: ");
            for (int i = 0; i < queen.Count; i++)
            {
                Console.Write($"{queen[i]} ");
            }
            Console.Write("\n");
        }
        public void Print(IList<IList<string>> output)
        {
            for (int i = 0; i < output.Count; i++)
            {
                for (int j = 0; j < output[i].Count; j++)
                {
                    Console.Write($"{output[i][j]}");
                }
                Console.Write($"\n");
            }
            Console.Write("\n");
        }
        public void AddQueen(IList<IList<string>> output, IList<string> q)
        {
            output.Add(q);
        }
        public IList<IList<string>> SolveNQueens(int n)
        {
            var output = new List<IList<string>>();
            var queen = new List<int>();
            int next = 0;
            while (queen.Count <= n)
            {
                queen.Add(next);
                if (Validate(queen))
                {
                    if (queen.Count == n)
                    {
                        AddQueen(output, Transfer(queen));
                        next = GoBack(queen, n);
                        if (next == -1)
                            break;
                    }
                    else
                    {
                        next = 0;
                    }
                }
                else
                {
                    next = queen.Last() + 1;
                    if (next < n)
                    {
                        queen.RemoveAt(queen.Count - 1);
                    }
                    else
                    {
                        next = GoBack(queen, n);
                        if (next == -1)
                            break;
                    }
                }
            }
            Print(output);
            return output;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            sol.SolveNQueens(8);
        }
    }
}
