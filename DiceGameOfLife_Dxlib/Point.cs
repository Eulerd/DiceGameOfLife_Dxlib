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

        public override string ToString()
        {
            return X + " , " + Y;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.X == p2.X && p1.Y == p2.Y);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return (p1.X != p2.X && p1.Y != p2.Y);
        }

        public override bool Equals(object obj)
        {
            return this == (Point)(obj);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }
    }
}
