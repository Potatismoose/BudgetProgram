namespace BudgetProgram.BudgetLists
{
    using BudgetProgram.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class Income : ILogable
    {
        public string Name { get; set; }
        public Dictionary<string, decimal> HouseholdIncomes { get; set; }
        /*
         * 
          foreach (var item in income.Where(x => x.Value <= 0))
            {
                Logger.LogError(income as ILogable, item);
                income.Remove(item.Key);
            }
        */

        public Income()
        {
            Name = "Inkomsten";
        }

        public string GetErrorMessageForLogMethod(KeyValuePair<string, decimal> income)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tFelmeddelande")
                .Append("Inkomsten ")
                .Append(income.Key)
                .Append(" på ")
                .AppendFormat("{0:C}", income.Value)
                .AppendLine(" har tagits bort då den var felaktigt formaterad.");

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
