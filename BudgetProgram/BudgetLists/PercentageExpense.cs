namespace BudgetProgram.BudgetLists
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Text;
    public class PercentageExpense : ILogable
    {
        public Dictionary<string, decimal> HouseholdPercentageExpenses { get; set; }

        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expenses)
        {
            var sb = new StringBuilder();
            sb.Append("Den procentuella utgiften ")
                .Append(expenses.Key)
                .Append(" på ")
                .AppendFormat("{0:C}", expenses.Value)
                .AppendLine(" gick inte att dra då det saknas pengar.");

            return sb.ToString();
        }
    }
}
