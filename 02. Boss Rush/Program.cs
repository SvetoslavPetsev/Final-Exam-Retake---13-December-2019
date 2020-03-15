using System;
using System.Text.RegularExpressions;

namespace _02._Boss_Rush
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Regex pattern = new Regex(@"^\|(?<name>[A-Z]{4,})\|\:\#(?<title>[A-Za-z]+\ [A-Za-z]+)\#$");
            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                Match matchInput = pattern.Match(input);
                if (matchInput.Success)
                {
                    string bossName = matchInput.Groups["name"].Value;
                    string bossTitle = matchInput.Groups["title"].Value;
                    int strength = bossName.Length;
                    int armor = bossTitle.Length;
                    
                    Console.WriteLine($"{bossName}, The {bossTitle}");
                    Console.WriteLine($">> Strength: {strength}");
                    Console.WriteLine($">> Armour: {armor}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
