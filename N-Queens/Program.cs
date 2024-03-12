using System;
using System.Collections.Generic;

namespace N_Queens
{

  // https://www.youtube.com/watch?v=Ph95IHmRp5M
  class Program
  {
    static void Main(string[] args)
    {
      Solution s = new Solution();
      var answer = s.SolveNQueens(4);
      foreach (var a in answer)
        foreach(var str in a)
          Console.WriteLine(str);
    }
  }

  public class Solution
  {
    public IList<IList<string>> SolveNQueens(int n)
    {
      HashSet<int> cols = new HashSet<int>();
      HashSet<int> positiveDiagonals = new HashSet<int>();
      HashSet<int> negetiveDiagonals = new HashSet<int>();
      var res = new List<IList<string>>();
      var board = new char[n][];
      for(int i = 0; i < n; i++)
      {
        board[i] = new char[n];
        for(int j = 0; j < n; j++)
        {
          board[i][j] = '.';
        }
      }
      void Backtrack(int r)
      {
        // once we reached the end of the rows we can stop
        if (r == n)
        {
          List<string> temp = new List<string>();
          foreach (var item in board)
          {
            var str = new string(item);
            temp.Add(str);
          }
          res.Add(temp);
          return;
        }

        for (int c = 0; c < n; c++)
        {
          if (cols.Contains(c) || positiveDiagonals.Contains(r + c) || negetiveDiagonals.Contains(r - c)) continue;

          cols.Add(c);
          positiveDiagonals.Add(r + c);
          negetiveDiagonals.Add(r - c);
          board[r][c] = 'Q';

          Backtrack(r + 1);

          cols.Remove(c);
          positiveDiagonals.Remove(r + c);
          negetiveDiagonals.Remove(r - c);
          board[r][c] = '.';
        }

      }
      Backtrack(0);

      return res;
    }
  }
}
