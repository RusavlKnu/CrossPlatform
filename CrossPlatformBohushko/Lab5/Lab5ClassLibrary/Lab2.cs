﻿using System;
using System.IO;
using System.Linq;

namespace Lab5ClassLibrary;

public class Lab2
{
    public static string Execute(string inputFilePath, string outputFilePath)
    {
        string[] words;

        using (StreamReader reader = new StreamReader(inputFilePath))
        {
            if (!int.TryParse(reader.ReadLine()?.Trim(), out int M) || M < 1 || M > 255)
            {
                string error = "Invalid value for M in INPUT.txt";
                Console.WriteLine(error);
                return error;
            }

            words = new string[M];
            for (int i = 0; i < M; i++)
            {
                string word = reader.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(word) || word.Length > 255 || !word.All(char.IsLower) || words.Contains(word))
                {
                    string error = "$Invalid word at line {i + 2} in INPUT.txt";
                    Console.WriteLine(error);
                    return error;
                }
                words[i] = word;
            }

            if (reader.ReadLine() != null)
            {
                string error = "There are more words than specified by M in INPUT.txt";

                Console.WriteLine(error);
                return error;
            }
        }

        Array.Sort(words, (a, b) => a.Length.CompareTo(b.Length));

        int[] dp = new int[words.Length];
        int maxLength = 1;

        for (int i = 0; i < words.Length; i++)
        {
            dp[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (words[i].StartsWith(words[j]))
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            maxLength = Math.Max(maxLength, dp[i]);
        }

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            writer.WriteLine(maxLength);
            return "To Output file was written: " + maxLength;
        }
    }
}