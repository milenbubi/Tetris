using System;
using System.Threading.Tasks;
using Tetris.Logic.Game.BaseLogic.Essentials;
using Tetris.Logic.Game.BaseLogic.Managers;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game
{
    internal class GameController
    {
        internal GameController()
        {
            FieldCells = new FieldCells();
            Graphic = new GameGraphic();
            Check = new Checker();
        }

        internal FieldCells FieldCells { get; }

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

        internal void SetObstacles()
        {
            FieldCells.ResetCells();
            Task.Delay(500).Wait();

            for (int i = 1; i < GameData.level; i++)
            {
                FieldCellsManager.AddNewObstacle(FieldCells);
                FieldCells.DrawAllRows();
                Task.Delay(500).Wait();
            }
        }

        internal void Finish()
        {
            ScoreManager.UpdateScores();

            Console.Clear();
            Console.ForegroundColor = FieldData.MessageColor;

            string[] message = new string[]
            {
                "GAME OVER\n",
                "Press 'Q' to quit game",
                "or press any key to play new game"
            };

            Console.CursorTop = (FieldData.WindowHeight - message.Length) / 2;

            foreach (var text in message)
            {
                Console.CursorLeft = (FieldData.WindowWidth - text.Length) / 2;
                Console.WriteLine(text);
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