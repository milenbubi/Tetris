using System;
using System.Threading;
using Tetris.Logic.Game;
using Tetris.Logic.Figures;
using static Tetris.Logic.GameData;
using Tetris.Logic;

namespace Tetris
{
    public class Engine
    {
        private int speed;

        private IFigure figure;
        private KeyController keyController;
        private GameController gameController;

        public Engine(GameController gameController, KeyController keyController)
        {
            this.speed = StartSpeed;

            this.keyController = keyController;
            this.gameController = gameController;
        }

        private bool InPlay
        {
            get
            {
                return IsStatusPlay() && !gameController.Check.IsFinished(figure);
            }
        }

        public void Run()
        {
            gameController.InitializeGame();

            Play();

            HandleFurtherGameFlow();
        }

        private void Play()
        {
            while (level <= LevelsCount)
            {
                while (figureCount <= FiguresPerLevel)
                {
                    SetUpFigure();
                    gameController.UpdateInfo();
                    DrawFigure();

                    TheHeartOfGame();

                    if (!IsStatusPlay()) return;

                    figureCount++;
                    points++;
                }

                level++;
                speed -= 10;
                points += PointsPerLevel;
                figureCount = 1;
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
            Thread.Sleep(3);
            nextFigure = FigureFactory.GetRandomFigure();
        }

        private void TheHeartOfGame()
        {
            while (InPlay)
            {
                Thread.Sleep(speed);

                MoveFigure();

                while (Console.KeyAvailable)
                {
                    UsePressedKey();
                }
            }
        }

        private void MoveFigure()
        {
            gameController.Graphic.Move(figure, 0, 1);
        }

        private void UsePressedKey()
        {
            //Smoothing the left/right moving
            Thread.Sleep(12);

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
                    figureCount--;
                    points--;
                    return false;

                default: return false;
            }
        }

        private void HandleFurtherGameFlow()
        {
            if (status == Status.GameOver)
            {
                gameController.Finish();
            }

            Run();
        }
    }
}