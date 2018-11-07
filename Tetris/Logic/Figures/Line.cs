namespace Tetris.Logic.Figures
{
    public class Line : Figure, IFigure
    {
        public Line(int x, int y) : base(2, x, y)
        {
            elemCoords[0] = new[] { 0, -1, -1, -1, 1, -1 };
            elemCoords[1] = new[] { 0, 0, 0, -1, 0, 1 };
        }
    }
}