using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Logic;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris
{
    class Program
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}
