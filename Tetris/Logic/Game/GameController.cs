using System;
using Tetris.Logic.Game.BaseLogic.Helpers;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game
{
    public class GameController
    {
        internal GameController()
        {
            this.Check = new Checker();
            this.Graphic = new GameGraphic();
            this.InfoPanel = new InfoPanel();
            this.FieldCells = new FieldCells();
        }

        internal Checker Check { get; }

        internal GameGraphic Graphic { get; }

        internal InfoPanel InfoPanel { get; }

        internal FieldCells FieldCells { get; }

        internal void InitializeGame()
        {
            Console.Clear();
            GameData.ResetData();
            GameInitializeManager.SetUpWindow();
            UpdateInfo();

            FieldCells.ResetCells();
            FieldCells.DrawAllRows();
            GameInitializeManager.ShowWelcomeMessage();

            if (ReadKey() == "M")
            {
                Menu.Show();
            }

            GameInitializeManager.ShowWelcomeMessage(false);
        }

        internal void UpdateInfo()
        {
            InfoPanel.Update();
        }

        internal void Finish()
        {
            Console.Clear();
            Console.ForegroundColor = FieldData.MessageColor;

            string[] message = new string[]
            {
                new string('\n', FieldData.WindowHeight/2-3),
                "GAME OVER",
                new string('\n', 2),
                "Press 'Q' to quit game",
                "or press any key to play new game"
            };

            foreach (var text in message)
            {
                int padding = (FieldData.WindowWidth - text.Length) / 2;

                Console.WriteLine("{0}{1}", new string(' ', padding), text);
            }

            if (ReadKey() == "Q")
            {
                FinishManager.EndOfGame();
            }
        }

        private static string ReadKey()
        {
            string key = Console.ReadKey(true).Key.ToString().ToUpper();
            return key;
        }
    }
}