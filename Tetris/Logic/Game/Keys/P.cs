﻿using System;
using System.Timers;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Providers;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game.Keys
{
    internal class P : PressedKey, IKey
    {
        private static int index;
        private static Timer timer;
        private static string[] pauseMessage;

        static P()
        {
            timer = new Timer(1000);
            timer.Elapsed += BlinkPauseMessage;

            pauseMessage = new[]
            {
                "             ",
                " GAME PAUSED ",
                "             "
            };
        }

        public override void Action(IFigure figure)
        {
            index = 0;
            timer.Start();

            Keyboard.PressAnyKey();
            timer.Stop();
            Field.DrawAllRows();
        }

        private static void BlinkPauseMessage(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = index++ % 2 == 0 ?
                FieldData.MessageColor : FieldData.BackgroundColor;

            Console.CursorTop = (FieldData.WindowHeight - pauseMessage.Length) / 2;

            foreach (var text in pauseMessage)
            {
                Console.CursorLeft = (FieldData.GameFieldWidth - text.Length) / 2;
                Console.WriteLine(text);
            }
        }
    }
}