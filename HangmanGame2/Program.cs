using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    /// <summary>
    /// This game is called Hangman. The goal is to guess the word that is hidden in asterisks. 
    /// Try to guess the word within 10 mistakes.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Game description at the start of the game.
            int numberOfWrongGuessesLeft = 10;
            Console.WriteLine("This is the hangman game! \nTry to guess the word guessing one letter at a time." +
                "\nYou have {0} wrong guesses to start with. \nTry to guess the word before you run out of wrong guesses.", numberOfWrongGuessesLeft);
            /* 
             * An array of strings is created which contains words used in the hangman game.
             * From this array a word will be chosen at random.
             * The chosen word will then be hidden by turning all the letters in asterisks.
            */
            string[] listOfWords = new string[10];
            listOfWords[0] = "class";
            listOfWords[1] = "property";
            listOfWords[2] = "parameter";
            listOfWords[3] = "method";
            listOfWords[4] = "argument";
            listOfWords[5] = "object";
            listOfWords[6] = "variable";
            listOfWords[7] = "string";
            listOfWords[8] = "integer";
            listOfWords[9] = "signature";
            Random pickRandomWord = new Random();
            var numberInIndex = pickRandomWord.Next(0, 10);
            string pickedWord = listOfWords[numberInIndex];
            char[] guess = new char[pickedWord.Length];
            for (int i = 0; i < pickedWord.Length; i++)
            {
                guess[i] = char.Parse("*");
            }
            Console.WriteLine(guess);
            Console.WriteLine("Guess a letter!");
            /*
             * Two lists contain the guessed letters and wrong letters guessed. 
             * These lists are used to give feedback on the input to show how well the player is playing the game.       
            */
            List<string> guessedLetters = new List<string>();
            List<string> guessedWrongLetters = new List<string>();
            // Console.WriteLine(pickedWord);
            /*
             * The user is able to make guesses till they either win or lose the game.
             * In case the input is not valid the user will be prompted to try and give valid input.
            */
            while (true)
            {
                string userInput = Console.ReadLine().ToLower().Trim();
                if (userInput.Length == 1)
                {
                    /*
                     * There are a few steps the the input will be checked on after a valid input.
                     * The input will be compared to the picked word.
                     * It will then be determined if the input has been given before.
                     * Then the input will be checked if it guessed a letter or if it was a wrong guess.                     
                     * Finally is the user has made too many mistakes, then they lose. If they guessed all the letters, then they win.
                    */
                    for (int j = 0; j < pickedWord.Length; j++)
                    {
                        if (char.Parse(userInput) == pickedWord[j]) // the input will be compared to each letter in the picked word.
                        {
                            guess[j] = char.Parse(userInput); 
                        }
                    }
                    Console.WriteLine(guess);
                    if (guessedLetters.Contains(userInput) || guessedWrongLetters.Contains(userInput)) // prevent duplicate wrong guesses and guessed letters.
                    {
                        Console.WriteLine("You already guessed this letter!");
                        continue;
                    }
                    if (!(pickedWord.Contains(userInput)))
                    {
                        guessedWrongLetters.Add(userInput);
                        numberOfWrongGuessesLeft--;
                    }
                    if (pickedWord.Contains(userInput))
                    {
                        guessedLetters.Add(userInput);
                        Console.WriteLine("You guessed right!");
                        /*  
                         * If number of the guessed letters and length of picked word are the same then the user wins.
                         * Before this check the input has already been compared to the guessed letters list. 
                         * If it was not checked before then the user could also win by inputting the same guessed letter for the length of the picked word.
                        */ 
                        if (guessedLetters.Count == pickedWord.Length)   
                        {
                            Console.WriteLine("You guessed the word! \nYou win!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (numberOfWrongGuessesLeft < 0)
                    {
                        Console.WriteLine("You lose! \nThe answer is: \n{0}", pickedWord.ToUpper());
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    Console.WriteLine("You have {0} wrong guess(es) left.", numberOfWrongGuessesLeft);
                    Console.WriteLine("Wrong guess(es): " + String.Join(", ", guessedWrongLetters));
                }
                else
                {
                    Console.WriteLine("Please provide a valid input and press enter :).");
                    continue;
                }
            }
        }
    }
}


