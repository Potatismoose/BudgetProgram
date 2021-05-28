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
        /// <summary>
        ///  ToDo
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expense)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
                .Append("\tUtgiften ")
                .Append(expense.Key)
                .Append(" på ")
                .AppendFormat("{0:C}", expense.Value)
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