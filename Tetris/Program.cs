using Tetris.Logic.Game;

namespace Tetris
{
    class Program
    {
        public static void Main(string[] args)
        {
            GameController gameController = new GameController();
            KeyController keyController = new KeyController();
            Engine engine = new Engine(gameController, keyController);

            engine.Run();
        }
    }
}