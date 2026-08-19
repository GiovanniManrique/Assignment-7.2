using System;
using System.Collections.Generic;

class Program
{
    static bool IsAnagram(string firstText, string secondText)
    {
        // Anagrams must contain the same number of characters.
        if (firstText.Length != secondText.Length)
        {
            return false;
        }

        Dictionary<char, int> characterCounts = new Dictionary<char, int>();

        // Count how many times each character occurs in the first string.
        foreach (char character in firstText)
        {
            if (characterCounts.ContainsKey(character))
            {
                characterCounts[character]++;
            }
            else
            {
                characterCounts[character] = 1;
            }
        }

        // Subtract each character found in the second string.
        foreach (char character in secondText)
        {
            if (!characterCounts.ContainsKey(character))
            {
                return false;
            }

            characterCounts[character]--;

            if (characterCounts[character] < 0)
            {
                return false;
            }
        }

        return true;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Anagram Checker");

        Console.Write("Enter the first string: ");
        string firstString = Console.ReadLine() ?? "";

        Console.Write("Enter the second string: ");
        string secondString = Console.ReadLine() ?? "";

        bool result = IsAnagram(firstString, secondString);
        Console.WriteLine($"Is an anagram: {result.ToString().ToLower()}");
    }
}

