using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Hero_Recruitment
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> heroAndSpells = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] info = input.Split();
                string cmd = info[0];
                if (cmd == "Enroll" && info.Length == 2)
                {
                    string heroName = info[1];
                    if (!heroAndSpells.ContainsKey(heroName))
                    {
                        heroAndSpells.Add(heroName, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                else if (cmd == "Learn" && info.Length == 3)
                {
                    string heroName = info[1];
                    string spellName = info[2];
                    if (heroAndSpells.ContainsKey(heroName))
                    {
                        if (!heroAndSpells[heroName].Contains(spellName))
                        {
                            heroAndSpells[heroName].Add(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has already learnt {spellName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }
                else if (cmd == "Unlearn" && info.Length == 3)
                {
                    string heroName = info[1];
                    string spellName = info[2];
                    if (heroAndSpells.ContainsKey(heroName))
                    {
                        if (heroAndSpells[heroName].Contains(spellName))
                        {
                            heroAndSpells[heroName].Remove(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }
            }
            if (heroAndSpells.Count > 0)
            {
                Console.WriteLine("Heroes:");
                heroAndSpells = heroAndSpells
                    .OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key)
                    .ToDictionary(e => e.Key, y => y.Value);
               
                foreach (var hero in heroAndSpells)
                {
                    Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
                }
            }
        }
    }
}
