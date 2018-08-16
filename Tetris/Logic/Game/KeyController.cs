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
        private IEnumerable<Type> keyClassesTypes;

        internal KeyController()
        {
            AllTypesImplementingIKey();
            RetrieveAllClassesImplementingIKey();
        }

        internal void Action(IFigure figure, string keyClassName)
        {
            IKey keyClass = keyClasses
                .Where(c => c.GetType().Name == keyClassName)
                .FirstOrDefault();

            if (keyClass != null)
            {
                keyClass.Action(figure);
            }
        }

        private void AllTypesImplementingIKey()
        {
            Type keyType = typeof(IKey);

            keyClassesTypes = AppDomain.CurrentDomain
                                       .GetAssemblies()
                                       .SelectMany(a => a.GetTypes())
                                       .Where(t => keyType.IsAssignableFrom(t) && !t.IsAbstract);
        }

        private void RetrieveAllClassesImplementingIKey()
        {
            keyClasses = keyClassesTypes
                .Select(t => (IKey)Activator.CreateInstance(t));
        }
    }
}