namespace BudgetProgram.BudgetLists
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Percentageexpense class contains dictionary with percentage expeses.
    /// </summary>
    public class PercentageExpense : ILogable
    {
        /// <summary>
        /// Property for Name that contains percentage expenses.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///Property for dictionary of all expenses.
        /// </summary>
        public Dictionary<string, decimal> HouseholdPercentageExpenses { get; set; }
        private const int Percentage = 100;
        /// <summary>
        /// Construktor that sets the property name to Procentuella utgiften.
        /// </summary>
        public PercentageExpense()
        {
            Name = "Procentuella utgiften";
        }
        // View interface for comments.
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
        // View interface for comments.
        public string GetErrorMessageForNull()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
            .Append('\t').Append(Name).AppendLine(" är ej specificerad, och behandlas ej.\r\n");

            return sb.ToString();
        }
    }
}
