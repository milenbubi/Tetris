namespace Tetris.Logic.Figures
{
    public class Cube : Figure, IFigure
    {
        public Cube(int x, int y) : base(1, x, y)
        {
            elemCoords[0] = new[] { 0, 0, -1, 0, -1, -1, 0, -1 };
        }
    }
}