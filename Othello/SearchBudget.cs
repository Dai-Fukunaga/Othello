using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Othello
{
    internal class SearchBudget
    {
        private int operations = 0;

        private int maxOperations;

        private long startTime = DateTime.Now.Ticks;

        private long endTime = DateTime.Now.Ticks;

        public static SearchBudget INFINITE = new SearchBudget(-1, -1);

        public SearchBudget(int operations, long time)
        {
            if (operations < 0 && operations != -1)
            {
                throw new Exception("Search operations must be positive.");
            }
            else if (time < 0L && time != -1L)
            {
                throw new Exception("Time must be positive.");
            }
            else
            {
                maxOperations = operations;
                if (time == -1)
                {
                    endTime = -1;
                }
                else
                {
                    endTime = startTime + time;
                }
            }
        }

        public int GetRemainingOperations()
        {
            return maxOperations == -1 ? int.MaxValue : maxOperations - operations;
        }

        public long GetRemainingTime()
        {
            return endTime == -1 ? long.MaxValue : Math.Max(endTime - DateTime.Now.Ticks, 0);
        }

        public void IncrementOperations()
        {
            if (this.GetRemainingOperations() == 0)
            {
                throw new SearchBudgetExceededException("Search operations exceeded.");
            }
            else
            {
                operations++;
            }
        }

        public void CheckTime()
        {
            if (GetRemainingTime() == 0)
            {
                throw new SearchBudgetExceededException("Search time exceeded.");
            }
        }
    }
}
