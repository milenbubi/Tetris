using Tetris.Logic.Game;

namespace Tetris
{
    class Program
    {
        public static void Main(string[] args)
        {
            GameController moveController = new GameController();
            KeyController keyController = new KeyController();
            Engine engine = new Engine(moveController, keyController);

            engine.Run();
        }
    }
}