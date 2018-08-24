namespace Tetris.Logic.Figures
{
    public class Line : Figure, IFigure
    {
        public Line(params int[] coords) : base(2, coords)
        {
            elemCoords[0] = new int[] { 0, -1, -1, -1, 1, -1 };
            elemCoords[1] = new int[] { 0, 0, 0, -1, 0, 1 };
        }
    }
}