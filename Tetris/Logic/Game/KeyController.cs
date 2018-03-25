using System;
using System.Linq;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.Keys;

namespace Tetris.Logic.Game
{
    public class KeyController : IKeyController
    {
        private IKey[] keyClasses;
        private Type[] keyClassesTypes;

        public KeyController()
        {
            AllTypesImplementingIKey();
            RetrieveAllClassesImplementingIKey();
        }

        public void Action(IFigure figure, string keyClassName)
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

            this.keyClassesTypes = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(k => keyType.IsAssignableFrom(k) && !k.IsAbstract)
                            .ToArray();
        }

        private void RetrieveAllClassesImplementingIKey()
        {
            int countOfKeyClasses = this.keyClassesTypes.Length;
            this.keyClasses = new IKey[countOfKeyClasses];

            for (int i = 0; i < countOfKeyClasses; i++)
            {
                IKey keyClass = (IKey)Activator.CreateInstance(keyClassesTypes[i]);
                keyClasses[i] = keyClass;
            }
        }
    }
}