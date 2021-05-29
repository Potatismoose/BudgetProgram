namespace BudgetProgram.BudgetLists
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class Expense : ILogable
    {
        public string Name { get; set; }
        public Dictionary<string, decimal> HouseholdExpenses { get; set; }

        public Expense()
        {
            Name = "Utgiften";
        }

        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expenseOrIncome)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
                .Append("\tUtgiften ")
                .Append(expenseOrIncome.Key)
                .Append(" på ")
                .AppendFormat("{0:C}", expenseOrIncome.Value)
                .AppendLine(" gick inte att dra då det saknas pengar.\r\n");

            return sb.ToString();
        }

        public string GetErrorMessageForNull()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
            .Append('\t').Append(Name).AppendLine(" är ej specificerad, och behandlas ej.\r\n");

            return sb.ToString();
        }
    }
}