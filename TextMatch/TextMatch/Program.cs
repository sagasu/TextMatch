using System;
using Services;


namespace TextMatch
{
    /// <summary>
    /// This application takes two arguments.
    /// A BaseString and a Substring
    /// It searches for a Substring inside a BaseString and displays the indexes, separated by comma.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if(args == null || args.Length != 2)
            {
                PrintHelp();
                return;
            }

            var baseString = args[0];
            var substring = args[1];

            var allIndexes = new StringService().GetAllIndexesOf(baseString, substring);

            Console.WriteLine(string.Join(", ",allIndexes));
        }

        private static void PrintHelp()
        {
            const string helpMessage = @"
                This application takes 2 argumets. Usage:
                TextMatch.exe <Parameter1> <Parameter2>

                If you want to use a space inside a parameter, be sure to use quotes, as in an example below
                TextMatch.exe ""Wellcome Home Sir"" ""Home Sir""
                ";
            Console.WriteLine(helpMessage);
        }
    }
}
