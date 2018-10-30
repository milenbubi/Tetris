using System;
using System.Threading.Tasks;
using Tetris.Logic.Game.BaseLogic.Managers;
using Tetris.Logic.Game.BaseLogic.Providers;
using Tetris.Logic.Game.BaseLogic.Essentials;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game
{
    internal static class GameController
    {
        private static string newGameMessage;
        private static string[] gameOverMessage;
        private static string[] winMessage;

        static GameController()
        {
            newGameMessage = "New game after {0} seconds";

            gameOverMessage = new string[]
            {
                "GAME OVER\n",
                "Press 'Q' to quit game",
                "or press any key to play new game"
            };

            winMessage = new string[]
            {
                "  CONGRATULATION !!!\n",

                "YOU WIN THE GAME !!!",
                Environment.NewLine,
                Environment.NewLine,
                "  press any key to play new game\n",
                "or 'Q' to quit game"
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
                Menu.Show();

            GameInitializeManager.ShowWelcomeMessage(false);
        }

        internal static void SetObstacles()
        {
            Field.ResetCells();
            Delay(500);

            for (int i = 1; i <= GameData.level / 2; i++)
            {
                FieldCellsManager.AddObstacle();
                Field.DrawAllRows();
                Delay(500);
            }
        }

        internal static void Finish()
        {
            ScoreManager.UpdateScores();

            switch (GameData.status)
            {
                case Status.NewGame:
                    PrintNewGameMessage();
                    return;

                case Status.GameOver:
                    Delay(1000);
                    MessageManager.PrintOnWholeWindow(gameOverMessage);
                    break;

                case Status.Win:
                    MessageManager.PrintOnWholeWindow(winMessage);
                    break;
            }

            if (PressedKey == "Q")
                FinishManager.EndOfGame();
        }

        private static void PrintNewGameMessage()
        {
            for (int i = 3; i >= 0; i--)
            {
                MessageManager.PrintOnWholeWindow(string.Format(newGameMessage, i));
                Delay(1000);
            }
        }
    }
}