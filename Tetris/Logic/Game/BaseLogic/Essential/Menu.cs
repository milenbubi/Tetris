using System;
using System.Linq;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.BaseLogic.Essential
{
    internal static class Menu
    {
        private const string Title = "MAIN MENU";

        private static string[] items;
        private static string[] backMessage;

        static Menu()
        {
            int padding = (FieldData.GameFieldWidth + Title.Length) / 2;

            items = new string[]
            {
                Environment.NewLine,
                Title.PadLeft(padding),
                Environment.NewLine,
                "'C' - Controls",
                "'B' - Best Scores\n",
                "'N' - New Game",
                "'Q' - Quit Game\n",
                "'A' - About Me",
                new string('\n',4),
                " Select from",
                " options above",
                " or press",
                " any key",
                " to continue",
                " playing."
            };

            backMessage = new string[]
            {
                Environment.NewLine,
                "Press any key",
                "to go Back."
            };
        }

        internal static void Show()
        {
            ShowMenu();

            switch (ReadKey())
            {
                case "C": Controls(); break;
                case "B": BestScores(); break;
                case "N": NewGame(); return;
                case "Q": QuitGame(); break;
                case "A": AboutMe(); break;
                default: ShowInfoPanel(); FieldCells.DrawAllRows(); return;
            }

            Show();
        }

        private static void ShowMenu()
        {
            //Repeating
            PrepareMenuWindow();
            Console.WriteLine(string.Join("\n", items));
        }

        private static void Controls()
        {
            string[] controls =
            {
                Environment.NewLine,
                "   Game Controls:",
                new string('\n',2),
                " ◄ - Left\n",
                " ► - Right\n",
                " ▼ - To the bottom",
                string.Empty,
                " SPACE - Rotation",
                string.Empty,
                " S - Next figure",
                string.Empty,
                " M - Menu",
                Environment.NewLine
            };

            //Repeating
            PrepareMenuWindow();
            Print(controls.Concat(backMessage).ToArray());
        }

        private static void BestScores()
        {
            ScoreManager.DisplayScores();

            Console.ForegroundColor = ConsoleColor.Red;

            int currentScore = GameData.points;
            Console.WriteLine("  Current score: {0} pts.\n", currentScore);

            try
            {
                int lowestBestScore = Convert.ToInt32(LogFileManager
                    .Read()
                    .Last()
                    .Split()
                    .First());

                if (currentScore >= lowestBestScore)
                {
                    Console.WriteLine("  You already reached");
                    Console.WriteLine("  the top 10 results.\n");
                    Console.WriteLine("  Just finish the game!");
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("  Score table is empty!\n");
            }

            Console.ForegroundColor = FieldData.MessageColor;

            Print(backMessage);
        }

        private static void NewGame()
        {
            GameData.status = Status.NewGame;
        }

        private static void QuitGame()
        {
            FinishManager.EndOfGame();
        }

        private static void AboutMe()
        {
            string title = "About Project Author ";
            int padding = (FieldData.WindowWidth - title.Length) / 2 + title.Length;

            string[] aboutMe =
            {
                Environment.NewLine,
                title.PadLeft(padding),
                Environment.NewLine,
                " Hi! I am Phillip Coitchev and I am",
                "entry level .NET developer.\n",
                " An unknown user has inspired me",
                "to make this game. I have spent many",
                "days to fix, remove, add or change",
                "something in this code, but it",
                "gets better and better.\n",
                " If you have related questions,",
                "comments or advices, feel free",
                "to contact me - fcc@abv.bg",
                Environment.NewLine
            };

            Console.Clear();
            Print(aboutMe.Concat(backMessage).ToArray());
        }

        private static void PrepareMenuWindow()
        {
            ShowInfoPanel();
            Console.ForegroundColor = FieldData.MessageColor;

            // !!!  After printing Info Panel, cursor is fixed on the last line and I am forced to move it up~!
            Console.SetCursorPosition(0, 0);
        }

        private static void ShowInfoPanel()
        {
            Console.Clear();
            InfoPanel.Update();
        }

        private static string ReadKey()
        {
            return Console.ReadKey(true)
                          .Key
                          .ToString()
                          .ToUpper();
        }

        private static void Print(string[] text)
        {
            Console.WriteLine(string.Join("\n", text));
            Console.ReadKey(true);
        }
    }
}