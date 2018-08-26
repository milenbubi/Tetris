using System;
using Tetris.Logic.Game;
using Tetris.Logic.Figures;
using static Tetris.Logic.GameData;
using Tetris.Logic;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Engine
    {
        private IFigure figure;

        private bool InPlay
        {
            get
            {
                return IsStatusPlay() && !GameController.Check.IsFinished(figure);
            }
        }

        internal void Run()
        {
            GameController.InitializeGame();

            Play();

            GameController.Finish();

            Run();
        }

        private void Play()
        {
            while (level <= LevelsCount)
            {
                GameController.SetObstacles();

                while (figureCount <= FiguresPerLevel)
                {
                    SetFigure();
                    GameController.UpdateInfo();
                    FigureFirstDraw();

                    TheHeartOfGame();

                    if (!IsStatusPlay()) return;

                    figureCount++;
                    points++;
                    speed--;
                }

                level++;
                figureCount = 1;
                points += PointsPerLevel;
            }
        }

        private void FigureFirstDraw()
        {
            if (GameController.Check.IsReachedBorder(figure))
            {
                status = Status.GameOver;
                return;
            }

            GameController.Graphic.Draw(figure);
        }

        private void SetFigure()
        {
            figure = nextFigure;
            nextFigure = NewFigure();
        }

        private void TheHeartOfGame()
        {
            while (InPlay)
            {
                MoveFigure();

                while (Console.KeyAvailable)
                {
                    UsePressedKey();
                }
            }
        }

        private void MoveFigure()
        {
            Task.Delay(speed).Wait();
            GameController.Graphic.Move(figure, 0, 1);
        }

        private void UsePressedKey()
        {
            //Smoothing the left/right moving
            Task.Delay(12).Wait();
            string key = Console.ReadKey(true).Key.ToString();

            KeyController.Action(figure, key);
        }

        private bool IsStatusPlay()
        {
            switch (status)
            {
                case Status.Play: return true;

                case Status.Skip:
                    status = Status.Play;
                    return false;

                default: return false;
            }
        }
    }
}