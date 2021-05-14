using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetProgram.HelperMethods
{
    class ExpenseHelper
    {
        public decimal Totalexpences(Dictionary<string, decimal> expenses)
        {
            decimal total = 0;
            foreach (var item in expenses.Values)
            {
                total += item;
            }
            return total;
        }
    }
}
