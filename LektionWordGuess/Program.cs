using System.Reflection;

namespace LektionWordGuess
{


    class WordGuessingGame
    {
        static string[] words = { "apple", "banana", "cherry", "date", "orange" };
        static string[] hardwords = { "teorihandbok", "hjulverkstaden", "huvudbonad", "shackmatt", "presentation" };
        static Random random = new Random();
        static int highscore = 0;
        static string[] args;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWord Guessing Game");
                Console.WriteLine("1. Play Game");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    PlayGame();
                }
                else if (choice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void PlayGame()
        {
            int points = 0;
            Console.WriteLine("Do you want " +
                              "\n1: Easy mode" +
                              "\n2: Hard mode");

            int diff = int.Parse(Console.ReadLine());
            string wordToGuess = "";
            if (diff == 1)
            {
                wordToGuess = words[random.Next(words.Length)];

            }
            else if (diff == 2)
            {
                wordToGuess = hardwords[random.Next(hardwords.Length)];
            }



            char[] guessedWord = new char[wordToGuess.Length];
            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }

            int attemptsLeft = 6;

            while (attemptsLeft > 0)
            {
                Console.WriteLine($"\nWord: {new string(guessedWord)}");
                Console.WriteLine($"Attempts left: {attemptsLeft}");
                Console.Write("Guess a letter: ");





                try
                {
                    var userinput = Console.ReadLine().ToLower();
                    char guess = userinput[0];
                    bool correctGuess = false;


                    while (!(userinput.ToString().Length == 1 && char.IsLetter(guess)))
                    {
                        Console.WriteLine("Invalid input");
                        Console.Write("Guess a letter: ");
                        userinput = Console.ReadLine().ToLower();
                        guess = userinput[0];
                    }



                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guess)
                        {

                            guessedWord[i] = guess;
                            correctGuess = true;
                            points++;
                        }
                    }

                    if (!correctGuess)
                    {

                        points--;
                        attemptsLeft--;
                        Console.WriteLine("Incorrect guess!");
                        Clue(wordToGuess, guessedWord);

                    }

                    if(attemptsLeft == 2)
                    {
                        GiveUp(wordToGuess);
                    }


                    if (new string(guessedWord) == wordToGuess)
                    {

                        Console.WriteLine($"Congratulations! You guessed the word: {wordToGuess}");
                        NewHighScore(points);
                        return;
                    }

                    

                    
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                }
                
            }
            Console.WriteLine($"Game over! The word was: {wordToGuess}");
            NewHighScore(points);




        }

        static void GiveUp(string wordToGuess)
        {

            Console.WriteLine("Do you want to give up?");
            string forfeit = Console.ReadLine();
            if(forfeit == "yes")
            {
                Console.WriteLine("The word was " + wordToGuess);
                Main(args);
            }
        }

        static void Clue( string wordToGuess, char[] guessedWord)
        {
            string checkguess = new string(guessedWord);
            Console.WriteLine("Do you want a clue? ");
            string theclue = Console.ReadLine(); 
            if(theclue == "yes")
            {
               foreach(char c in wordToGuess)
                {
                    if(!checkguess.Contains(c))
                    {
                        Console.WriteLine(c);
                        return;
                    }
                }
            }
        }

        static void NewHighScore(int points)
        {
            if (points < 0)
            {
                points = 0;
            }

            if (points > highscore)
            {
                highscore = points;
                Console.WriteLine("Congratz new highscore " + points);
            }
            else
            {
                Console.WriteLine("Your points = " + points);
            }
        }
    }
}
