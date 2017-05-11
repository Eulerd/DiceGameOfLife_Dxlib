namespace DiceGameOfLife_Dxlib
{
    class Point
    {
        public Point()
        {

        }

        public Point(int size)
        {
            X = size;
            Y = size;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
