using Tetris.Logic;
using Tetris.Logic.Game;
using Tetris.Logic.Figures;
using static Tetris.Logic.GameData;

namespace Tetris
{
    internal class Engine
    {
        private IFigure figure;

        private bool InPlay => PlayStatus() && !GameController.Check.IsFinished(figure);

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

                    if (!PlayStatus()) return;

                    figureCount++;
                    points++;
                    speed--;
                }

                level++;
                figureCount = 1;
                points += PointsPerLevel;
            }

            status = Status.Win;
        }

        private void FigureFirstDraw()
        {
            if (GameController.Check.IsReachedBorder(figure, 0, 0))
            {
                status = Status.GameOver;
            }
            else if (status.Equals(Status.Play))
            {
                GameController.Graphic.Draw(figure);
                DelayNextFigure();
            }
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
            }
        }

        private void DelayNextFigure()
        {
            speedDelay.Interval = speed;
            speedDelay.Enabled = true;

            while (speedDelay.Enabled)
            {
                while (GameController.KeyIsPressed)
                {
                    KeyController.Action(figure, GameController.PressedKey);
                }
            }
        }

        private void MoveFigure()
        {
            GameController.Graphic.Move(figure, 0, 1);
            DelayNextFigure();
        }

        private bool PlayStatus()
        {
            switch (status)
            {
                case Status.Skip: status = Status.Play; return false;
                case Status.Play: return true;
                default: return false;
            }
        }
    }
}