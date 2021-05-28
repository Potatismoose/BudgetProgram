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
        /// <summary>
        /// ToDo: Skriv kommentaren
        /// </summary>
        /// <param name="expenses"></param>
        /// <returns></returns>
        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expenses)
        {
            var sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
                .Append("\tDen procentuella utgiften ")
                .Append(expenses.Key)
                .Append(" på ")
                .AppendFormat($"{expenses.Value * Percentage}%")
                .AppendLine(" gick inte att dra då det saknas pengar.\r\n");

            return sb.ToString();
        }
        /// <summary>
        /// ToDo: Skriv kommentaren
        /// </summary>
        /// <returns></returns>
        public string GetErrorMessageForNull()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
            .AppendLine($"\t{Name} är ej specificerad, och behandlas ej.\r\n");

            return sb.ToString();
        }
    }
}
