

using System;
using System.Collections.Generic;
using System.IO;

namespace SpellCheckerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = createDictionary();
            List<string> misspelledWords = new List<string>(); // collect misspelled words

            // 1. Take a user input of a word and check if it has been spelled correctly
            Console.WriteLine("Enter a single word to check:");
            string singleWord = Console.ReadLine();
            bool Correct = false;

            foreach (string word in words)
            {
                if (word != null && word == singleWord)
                {
                    Correct = true;
                    break;
                }
            }

            if (Correct)
            {
                Console.WriteLine(" The word is spelled correctly yay");
            }
            else
            {
                Console.WriteLine("That word is misspelled:(");
                misspelledWords.Add(singleWord);
            }

            // 2. Take a string of words as a user input and check they have all been spelled correctly
            Console.WriteLine("Enter a sentence to check spelling:");
            string sentence = Console.ReadLine();
            string[] sentenceWords = sentence.Split(' ');
            int correctCount = 0;

            foreach (string word in sentenceWords)
            {
                bool found = false;
                foreach (string dictionaryWord in words)
                {
                    if (dictionaryWord != null && dictionaryWord == word)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    Console.WriteLine(" the word is correct!");
                    correctCount++;
                }
                else
                {
                    Console.WriteLine($"{word} is misspelled.");
                    misspelledWords.Add(word);
                }
            }

            // 3. Create a spelling score
            int totalWords = sentenceWords.Length;
            double score = (double)correctCount / totalWords * 100;
            Console.WriteLine($"your spelling score isss {score}% ({correctCount}/{totalWords} correct)");

            // 4. Save misspelled words to file
            if (misspelledWords.Count > 0)
            {
                File.WriteAllLines("MisspelledWords.txt", misspelledWords);
                Console.WriteLine("Misspelled words saved to 'MisspelledWords.txt'");
            }
            else
            {
                Console.WriteLine("No misspelled words found.");
            }
        }

        // This method reads all words from "wordsFile.txt"
        static string[] createDictionary()
        {
            if (File.Exists("wordsFile.txt"))
            {
                return File.ReadAllLines("wordsFile.txt");
            }
            else
            {
                Console.WriteLine("Dictionary file not found, using default words.");
                return new string[] { "apple", "banana", "orange", "grape", "pear" };
            }
        }
    }
}
