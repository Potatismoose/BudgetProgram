using System;
using System.Collections.Generic;
using System.IO;

namespace BudgetProgram.Interfaces
{
    public static class Logger
    {
        readonly private static string errorlogPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\errorlog {DateTime.Now.ToShortDateString()}.txt";
        readonly private static string reportPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\report.txt";
        public static void LogError(ILogable expense, KeyValuePair<string, decimal> keyValuePair)
        {
            File.AppendAllText(errorlogPath, expense.GetErrorMessageForLogMethod(keyValuePair));
            File.AppendAllText(reportPath, expense.GetErrorMessageForLogMethod(keyValuePair));
        }

        public static void LogReport()
        {
            File.AppendAllText(reportPath, "text");
        }
    }
}
