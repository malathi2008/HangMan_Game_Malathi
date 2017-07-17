using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Game_Malathi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to HANGMAN Game! Guess the word game..... " + "\n" + "\n");


            Random random = new Random((int)DateTime.Now.Ticks);

            string[] words = { "Hello", "Meeting", "School", "Swimming", "Station", "Train" };

            string Guess = words[random.Next(0, words.Length)];
            string GuessedUppercase = Guess.ToUpper();

            StringBuilder ShowWord = new StringBuilder(Guess.Length);
            for (int i = 0; i < Guess.Length; i++)
                ShowWord.Append('_');

            if (Guess.Length == 8)
            {
                Console.WriteLine("The number of charachters in the word are: _ _ _ _ _ _ _ _");
                Console.WriteLine("Correct guess score: 8 points and bonus 15 points, Total score: 23 points");
            }

            if (Guess.Length == 7)
            {
                Console.WriteLine("The number of charachters in the word are: _ _ _ _ _ _ _");
                Console.WriteLine("Correct guess score: 7 points and bonus 15 points, Total score: 22 points");
            }

            if (Guess.Length == 6)
            {
                Console.WriteLine("The number of charachters in the word are: _ _ _ _ _ _");
                Console.WriteLine("Correct guess score: 6 points and bonus 15 points, Total score: 21 points");
            }

            if (Guess.Length == 5)
            {
                Console.WriteLine("The number of charachters in the word are: _ _ _ _ _");
                Console.WriteLine("Correct guess score: 5 points and bonus 15 points, Total score: 20 points");
            }

            List<char> GuessedCorrect = new List<char>();
            List<char> GuessedWrong = new List<char>();

            int lives = 5;
            bool result = false;
            int RevealedLetters = 0;

            string input;
            char guess;

            while (!result && lives > 0)
            {
                //Console.Write("Guess a correct letter for the word: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (GuessedCorrect.Contains(guess))
                {
                    Console.WriteLine("You have already guessed this letter '{0}', and it is correct!", guess);
                    continue;
                }

                else if (GuessedWrong.Contains(guess))
                {
                    Console.WriteLine("You have already guessed this letter '{0}', and it is wrong!", guess);
                    continue;
                }

                if (GuessedUppercase.Contains(guess))
                {
                    GuessedCorrect.Add(guess);

                    for (int i = 0; i < Guess.Length; i++)
                    {
                        if (GuessedUppercase[i] == guess)
                        {
                            ShowWord[i] = Guess[i];
                            RevealedLetters++;

                        }
                    }

                    if (RevealedLetters == Guess.Length)
                        result = true;

                }
                else
                {
                    GuessedWrong.Add(guess);
                    if (lives == 5)
                    {

                        PrintHangMan4();
                    }
                    if (lives == 4)
                    {

                        PrintHangMan3();
                    }
                    if (lives == 3)
                    {

                        PrintHangMan2();

                    }
                    if (lives == 2)
                    {

                        PrintHangMan1();

                    }

                    if (lives == 1)
                    {

                        PrintHangMan0();
                    }


                    lives--;
                }

                Console.WriteLine(ShowWord.ToString());
            }
            int points = Guess.Length;
            int bonus = 15;
            int score = points + bonus;
            int guessed = RevealedLetters;
            if (result)
            {
                Console.WriteLine("You won! You guessed the correct word......");
                Console.WriteLine("Your score is" + " " + points + " " + "with bonus points your total score is" + " " + score);
            }


            else
            {
                Console.WriteLine("You lost the game!..... The correct word is '{0}':", Guess);
                Console.WriteLine("Your correct guesses are" + " " + guessed + " " + "letters and your total score is:" + guessed);

            }
            Console.ReadLine();
        }

        static void PrintHangMan0()
        {
            Console.WriteLine("__________   ");
            Console.WriteLine("|         |  ");
            Console.WriteLine("|         0  ");
            Console.WriteLine("|        /|\\ ");
            Console.WriteLine("|        / \\ ");
            Console.WriteLine("|            ");
            Console.WriteLine("|            ");
        }
        static void PrintHangMan1()
        {
            Console.WriteLine("__________   ");
            Console.WriteLine("|         |  ");
            Console.WriteLine("|         0  ");
            Console.WriteLine("|        /|\\ ");
            Console.WriteLine("|         ");
            Console.WriteLine("|            ");
            Console.WriteLine("|            ");
        }
        static void PrintHangMan2()
        {
            Console.WriteLine("__________   ");
            Console.WriteLine("|         |  ");
            Console.WriteLine("|         0  ");
            Console.WriteLine("|         ");
            Console.WriteLine("|         ");
            Console.WriteLine("|            ");
            Console.WriteLine("|            ");
        }
        static void PrintHangMan3()
        {
            Console.WriteLine("__________   ");
            Console.WriteLine("|         |  ");
            Console.WriteLine("|           ");
            Console.WriteLine("|         ");
            Console.WriteLine("|         ");
            Console.WriteLine("|            ");
            Console.WriteLine("|            ");
        }
        static void PrintHangMan4()
        {
            Console.WriteLine("__________   ");
            Console.WriteLine("|      ");
            Console.WriteLine("|           ");
            Console.WriteLine("|         ");
            Console.WriteLine("|         ");
            Console.WriteLine("|            ");
            Console.WriteLine("|            ");
        }
    }
    }

