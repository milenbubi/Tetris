using Tetris.Logic.Game.BaseLogic.Helpers;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game
{
    public class GameController : IGameControler
    {
        private InfoPanel infoPanel;
        private WindowInitializer initializer;

        public GameController()
        {
            this.Check = new Checker();
            this.Graphic = new GameGraphic();
            this.infoPanel = new InfoPanel();
            this.initializer = new WindowInitializer();
        }

        public Checker Check { get; }

        public GameGraphic Graphic { get; }

        public void Initialize()
        {
            initializer.SetUpWindow();
            this.Update();
            initializer.ShowWelcomeMessage();
        }

        public void Update()
        {
            infoPanel.Update();
        }

        public void Finish()
        {
            FinishManager.EndOfGame();
        }
    }
}
