using System.Diagnostics.CodeAnalysis;
using ConsoleTableExt;

namespace drink_info
{
    public class TableVisualizationEngine
    {
        public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T:class
        {
            Console.Clear();
            if(tableName==null)
                tableName="";
            System.Console.WriteLine("\n\n");

            ConsoleTableBuilder.From(tableData).WithColumn(tableName).ExportAndWriteLine();
            System.Console.WriteLine("\n\n");
        }
    }
}