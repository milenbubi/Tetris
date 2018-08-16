namespace Tetris.Logic.Figures
{
    internal class ZLine : Figure, IFigure
    {
        internal ZLine() : base(2)
        {
            elemCoords[0] = new int[] { 0, 0, 0, -1, -1, -1, 1, 0 };
            elemCoords[1] = new int[] { 0, 0, 0, 1, 1, 0, 1, -1 };
        }
    }
}