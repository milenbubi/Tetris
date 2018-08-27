using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.BaseLogic.Providers
{
    internal static class FigureFactory
    {
        private static IEnumerable<Type> figureTypes;

        static FigureFactory()
        {
            figureTypes = AppDomain.CurrentDomain
                                   .GetAssemblies()
                                   .SelectMany(a => a.GetTypes())
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