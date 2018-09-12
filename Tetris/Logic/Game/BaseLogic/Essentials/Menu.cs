﻿using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Logic.Game.BaseLogic.Managers;
using Tetris.Logic.Game.BaseLogic.Providers;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game.BaseLogic.Essentials
{
    internal static class Menu
    {
        private const string Title = "MAIN MENU";

        private static IEnumerable<string> items;
        private static IEnumerable<string> backMessage;

        static Menu()
        {
            items = new[]
            {
                Environment.NewLine,
                Title.PadLeft((FieldData.GameFieldWidth + Title.Length) / 2),
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

            backMessage = new[]
            {
                Environment.NewLine,
                "Press any key",
                "to go Back."
            };
        }

        internal static void Show()
        {
            DisplayItems();

            switch (Keyboard.ReadKey)
            {
                case "C": Controls(); break;
                case "B": BestScores(); break;
                case "N": NewGame(); return;
                case "Q": QuitGame(); break;
                case "A": AboutMe(); break;
                default: ShowInfoPanel(); Field.DrawAllRows(); return;
            }

            Show();
        }

        private static void DisplayItems()
        {
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
            Print(controls.Concat(backMessage));
        }

        private static void BestScores()
        {
            ScoreManager.DisplayScores();
            Console.ForegroundColor = ConsoleColor.Red;

            int currentScore = GameData.points;
            Console.WriteLine("  Current score: {0} pts.\n", currentScore);

            IEnumerable<string> scoreTable = LogFileManager.Read();

            try
            {
                int lowestBestScore = int.Parse(scoreTable
                    .Last()
                    .Split()
                    .First());

                if (currentScore >= lowestBestScore || scoreTable.Count() < 10)
                {
                    Console.WriteLine("  You already reached");
                    Console.WriteLine("  the top 10 results.\n");
                    Console.WriteLine("  Just finish the game!");
                }
            }
            catch (FormatException)
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
            Print(aboutMe.Concat(backMessage));
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

        private static void Print(IEnumerable<string> text)
        {
            Console.WriteLine(string.Join("\n", text));
            Keyboard.PressAnyKey();
        }
    }
}