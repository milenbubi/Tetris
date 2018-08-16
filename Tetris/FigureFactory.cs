using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Logic.Figures;

namespace Tetris
{
    internal static class FigureFactory
    {
        private static IEnumerable<Type> figureTypes;

        static FigureFactory()
        {
            AllTypesImplementingIFigure();
        }

        internal static IFigure GetRandomFigure()
        {
            var seed = (int)DateTime.Now.Ticks;
            Random rand = new Random(seed);

            Type randomFigure = figureTypes.ElementAt(rand.Next(figureTypes.Count()));

            return (IFigure)Activator.CreateInstance(randomFigure, true);
        }

        private static void AllTypesImplementingIFigure()
        {
            figureTypes = AppDomain.CurrentDomain
                                   .GetAssemblies()
                                   .SelectMany(a => a.GetTypes())
                                   .Where(t => typeof(IFigure).IsAssignableFrom(t) && !t.IsAbstract)
                                   .ToArray();
        }
    }
}