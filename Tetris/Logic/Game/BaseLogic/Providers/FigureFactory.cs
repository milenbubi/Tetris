using System;
using System.Linq;
using System.Reflection;
using Tetris.Logic.Figures;
using System.Collections.Generic;

namespace Tetris.Logic.Game.BaseLogic.Providers
{
    internal static class FigureFactory
    {
        private static IEnumerable<Type> figureTypes;

        static FigureFactory()
        {
            figureTypes = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                  .Where(t => typeof(IFigure).IsAssignableFrom(t) && !t.IsAbstract);
        }

        internal static IFigure GetRandomFigure(int x, int y)
        {
            int randomPosition = RandomNumber.ZeroBasedRange(figureTypes.Count());

            Type randomFigure = figureTypes.ElementAt(randomPosition);

            return (IFigure)Activator.CreateInstance(randomFigure, x, y);
        }
    }
}