using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab5ClassLibrary
{
    public class Lab3
    {
        public static string Execute(string inputFilePath, string outputFilePath)
        {
            var reactions = new Dictionary<string, string>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                if (!int.TryParse(reader.ReadLine(), out int m) || m < 0 || m > 1000)
                {
                    string error = "Invalid number of reactions.";
                    Console.WriteLine(error);
                    return error;
                }

                for (int i = 0; i < m; i++)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        string eror = $"Reaction {i + 1} is empty.";
                        Console.WriteLine(eror);
                        return eror;
                    }

                    string[] reaction = line.Split(new string[] { " -> " }, StringSplitOptions.None);
                    if (reaction.Length != 2 || string.IsNullOrEmpty(reaction[0]) ||
                        string.IsNullOrEmpty(reaction[1]) || !IsValidSubstanceName(reaction[0]) ||
                        !IsValidSubstanceName(reaction[1]))
                    {
                        string error = $"Invalid reaction format for reaction {i + 1}.";
                        Console.WriteLine(error);
                        return error;
                    }

                    if (reactions.ContainsKey(reaction[0]))
                    {
                        string error = $"Duplicate reaction found for {reaction[0]}. Looking for  shortest way";
                        Console.WriteLine(error);
                    }

                    reactions[reaction[0]] = reaction[1];
                }

                string startSubstance = reader.ReadLine();
                string desiredSubstance = reader.ReadLine();

                if (!IsValidSubstanceName(startSubstance) || !IsValidSubstanceName(desiredSubstance))
                {
                    string error = "Invalid substance name.";
                    Console.WriteLine(error);
                    return error;
                }

                int result = TransformSubstanceDijkstra(reactions, startSubstance, desiredSubstance);

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine(result);
                    return "To Output file was written: " + result;
                }
            }
        }

        private static bool IsValidSubstanceName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length <= 20 && Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        private static int TransformSubstanceDijkstra(Dictionary<string, string> reactions, string start, string target)
        {
            var visited = new HashSet<string>();
            var queue = new Queue<(string Substance, int Steps)>();
            queue.Enqueue((start, 0));

            while (queue.Count > 0)
            {
                var currentState = queue.Dequeue();
                var currentSubstance = currentState.Substance;
                var currentSteps = currentState.Steps;

                if (currentSubstance == target)
                {
                    return currentSteps;
                }

                if (visited.Contains(currentSubstance))
                {
                    continue;
                }

                visited.Add(currentSubstance);

                if (reactions.ContainsKey(currentSubstance))
                {
                    var neighbor = reactions[currentSubstance];
                    queue.Enqueue((neighbor, currentSteps + 1));
                }
            }

            return -1; // -1 as output means that no satisfuying path was found
        }
    }
}