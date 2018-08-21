using System;
using Tetris.Logic.Game.BaseLogic.Essential;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game
{
    internal class GameController
    {
        internal GameController()
        {
            Graphic = new GameGraphic();
            Check = new Checker();
        }

        internal GameGraphic Graphic { get; }

        internal Checker Check { get; }

        internal void UpdateInfo() => InfoPanel.Update();

        internal void InitializeGame()
        {
            GameInitializeManager.SetUpWindow();
            GameData.ResetData();
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

        internal void Finish()
        {
            ScoreManager.UpdateScores();

            Console.Clear();
            Console.ForegroundColor = FieldData.MessageColor;

            string[] message = new string[]
            {
                new string('\n', FieldData.WindowHeight/2 - 4),
                "GAME OVER",
                Environment.NewLine,
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

        private string ReadKey()
        {
            return Console.ReadKey(true)
                          .Key
                          .ToString()
                          .ToUpper();
        }
    }
}