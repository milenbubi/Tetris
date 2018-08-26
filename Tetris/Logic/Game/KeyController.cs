using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.Keys;

namespace Tetris.Logic.Game
{
    internal static class KeyController
    {
        private static IDictionary<string, IKey> keyClasses;

        static KeyController()
        {
            keyClasses = AppDomain.CurrentDomain
                                  .GetAssemblies()
                                  .SelectMany(a => a.GetTypes())
                                  .Where(t => typeof(IKey).IsAssignableFrom(t) && !t.IsAbstract)
                                  .ToDictionary(t => t.Name, t => (IKey)Activator.CreateInstance(t));
        }

        internal static void Action(IFigure figure, string key)
        {
            if (keyClasses.ContainsKey(key))
            {
                keyClasses[key].Action(figure);
            }
        }
    }
}