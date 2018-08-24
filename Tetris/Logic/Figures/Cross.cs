namespace Tetris.Logic.Figures
{
    public class Cross : Figure, IFigure
    {
        public Cross(params int[] coords) : base(1, coords)
        {
            elemCoords[0] = new int[] { 0, 0, 0, -1, 0, 1, -1, 0, 1, 0 };
        }
    }
}