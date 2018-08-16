using System;
using System.Linq;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.BaseLogic.Helpers
{
    internal static class Menu
    {
        private const string ItemKeys = "CBNQA";
        private const string Title = "MAIN MENU";

        private static string key;
        private static readonly string[] items;
        private static readonly string[] backMessage;

        private static InfoPanel infoPanel;
        private static FieldCells fieldCells;

        static Menu()
        {
            int padding = (FieldData.GameFieldWidth - Title.Length) / 2;

            items = new string[]
            {
                Environment.NewLine,
                Title.PadLeft(padding + Title.Length),
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

            infoPanel = new InfoPanel();
            fieldCells = new FieldCells();
        }

        internal static void Show()
        {
            do
            {
                ShowMenu();

                switch (ReadKey())
                {
                    case "C": Controls(); break;
                    case "B": BestScores(); break;
                    case "N": NewGame(); key = null; return;
                    case "Q": QuitGame(); break;
                    case "A": AboutMe(); break;
                }

            } while (ItemKeys.Contains(key));

            fieldCells.DrawAllRows();
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
                string.Join(Environment.NewLine, backMessage)
            };

            PrepareMenuWindow();
            Print(controls);
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
                Environment.NewLine,
                string.Join(Environment.NewLine, backMessage)
            };

            Console.Clear();
            Print(aboutMe);
        }

        private static void ShowMenu()
        {
            PrepareMenuWindow();
            Console.WriteLine(string.Join("\n", items));
        }

        private static void PrepareMenuWindow()
        {
            Console.Clear();
            infoPanel.Update();
            Console.ForegroundColor = FieldData.MessageColor;

            // !!!  After printing Info Panel, cursor is fixed on the last line and I am forced to move it up~!
            Console.SetCursorPosition(0, 0);
        }

        private static string ReadKey()
        {
            string pressedKey = Console.ReadKey(true)
                .Key
                .ToString()
                .ToUpper();

            key = pressedKey;
            return pressedKey;
        }

        private static void Print(string[] text)
        {
            Console.WriteLine(string.Join("\n", text));
            Console.ReadKey(true);
        }
    }
}