using System;
using System.Threading.Tasks;
using Tetris.Logic.Game.BaseLogic.Essentials;
using Tetris.Logic.Game.BaseLogic.Managers;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game
{
    internal static class GameController
    {
        private static string[] finishMessage;

        static GameController()
        {
            FieldCells = new FieldCells();
            Graphic = new GameGraphic();
            Check = new Checker();

            finishMessage = new string[]
                {
                    "GAME OVER\n",
                    "Press 'Q' to quit game",
                    "or press any key to play new game"
                };
        }

        internal static FieldCells FieldCells { get; }

        internal static GameGraphic Graphic { get; }

        internal static Checker Check { get; }

        internal static void UpdateInfo() => InfoPanel.Update();

        internal static void InitializeGame()
        {
            GameInitializeManager.SetUpWindow();
            GameData.ResetData();
            UpdateInfo();

            FieldCells.ResetCells();
            FieldCells.DrawAllRows();
            GameInitializeManager.ShowWelcomeMessage();

            if (Read.Key == "M")
            {
                Menu.Show();
            }

            GameInitializeManager.ShowWelcomeMessage(false);
        }

        internal static void SetObstacles()
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

        internal static void Finish()
        {
            ScoreManager.UpdateScores();

            Console.Clear();
            Console.ForegroundColor = FieldData.MessageColor;
            Console.CursorTop = (FieldData.WindowHeight - finishMessage.Length) / 2;

            foreach (var text in finishMessage)
            {
                Console.CursorLeft = (FieldData.WindowWidth - text.Length) / 2;
                Console.WriteLine(text);
            }

            if (Read.Key == "Q")
            {
                FinishManager.EndOfGame();
            }
        }
    }
}