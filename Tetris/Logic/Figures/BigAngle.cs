namespace Tetris.Logic.Figures
{
    public class BigAngle : Figure, IFigure
    {
        public BigAngle(int x, int y) : base(4, x, y)
        {
            elemCoords[0] = new[] { -1, -1, 0, -1, 1, -1, 1, 0, 1, 1 };
            elemCoords[1] = new[] { -1, 1, 0, 1, 1, 1, 1, 0, 1, -1 };
            elemCoords[2] = new[] { 1, 1, 0, 1, -1, 1, -1, 0, -1, -1 };
            elemCoords[3] = new[] { 1, -1, 0, -1, -1, -1, -1, 0, -1, 1 };
        }
    }
}