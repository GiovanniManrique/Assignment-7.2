using System;

class Program
{
    // Returns true when the character is an uppercase or lowercase vowel.
    static bool IsVowel(char letter)
    {
        return "aeiouAEIOU".Contains(letter);
    }

    static string ReverseVowels(string text)
    {
        char[] letters = text.ToCharArray();
        int left = 0;
        int right = letters.Length - 1;

        while (left < right)
        {
            // Move each pointer until it reaches a vowel.
            while (left < right && !IsVowel(letters[left]))
            {
                left++;
            }

            while (left < right && !IsVowel(letters[right]))
            {
                right--;
            }

            // Swap the vowels found at the left and right positions.
            if (left < right)
            {
                char temporary = letters[left];
                letters[left] = letters[right];
                letters[right] = temporary;

                left++;
                right--;
            }
        }

        return new string(letters);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Reverse Vowels Program");
        Console.Write("Enter a string: ");

        string input = Console.ReadLine() ?? "";
        string result = ReverseVowels(input);

        Console.WriteLine($"Reversed vowels: {result}");
    }
}

