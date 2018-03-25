namespace Tetris.Logic.Figures
{
    public class Cube : Figure, IFigure
    {
        public Cube() : base(1)
        {
            elemCoords[0] = new int[] { 0, 0, -1, 0, -1, 1, 0, 1 };
        }
    }
}