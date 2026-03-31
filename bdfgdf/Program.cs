using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Завдання 1
        var rnd = new Random();
        var numbers = Enumerable.Range(0, 100).Select(x => rnd.Next(1, 1000)).ToList();

        var primes = numbers.Where(IsPrime).ToList();
        var fibs = numbers.Where(IsFibonacci).ToList();

        File.WriteAllLines("primes.txt", primes.Select(x => x.ToString()));
        File.WriteAllLines("fibonacci.txt", fibs.Select(x => x.ToString()));

        Console.WriteLine($"Total: {numbers.Count}");
        Console.WriteLine($"Primes: {primes.Count}");
        Console.WriteLine($"Fibonacci: {fibs.Count}");

        // Завдання 2
        Console.WriteLine("Enter file path:");
        string path = Console.ReadLine();

        Console.WriteLine("Word to find:");
        string find = Console.ReadLine();

        Console.WriteLine("Word to replace:");
        string replace = Console.ReadLine();

        string text = File.ReadAllText(path);
        int count = text.Split(find).Length - 1;

        text = text.Replace(find, replace);
        File.WriteAllText(path, text);

        Console.WriteLine($"Replacements: {count}");

        // Завдання 3
        Console.WriteLine("Text file path:");
        string textPath = Console.ReadLine();

        Console.WriteLine("Moderation words file path:");
        string modPath = Console.ReadLine();

        string content = File.ReadAllText(textPath);
        var badWords = File.ReadAllText(modPath)
            .Split(new[] { ' ', '\n', '\r', '.', ',', '!' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in badWords)
        {
            content = content.Replace(word, new string('*', word.Length));
        }

        File.WriteAllText(textPath, content);
        Console.WriteLine("Moderation done");

        // Завдання 4
        Console.WriteLine("File to reverse:");
        string reversePath = Console.ReadLine();

        string reverseText = File.ReadAllText(reversePath);
        string reversed = new string(reverseText.Reverse().ToArray());

        File.WriteAllText("reversed.txt", reversed);
        Console.WriteLine("Reversed file created");

        // Завдання 5
        string numbersPath = "numbers.txt";

        if (File.Exists(numbersPath))
        {
            var nums = File.ReadAllLines(numbersPath).Select(int.Parse).ToList();

            var positive = nums.Where(x => x > 0).ToList();
            var negative = nums.Where(x => x < 0).ToList();
            var twoDigit = nums.Where(x => x >= 10 && x <= 99 || x <= -10 && x >= -99).ToList();
            var fiveDigit = nums.Where(x => x >= 10000 && x <= 99999 || x <= -10000 && x >= -99999).ToList();

            File.WriteAllLines("positive.txt", positive.Select(x => x.ToString()));
            File.WriteAllLines("negative.txt", negative.Select(x => x.ToString()));
            File.WriteAllLines("twodigit.txt", twoDigit.Select(x => x.ToString()));
            File.WriteAllLines("fivedigit.txt", fiveDigit.Select(x => x.ToString()));

            Console.WriteLine($"Positive: {positive.Count}");
            Console.WriteLine($"Negative: {negative.Count}");
            Console.WriteLine($"Two-digit: {twoDigit.Count}");
            Console.WriteLine($"Five-digit: {fiveDigit.Count}");
        }
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
            if (number % i == 0)
                return false;
        return true;
    }

    static bool IsFibonacci(int number)
    {
        int x1 = 5 * number * number + 4;
        int x2 = 5 * number * number - 4;
        return IsPerfectSquare(x1) || IsPerfectSquare(x2);
    }

    static bool IsPerfectSquare(int x)
    {
        int s = (int)Math.Sqrt(x);
        return s * s == x;
    }
}