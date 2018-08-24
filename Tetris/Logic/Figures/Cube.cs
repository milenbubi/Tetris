namespace Tetris.Logic.Figures
{
    public class Cube : Figure, IFigure
    {
        public Cube(params int[] coords) : base(1, coords)
        {
            elemCoords[0] = new int[] { 0, 0, -1, 0, -1, -1, 0, -1 };
        }
    }
}