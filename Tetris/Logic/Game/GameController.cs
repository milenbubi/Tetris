﻿using System;
using System.Threading.Tasks;
using Tetris.Logic.Game.BaseLogic.Managers;
using Tetris.Logic.Game.BaseLogic.Providers;
using Tetris.Logic.Game.BaseLogic.Essentials;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game
{
    internal static class GameController
    {
        private static string[] finishMessage;

        static GameController()
        {
            finishMessage = new string[]
                {
                    "GAME OVER\n",
                    "Press 'Q' to quit game",
                    "or press any key to play new game"
                };
        }

        internal static Checker Check => Container.Checker;

        internal static GameGraphic Graphic => Container.GameGraphic;

        internal static bool KeyIsPressed => Keyboard.KeyIsPressed;

        internal static string PressedKey => Keyboard.ReadKey();

        internal static void UpdateInfo() => InfoPanel.Update();

        internal static void Delay(int miliSeconds) => Task.Delay(miliSeconds).Wait();

        internal static void InitializeGame()
        {
            GameInitializeManager.SetUpWindow();
            GameData.ResetData();
            UpdateInfo();

            Field.ResetCells();
            Field.DrawAllRows();
            GameInitializeManager.ShowWelcomeMessage();

            if (PressedKey == "M")
            {
                Menu.Show();
            }

            GameInitializeManager.ShowWelcomeMessage(false);
        }

        internal static void SetObstacles()
        {
            Field.ResetCells();
            Delay(500);

            for (int i = 1; i <= GameData.level / 2; i++)
            {
                FieldCellsManager.AddNewObstacle();
                Field.DrawAllRows();
                Delay(500);
            }
        }

        internal static void Finish()
        {
            ScoreManager.UpdateScores();
            Console.Clear();
            Console.ForegroundColor = FieldData.MessageColor;

            if (GameData.status == Status.NewGame)
            {
                string newGameMessage = "New game after {0} seconds";

                Console.CursorTop = FieldData.WindowHeight / 2 - 1;

                for (int i = 4; i >= 0; i--)
                {
                    Console.CursorLeft = (FieldData.WindowWidth - newGameMessage.Length) / 2;
                    Console.Write(String.Format(newGameMessage, i));
                    Delay(1000);
                }
            }
            else
            {
                Console.CursorTop = (FieldData.WindowHeight - finishMessage.Length) / 2;

                foreach (var text in finishMessage)
                {
                    Console.CursorLeft = (FieldData.WindowWidth - text.Length) / 2;
                    Console.WriteLine(text);
                }

                if (PressedKey == "Q")
                {
                    FinishManager.EndOfGame();
                }
            }
        }
    }
}