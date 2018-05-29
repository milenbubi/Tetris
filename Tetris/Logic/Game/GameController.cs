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

        //Under Construction
        internal Status Status { get; private set; }

        internal void InitializeGame()
        {
            GameData.status = Status.Play;
            GameInitializeManager.SetUpWindow();
            UpdateInfo();

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

        //Under Construction
        internal bool? MayPlay()
        {
            switch (Status)
            {
                case Status.Play:
                    break;
                case Status.Skip:
                    break;
                case Status.NewGame:
                    break;
                case Status.GameOver:
                    break;
                default:
                    break;
            }

            return null;
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