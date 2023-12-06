using System;
using System.IO;
using Lab4ClassLibrary;
using McMaster.Extensions.CommandLineUtils;

namespace Lab4
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            CommandLineApplication app = new CommandLineApplication();
            app.HelpOption();

            app.Command("version", command =>
            {
                command.Description = "Info about the program and author";
                command.OnExecute(() =>
                {
                    Console.WriteLine("This program was made by Vladyslav Bohushko");
                    Console.WriteLine("Application version: v0.9.0");
                    Console.WriteLine("Variant 6");
                    Console.WriteLine("Group IPZ-41/1");
                    Console.WriteLine("Was made with love to programming :)");
                });
            });

            app.Command("set-path", command =>
            {
                command.Description = "Setting path's to input/output files";
                CommandOption pathOption = command.Option("-p|--path <path>",
                    "Path to the folder with input and output files", CommandOptionType.SingleValue);
                pathOption.IsRequired();

                command.OnExecute(() =>
                {
                    string pathValue = pathOption.Value();
                    Environment.SetEnvironmentVariable("LAB_PATH", pathValue, EnvironmentVariableTarget.User);
                    Console.WriteLine($"LAB_PATH was set to: {pathValue}");
                });
            });

            app.Command("run", command =>
            {
                command.Description = "Execute lab (1-3)";
                CommandArgument selectedLab = command.Argument("lab", "The lab to run (lab1, lab2, lab3)");
                CommandOption inputPath = command.Option("-i|--input <path>", "Input txt file path",
                    CommandOptionType.SingleValue);
                CommandOption outputPath = command.Option("-o|--output <path>", "Output txt file path",
                    CommandOptionType.SingleValue);

                command.OnExecute(() =>
                {
                    var inputOption = DeterminePath(inputPath.Value(), "input.txt");
                    var outputOption = DeterminePath(outputPath.Value(), "output.txt");

                    if (File.Exists(inputOption))
                    {
                        string labValue = selectedLab.Value;
                        ExecuteLab(labValue, inputOption, outputOption);
                    }
                    else
                    {
                        Console.WriteLine($"Can't find input.txt file by path {inputOption}\n\n");
                        command.ShowHelp();
                    }
                });
            });

            app.OnExecute(() => app.ShowHelp());

            return app.Execute(args);
        }

        private static string DeterminePath(string option, string fileName)
        {
            if (!string.IsNullOrEmpty(option)) return option;
            
            option = Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User)
                     ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            if (!string.IsNullOrEmpty(option))
            {
                option = Path.Combine(option, fileName);
            }

            return option;
        }

        private static void ExecuteLab(string labValue, string inputOption, string outputOption)
        {
            if (string.IsNullOrEmpty(labValue) || (labValue != "lab1" && labValue != "lab2" && labValue != "lab3"))
            {
                Console.WriteLine("Invalid lab value. Use lab1, lab2, or lab3.");
            }
            else
            {
                switch (labValue)
                {
                    case "lab1":
                        Lab1.Execute(inputOption, outputOption);
                        break;
                    case "lab2":
                        Lab2.Execute(inputOption, outputOption);
                        break;
                    case "lab3":
                        Lab3.Execute(inputOption, outputOption);
                        break;
                }
            }
        }
    }
}