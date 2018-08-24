namespace Tetris.Logic.Figures
{
    public class LittleAngle : Figure, IFigure
    {
        public LittleAngle(params int[] coords) : base(4, coords)
        {
            elemCoords[0] = new int[] { 0, 0, 0, -1, -1, 0 };
            elemCoords[1] = new int[] { 0, 0, 1, 0, 0, -1 };
            elemCoords[2] = new int[] { 0, 0, 0, 1, 1, 0 };
            elemCoords[3] = new int[] { 0, 0, -1, 0, 0, 1 };
        }
    }
}