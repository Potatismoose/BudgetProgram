using BudgetProgram.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace BudgetProgram.BudgetLists
{
    public class Expense : ILogable
    {
        public Dictionary<string, decimal> HouseholdExpenses { get; set; }
        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expense)
        {
           
            StringBuilder sb = new StringBuilder();
            sb.Append("Utgiften ")
                .Append(expense.Key)
                .Append(" på ")
                .AppendFormat("{0:C}", expense.Value)
                .AppendLine(" gick inte att dra då det saknas pengar.");

            return sb.ToString();
        }
    }
}