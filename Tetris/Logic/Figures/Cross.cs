namespace Tetris.Logic.Figures
{
  internal  class Cross : Figure, IFigure
    {
        internal Cross() : base(1)
        {
            elemCoords[0] = new int[] { 0, 0, 0, -1, 0, 1, -1, 0, 1, 0 };
        }
    }
}