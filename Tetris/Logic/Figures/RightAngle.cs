namespace Tetris.Logic.Figures
{
    public class RightAngle : Figure, IFigure
    {
        public RightAngle() : base(4)
        {
            elemCoords[0] = new int[] { 0, 0, -1, 0, 0, 1 };
            elemCoords[1] = new int[] { 0, 0, 0, -1, -1, 0 };
            elemCoords[2] = new int[] { 0, 0, 0, -1, 1, 0 };
            elemCoords[3] = new int[] { 0, 0, 1, 0, 0, 1 };
        }
    }
}