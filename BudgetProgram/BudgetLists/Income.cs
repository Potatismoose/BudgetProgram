namespace BudgetProgram.BudgetLists
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class Income : ILogable
    {
        public string Name { get; set; }
        public Dictionary<string, decimal> HouseholdIncomes { get; set; }

        public Income()
        {
            Name = "Inkomsten";
        }

        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> expenseOrIncome)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
                .Append("\tInkomsten ")
                .Append(expenseOrIncome.Key)
                .Append(" på ")
                .AppendFormat("{0:C}", expenseOrIncome.Value)
                .AppendLine(" har tagits bort då den var felaktigt formaterad.");

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
