namespace Tetris.Logic.Figures
{
    public class LittleAngle : Figure, IFigure
    {
        public LittleAngle(int x, int y) : base(4, x, y)
        {
            elemCoords[0] = new[] { 0, 0, 0, -1, -1, 0 };
            elemCoords[1] = new[] { 0, 0, 1, 0, 0, -1 };
            elemCoords[2] = new[] { 0, 0, 0, 1, 1, 0 };
            elemCoords[3] = new[] { 0, 0, -1, 0, 0, 1 };
        }
    }
}