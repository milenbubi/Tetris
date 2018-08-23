using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tetris.Logic.Figures;

namespace Tetris
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

        internal static IFigure GetRandomFigure()
        {
            Task.Delay(20).Wait();
            int seed = (int)DateTime.Now.Ticks;
            int randomPosition = new Random(seed).Next(figureTypes.Count());

            Type randomFigure = figureTypes.ElementAt(randomPosition);

            return (IFigure)Activator.CreateInstance(randomFigure, true);
        }
    }
}