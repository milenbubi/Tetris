using System;
using System.Threading;
using Tetris.Logic.Game;
using Tetris.Logic.Figures;
using static Tetris.Logic.GameData;

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

        private bool IsFinished
        {
            get
            {
                return this.gameController.Check.IsFinished(figure);
            }
        }

        public void Run()
        {
            this.gameController.Initialize();

            for (; level <= MaxLevelCount; level++)
            {
                for (; figureCount <= FigureCountPerLevel; figureCount++)
                {
                    SetUpFigure();
                    gameController.UpdateInfo();

                    TheHeartOfGame();
                    points++;
                }

                points += PointsPerLevel;
                figureCount = 1;
                speed -= 10;
            }
            gameController.Finish();
        }

        private void SetUpFigure()
        {
            figure = nextFigure;
            Thread.Sleep(3);
            nextFigure = FigureFactory.GetRandomFigure();
        }

        private void TheHeartOfGame()
        {
            while (!IsFinished)
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
            this.gameController.Graphic.Move(figure, 0, 1);
        }

        private void UsePressedKey()
        {
            //Smoothing the left/right moving
            Thread.Sleep(12);

            string keyClassName = Console.ReadKey(true).Key.ToString();

            this.keyController.Action(figure, keyClassName);
        }
    }
}