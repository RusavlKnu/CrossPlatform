using System.IO;
using StreamWriter = System.IO.StreamWriter;

namespace Lab5ClassLibrary
{
    public class Lab1
    {
        public static string Execute(string inputFilePath, string outputFilePath)
        {
            int N;
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = reader.ReadLine();
                string nextLine = reader.ReadLine();

                if (nextLine != null || !int.TryParse(line, out N))
                {
                    string errorMessage = "Error: INPUT.txt should contain a single integer value.";
                    WriteError(outputFilePath, errorMessage);
                    return errorMessage;
                }
            }

            if (N < 1 || N > 109)
            {
                string errorMessage = "Error: Invalid value of N. It should be in the range 1 ≤ N ≤ 109.";
                WriteError(outputFilePath ,errorMessage);
                return errorMessage;
            }

            int count = 0;

            for (int i = 1; i <= N; i++)
            {
                if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0)
                {
                    count++;
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine(count);
            }

            return "To Output file was written: " + count;
        }

        private static void WriteError(string outputFilePath, string errorMessage)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine(errorMessage);
            }
        }
    }
}