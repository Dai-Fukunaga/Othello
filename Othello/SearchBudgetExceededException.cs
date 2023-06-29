using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class SearchBudgetExceededException : Exception
    {
        public SearchBudgetExceededException(string message) : base(message) { }
    }
}
