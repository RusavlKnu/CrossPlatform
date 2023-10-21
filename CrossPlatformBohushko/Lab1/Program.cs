using System;
using System.IO;

class Program
{
    static void Main()
    {
        int N;
        using (StreamReader reader = new StreamReader("..//..//..//INPUT.txt"))
        {
            string line = reader.ReadLine();
            string nextLine = reader.ReadLine();

            if (nextLine != null || !int.TryParse(line, out N))
            {
                WriteError("Error: INPUT.txt should contain a single integer value.");
                return;
            }
        }

        if (N < 1 || N > 109)
        {
            WriteError("Error: Invalid value of N. It should be in the range 1 ≤ N ≤ 109.");
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

        using (StreamWriter writer = new StreamWriter("..//..//..//OUTPUT.txt"))
        {
            writer.WriteLine(count);
        }
    }

    static void WriteError(string errorMessage)
    {
        using (StreamWriter writer = new StreamWriter("..//..//..//OUTPUT.txt"))
        {
            writer.WriteLine(errorMessage);
        }
    }
}
