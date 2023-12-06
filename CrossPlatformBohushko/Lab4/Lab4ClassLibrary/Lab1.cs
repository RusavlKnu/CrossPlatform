using System.IO;
using StreamWriter = System.IO.StreamWriter;

namespace Lab4ClassLibrary
{
    public class Lab1
    {
        public static void Execute(string inputFilePath, string outputFilePath)
        {
            int N;
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = reader.ReadLine();
                string nextLine = reader.ReadLine();

                if (nextLine != null || !int.TryParse(line, out N))
                {
                    WriteError(outputFilePath,"Error: INPUT.txt should contain a single integer value.");
                    return;
                }
            }

            if (N < 1 || N > 109)
            {
                WriteError(outputFilePath ,"Error: Invalid value of N. It should be in the range 1 ≤ N ≤ 109.");
                return;
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