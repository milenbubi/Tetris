namespace Tetris.Logic.Figures
{
    internal class Cube : Figure, IFigure
    {
        internal Cube() : base(1)
        {
            elemCoords[0] = new int[] { 0, 0, -1, 0, -1, -1, 0, -1 };
        }
    }
}