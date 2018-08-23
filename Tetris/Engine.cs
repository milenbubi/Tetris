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
        private int speed;

        private IFigure figure;
        private KeyController keyController;
        private GameController gameController;

        internal Engine(GameController gameController, KeyController keyController)
        {
            speed = StartSpeed;

            this.keyController = keyController;
            this.gameController = gameController;
        }

        private bool IsInPlay
        {
            get
            {
                return IsStatusPlay() && !gameController.Check.IsFinished(figure);
            }
        }

        internal void Run()
        {
            gameController.InitializeGame();

            Play();

            gameController.Finish();

            Run();
        }

        private void Play()
        {
            while (level <= LevelsCount)
            {
                gameController.SetObstacles();

                while (figureCount <= FiguresPerLevel)
                {
                    SetUpFigure();
                    gameController.UpdateInfo();
                    DrawFigure();

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

        private void DrawFigure()
        {
            if (gameController.Check.IsReachedBorder(figure))
            {
                status = Status.GameOver;
                return;
            }

            gameController.Graphic.Draw(figure);
        }

        private void SetUpFigure()
        {
            figure = nextFigure;
            nextFigure = FigureFactory.GetRandomFigure();
        }

        private void TheHeartOfGame()
        {
            while (IsInPlay)
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
            gameController.Graphic.Move(figure, 0, 1);
        }

        private void UsePressedKey()
        {
            //Smoothing the left/right moving
            Task.Delay(12).Wait();
            string keyClassName = Console.ReadKey(true).Key.ToString();

            keyController.Action(figure, keyClassName);
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