namespace BudgetProgram.BudgetLists
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class PercentageExpense : ILogable
    {
        public string Name { get; set; }
        public Dictionary<string, decimal> HouseholdPercentageExpenses { get; set; }
        private const int percentage = 100;

        public PercentageExpense()
        {
            Name = "Procentuella utgiften";
        }
        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expenses)
        {
            var sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
                .Append("Den procentuella utgiften ")
                .Append(expenses.Key)
                .Append(" på ")
                .AppendFormat($"{expenses.Value * percentage}%")
                .AppendLine(" gick inte att dra då det saknas pengar.");

            return sb.ToString();
        }

        public string GetErrorMessageForNULL()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
            .AppendLine($"\t{Name} är ej specificerad, och behandlas ej.\r\n");

            return sb.ToString();
        }
    }
}
