using System;
using System.Linq;
using Tetris.Logic.Figures;

namespace Tetris
{
    internal static class FigureFactory
    {
        private static Type[] figureTypes;

        static FigureFactory()
        {
            AllTypesImplementingIFigure();
        }

        /// <summary>
        /// Creates a random figure object.
        /// </summary>
        /// <returns>Next Random IFigure for Tetris game.</returns>
        internal static IFigure GetRandomFigure()
        {
            var seed = (int)DateTime.Now.Ticks;
            Random rand = new Random(seed);

            Type randomFigure = figureTypes[rand.Next(figureTypes.Length)];

            IFigure figure = (IFigure)Activator.CreateInstance(randomFigure);
            return figure;
        }

        private static void AllTypesImplementingIFigure()
        {
            Type figureType = typeof(IFigure);

            figureTypes = AppDomain.CurrentDomain.GetAssemblies()
                   .SelectMany(a => a.GetTypes())
                   .Where(t => figureType.IsAssignableFrom(t) && !t.IsAbstract)
                   .ToArray();
        }
    }
}
