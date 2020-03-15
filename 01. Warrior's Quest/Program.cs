using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _01._Warrior_s_Quest
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            while (true)
            {
                string info = Console.ReadLine();
                if (info == "For Azeroth")
                {
                    break;
                }
                string[] commands = info.Split(" ").ToArray();
                string cmdArg = commands[0];
                if (cmdArg == "GladiatorStance")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if (cmdArg == "DefensiveStance")
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (cmdArg == "Dispel")
                {
                    int index = int.Parse(commands[1]);
                    char symbol = char.Parse(commands[2]);
                    if (index >= 0 && index < input.Length)
                    {
                        input = input.Remove(index, 1);
                        input = input.Insert(index, symbol.ToString());
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                }
                else if (cmdArg == "Target")
                {
                    string modif = commands[1];
                    string substr = commands[2];
                    if (input.Contains(substr))
                    {
                        if (modif == "Change")
                        {
                            string secondStr = commands[3];
                            input = input.Replace(substr, secondStr);
                            Console.WriteLine(input);
                        }
                        else if (modif == "Remove")
                        {
                            input = input.Replace(substr, string.Empty);
                            Console.WriteLine(input);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Command doesn't exist!");
                    }
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }
            }
        }
    }
}
