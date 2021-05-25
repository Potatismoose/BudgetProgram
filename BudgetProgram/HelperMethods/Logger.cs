using BudgetProgram.BudgetLists;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BudgetProgram.Interfaces
{
    public static class Logger
    {
        private const int percentage = 100;
        private const int PaddingForReportFile = 30;
        private const int PaddingForReportFileError = 4;
        readonly private static string errorlogPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\errorlog {DateTime.Now.ToShortDateString()}.txt";
        readonly private static string reportPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\report.txt";
        public static void LogErrorAndAddToReport(ILogable expenseOrIncome, KeyValuePair<string, decimal> keyValuePair)
        {
            File.AppendAllText(errorlogPath, expenseOrIncome.GetErrorMessageForLogMethod(keyValuePair));
            LogReport(expenseOrIncome, keyValuePair);
            var stringLength = expenseOrIncome.GetErrorMessageForLogMethod(keyValuePair).Length;
            File.AppendAllText(reportPath, expenseOrIncome.GetErrorMessageForLogMethod(keyValuePair).PadLeft(stringLength+PaddingForReportFileError));
        }

        public static void LogReport(ILogable expenseOrIncome, KeyValuePair<string, decimal> keyValuePair)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(keyValuePair.Key.PadRight(PaddingForReportFile));
            if (expenseOrIncome is PercentageExpense)
            {
                sb.Append((keyValuePair.Value * percentage).ToString());
                sb.AppendLine("%");
            }
            else
            {
                sb.AppendLine(keyValuePair.Value.ToString());
            }
            File.AppendAllText(reportPath, sb.ToString());
        }
    }
}
