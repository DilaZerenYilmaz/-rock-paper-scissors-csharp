using System;
using System.Threading;

namespace RockPaperScissorsConsoleApp
{
    public static class CoreGame
    {
        private static GameScore _gameScore = GameScore.GetInstance();

        public static void Run()
        {
            while (true)
            {
                Console.Write("Do you wanna play ? (1 for Yes, 0 for exit, 2 Score) : ");
                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Clear();
                    ErrorInput();
                }

                if (int.TryParse(userInput, out var i))
                {
                    if (i == 0)
                    {
                        Exit();
                    }
                    else if (i == 1)
                    {
                        Game();
                    }
                    else if (i == 2)
                    {
                        PrintScore();
                    }
                    else
                    {
                        ErrorInput();
                    }
                }
                else
                {
                    ErrorInput();
                }
            }
        }

        public static void Game()
        {
            Clear();

            Random r = new Random();

            Console.WriteLine("Computer thinking...");

            GameEnum computerChoose = GameEnum.Rock;

            for (int i = 0; i < 10000; i++)
            {
                computerChoose = (GameEnum)r.Next(0, 2);
            }

            Console.WriteLine("Computer set...");

            Thread.Sleep(1500);

            bool input = true;
            GameEnum userChoose = GameEnum.Rock;
            while (input)
            {
                Console.Write("Your choose (0 Rock, 1 Paper, 2 Scissors) : ");
                var temp = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(temp))
                {
                    if (int.TryParse(temp, out var i))
                    {
                        if (i == 0 || i == 1 || i == 2)
                        {
                            userChoose = (GameEnum)i;
                            input = false;
                        }
                        else
                        {
                            ErrorInput();
                        }
                    }
                    else
                    {
                        ErrorInput();
                    }
                }
                else
                {
                    ErrorInput();
                }
            }

            WinnerDecider(computerChoose, userChoose);
        }

        public static void WinnerDecider(GameEnum computer, GameEnum user)
        {
            if (computer == GameEnum.Rock)
            {
                if (user == GameEnum.Rock)
                {
                    Console.WriteLine("Draw!!!");
                }
                else if (user == GameEnum.Paper)
                {
                    Console.WriteLine("You won!!!");
                    _gameScore.YouWin++;
                }
                else
                {
                    Console.WriteLine("You lose!!!");
                    _gameScore.ComputerWin++;
                }
            }
            else if (computer == GameEnum.Paper)
            {
                if (user == GameEnum.Paper)
                {
                    Console.WriteLine("Draw!!!");
                }
                else if (user == GameEnum.Scissors)
                {
                    Console.WriteLine("You won!!!");
                    _gameScore.YouWin++;
                }
                else
                {
                    Console.WriteLine("You lose!!!");
                    _gameScore.ComputerWin++;
                }
            }
            else if (computer == GameEnum.Scissors)
            {
                if (user == GameEnum.Scissors)
                {
                    Console.WriteLine("Draw!!!");
                }
                else if (user == GameEnum.Rock)
                {
                    Console.WriteLine("You won!!!");
                    _gameScore.YouWin++;
                }
                else
                {
                    Console.WriteLine("You lose!!!");
                    _gameScore.ComputerWin++;
                }
            }
        }

        public enum GameEnum
        {
            Rock,
            Paper,
            Scissors
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void ErrorInput()
        {
            Console.WriteLine("Error input");
        }

        public static void Exit()
        {
            Environment.Exit(exitCode: 0);
        }

        public static void PrintScore()
        {
            Console.WriteLine($"Computer {_gameScore.ComputerWin} vs You {_gameScore.YouWin}");
        }
    }
}