namespace Tetris.Logic.Figures
{
    class LittlePortal : Figure, IFigure
    {
        internal LittlePortal() : base(4)
        {
            elemCoords[0] = new int[] { -1, 0, -1, -1, 0, -1, 1, -1, 1, 0 };
            elemCoords[1] = new int[] { 0, -1, 1, -1, 1, 0, 1, 1, 0, 1 };
            elemCoords[2] = new int[] { 0, 0, -1, 0, -1, -1, 1, 0, 1, -1 };
            elemCoords[3] = new int[] { -1, 0, -1, -1, 0, -1, -1, 1, 0, 1 };
        }
    }
}