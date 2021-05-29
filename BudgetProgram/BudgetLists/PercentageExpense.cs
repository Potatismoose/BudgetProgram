namespace BudgetProgram.BudgetLists
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class PercentageExpense : ILogable
    {
        public string Name { get; set; }
        public Dictionary<string, decimal> HouseholdPercentageExpenses { get; set; }
        private const int Percentage = 100;

        public PercentageExpense()
        {
            Name = "Procentuella utgiften";
        }

        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expenseOrIncome)
        {
            var sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
                .Append("\tDen procentuella utgiften ")
                .Append(expenseOrIncome.Key)
                .Append(" på ")
                .AppendFormat($"{expenseOrIncome.Value * Percentage}%")
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
