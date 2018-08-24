namespace Tetris.Logic.Figures
{
    public class ZLine : Figure, IFigure
    {
        public ZLine(params int[] coords) : base(2, coords)
        {
            elemCoords[0] = new int[] { 0, 0, 0, -1, -1, -1, 1, 0 };
            elemCoords[1] = new int[] { 0, 0, 0, 1, 1, 0, 1, -1 };
        }
    }
}