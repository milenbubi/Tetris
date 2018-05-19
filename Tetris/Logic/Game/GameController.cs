using Tetris.Logic.Game.BaseLogic.Helpers;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game
{
    public class GameController
    {
        public GameController()
        {
            this.Check = new Checker();
            this.Graphic = new GameGraphic();
            this.InfoPanel = new InfoPanel();
        }

        public Checker Check { get; }

        public GameGraphic Graphic { get; }

        public InfoPanel InfoPanel { get; }

        public void Initialize()
        {
            GameInitializeManager.SetUpWindow();
            this.UpdateInfo();
            GameInitializeManager.ShowWelcomeMessage();
        }

        public void UpdateInfo()
        {
            InfoPanel.Update();
        }

        public void Finish()
        {
            FinishManager.EndOfGame();
        }
    }
}