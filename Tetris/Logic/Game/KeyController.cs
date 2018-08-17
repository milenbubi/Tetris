using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.Keys;

namespace Tetris.Logic.Game
{
    internal class KeyController
    {
        private IEnumerable<IKey> keyClasses;

        internal KeyController()
        {
            keyClasses = AppDomain.CurrentDomain
                                  .GetAssemblies()
                                  .SelectMany(a => a.GetTypes())
                                  .Where(t => typeof(IKey).IsAssignableFrom(t) && !t.IsAbstract)
                                  .Select(t => (IKey)Activator.CreateInstance(t));
        }

        internal void Action(IFigure figure, string keyClassName)
        {
            IKey keyClass = keyClasses.FirstOrDefault(c => c.GetType().Name == keyClassName);

            if (keyClass != null)
            {
                keyClass.Action(figure);
            }
        }
    }
}