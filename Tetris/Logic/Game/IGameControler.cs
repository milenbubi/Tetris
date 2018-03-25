using Tetris.Logic.Game.BaseLogic.Helpers;

namespace Tetris.Logic.Game
{
    public interface IGameControler
    {
        Checker Check { get; }
        GameGraphic Graphic { get; }
        void Initialize();
        void Update();
        void Finish();
    }
}
