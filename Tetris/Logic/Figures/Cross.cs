namespace Tetris.Logic.Figures
{
    public class Cross : Figure, IFigure
    {
        public Cross(int x, int y) : base(1, x, y)
        {
            elemCoords[0] = new int[] { 0, 0, 0, -1, 0, 1, -1, 0, 1, 0 };
        }
    }
}