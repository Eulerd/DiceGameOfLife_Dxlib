namespace DiceGameOfLife_Dxlib
{
    class Cells
    {
        /// <summary>
        /// x方向の最大値
        /// </summary>
        public int MaxX { get; private set; }

        /// <summary>
        /// y方向の最大値
        /// </summary>
        public int MaxY { get; private set; }

        /// <summary>
        /// 最大値
        /// </summary>
        private const int MaxValue = 1000;

        /// <summary>
        /// 各セルの生死
        /// </summary>
        public bool[,] alives;

        public Cells()
        {
            MaxX = MaxValue;
            MaxY = MaxValue;
            alives = new bool[MaxX, MaxY];

            Clear();
        }

        public Cells(int x, int y)
        {
            MaxX = x;
            MaxY = y;
            alives = new bool[MaxX, MaxY];

            Clear();
        }
        
        public void Update(int x, int y)
        {
            if (x > MaxX)
                MaxX = x + 10;
            if (y > MaxY)
                MaxY = y + 10;

            bool[,] tmp_alives = new bool[MaxX, MaxY];

            for (int i = 0; i < MaxX; i++)
                for (int j = 0; j < MaxY; j++)
                    tmp_alives[i, j] = IsAlive(i, j);

            alives = tmp_alives;
        }

        public void ChangeSell(int x, int y)
        {
            alives[x, y] = !alives[x, y];
        }

        /// <summary>
        /// そのセルが次に生きているのか
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <returns>セルの生死</returns>
        bool IsAlive(int x, int y)
        {
            int count = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                if (x == 0 || x == MaxX - 1)
                    continue;

                for (int j = y - 1; j < y + 2; j++)
                {
                    if (y == 0 || y == MaxY - 1)
                        continue;

                    if (i == x && j == y)
                        continue;

                    if (alives[i, j])
                        count++;
                }
            }
            
            if(alives[x,y])
            {
                return (count == 2 || count == 3);
            }
            else
            {
                return count == 3;
            }
        }

        /// <summary>
        /// すべてのセルを死なせる
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < MaxX; i++)
                for (int j = 0; j < MaxY; j++)
                    alives[i, j] = false;
        }
    }
}
