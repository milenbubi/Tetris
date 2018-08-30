namespace Tetris.Logic.Figures
{
    public class LittlePortal : Figure, IFigure
    {
        public LittlePortal(int x, int y) : base(4, x, y)
        {
            elemCoords[0] = new int[] { -1, 0, -1, -1, 0, -1, 1, -1, 1, 0 };
            elemCoords[1] = new int[] { 0, -1, 1, -1, 1, 0, 1, 1, 0, 1 };
            elemCoords[2] = new int[] { 0, 0, -1, 0, -1, -1, 1, 0, 1, -1 };
            elemCoords[3] = new int[] { -1, 0, -1, -1, 0, -1, -1, 1, 0, 1 };
        }
    }
}