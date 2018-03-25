using System;
using Tetris.Logic.Game;
using Tetris.Logic;
using System.IO;
using Tetris.Logic.Game.Keys;
using Tetris.Logic.Figures;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {

            IGameControler moveController = new GameController();
            IKeyController keyController = new KeyController();
            Engine engine = new Engine(moveController, keyController);

             engine.Run();

            //     F finish = new F();
            //   finish.KeyAction(new SLine());


        }
    }
}

