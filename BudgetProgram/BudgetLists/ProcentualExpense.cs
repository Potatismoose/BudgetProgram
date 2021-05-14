using System.Collections.Generic;
using System.Linq;

namespace BudgetProgram.BudgetLists
{
    public class ProcentualExpense
    {
        public Dictionary<string, decimal> ProcentualExpenses { get; set; }
        public ProcentualExpense(Dictionary<string, decimal> procentualExpenses)
        {
            foreach (var item in procentualExpenses.Where(x => x.Value <= 0))
            {
                procentualExpenses.Remove(item.Key);
            }

            ProcentualExpenses = procentualExpenses;
        }
    }
}
