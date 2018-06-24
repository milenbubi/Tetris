using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.BaseLogic.Helpers
{
    internal static class Menu
    {
        private const string Title = "MAIN MENU";
        private const string ItemKeys = "CBNQA";

        private static string key;
        private static string[] items;
        private static string[] backMessage;

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
                new string('\n', 3),
                "Press any key",
                "to go Back."
            };

            infoPanel = new InfoPanel();
            fieldCells = new FieldCells();
        }

        public static void Show()
        {
            do
            {
                switch (key)
                {
                    case "C": Controls(); break;
                    case "B": DisplayScores(); break;
                    case "N": NewGame(); key = null; return;
                    case "Q": QuitGame(); break;
                    case "A": AboutMe(); break;
                }

                ShowMenu();

            } while (ItemKeys.Contains(ReadKey()));

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
                new string('\n', 3),
                "   Press any key",
                "   to go Back."
            };

            PrepareMenuWindow();
            PrintItemInformation(controls);
        }

        private static void DisplayScores()
        {
            //Under Construction!! -  info about user result in case it is not present in Top 10 !

            ICollection<string> bestScores = LogFileManager.Read();

            ScoreManager.DisplayScores();

            int currentResult = GameData.points;

            int lowestBestScore = Convert.ToInt32(bestScores
                .Last()
                .Split()
                .First());

            if (currentResult < lowestBestScore)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(Environment.NewLine);
                Console.Write(new String(' ', 2));
                Console.WriteLine("Your current result: {0}", currentResult);

                Console.ForegroundColor = FieldData.MessageColor;
            }

            PrintItemInformation(backMessage);
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
            string title = "About project author";
            int padding = (FieldData.WindowWidth - title.Length) / 2 + title.Length;

            string[] aboutMe =
            {
                Environment.NewLine,
                title.PadLeft(padding),
                Environment.NewLine,
                " Hi! I am Phillip Coitchev and I am",
                "entry level .NET developer.\n",
                " An unknown user has inspired me",
                "to create the game. I have spent many",
                "days to fix, remove, add or change",
                "something in this code, but it",
                "gets better and better.\n",
                " If you have related questions,",
                "comments or advices, feel free",
                "to contact me - fcc@abv.bg",
                string.Join(Environment.NewLine, backMessage)
            };

            Console.Clear();
            PrintItemInformation(aboutMe);
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

        private static void PrintItemInformation(string[] backMessage)
        {
            Console.WriteLine(string.Join("\n", backMessage));
            Console.ReadKey(true);
        }
    }
}