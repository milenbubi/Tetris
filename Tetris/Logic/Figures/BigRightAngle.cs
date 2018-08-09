namespace Tetris.Logic.Figures
{
    internal class BigRightAngle : Figure, IFigure
    {
        public BigRightAngle() : base(4)
        {
            elemCoords[0] = new int[] { -1, -1, 0, -1, 1, -1, 1, 0, 1, 1 };
            elemCoords[1] = new int[] { -1, 1, 0, 1, 1, 1, 1, 0, 1, -1 };
            elemCoords[2] = new int[] { 1, 1, 0, 1, -1, 1, -1, 0, -1, -1 };
            elemCoords[3] = new int[] { 1, -1, 0, -1, -1, -1, -1, 0, -1, 1 };

        }
    }
}
