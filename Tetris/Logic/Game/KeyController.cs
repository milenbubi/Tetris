using System;
using System.Linq;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.Keys;

namespace Tetris.Logic.Game
{
    internal class KeyController
    {
        private IKey[] keyClasses;
        private Type[] keyClassesTypes;

        internal KeyController()
        {
            AllTypesImplementingIKey();
            RetrieveAllClassesImplementingIKey();
        }

        internal void Action(IFigure figure, string keyClassName)
        {
            foreach (IKey keyClass in keyClasses)
            {
                if (keyClass.GetType().Name == keyClassName)
                {
                    keyClass.Action(figure);
                    return;
                }
            }
        }

        private void AllTypesImplementingIKey()
        {
            Type keyType = typeof(IKey);

            this.keyClassesTypes = AppDomain.CurrentDomain
                                            .GetAssemblies()
                                            .SelectMany(a => a.GetTypes())
                                            .Where(t => keyType.IsAssignableFrom(t) && !t.IsAbstract)
                                            .ToArray();
        }

        private void RetrieveAllClassesImplementingIKey()
        {
            int countOfKeyClasses = this.keyClassesTypes.Length;
            keyClasses = new IKey[countOfKeyClasses];

            for (int i = 0; i < countOfKeyClasses; i++)
            {
                IKey keyClass = (IKey)Activator.CreateInstance(keyClassesTypes[i]);
                keyClasses[i] = keyClass;
            }
        }
    }
}