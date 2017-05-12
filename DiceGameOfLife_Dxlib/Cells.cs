using System.Collections.Generic;

namespace DiceGameOfLife_Dxlib
{
    class Cells
    {
        public int Origin
        {
            get { return MaxValue / 2; }
        }
        
        public void SetAlive(Point p)
        {
            p.X += Origin;
            p.Y += Origin;

            if (AlivePoints[flip].IndexOf(p) != -1)
                return;

            alives[flip][p.X, p.Y] = true;
            AlivePoints[flip].Add(p);
        }

        public void SetDead(Point p)
        {
            p.X += Origin;
            p.Y += Origin;

            if (AlivePoints[flip].Count == 0)
                return;

            alives[flip][p.X, p.Y] = false;
            AlivePoints[flip].Remove(p);
        }

        public List<Point> GetAlivePoints()
        {
            return AlivePoints[flip];
        }

        public void Update()
        {
            AlivePoints[NextFlip].Clear();
            
            AliveInit();

            foreach (Point p in AlivePoints[flip])
            {
                for (int i = p.X - 1; i <= p.X + 1; i++)
                {
                    for (int j = p.Y - 1; j <= p.Y + 1; j++)
                    {
                        // 未確定なら
                        if (alives[NextFlip][i, j] == null)
                        {
                            alives[NextFlip][i, j] = IsAliveNext(i, j);
                            UsedPoints.Add(new Point(i, j));
                        }
                    }
                }
            }
            
            flip = 1 - flip;
        }
        
        /// <summary>
        /// そのセルが次に生きているのか
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <returns>セルの生死</returns>
        bool IsAliveNext(int x, int y)
        {
            int count = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    // 自セルはカウントしない
                    if (i == x && j == y)
                        continue;

                    if (alives[flip][i, j] == true)
                        count++;
                }
            }

            bool isAlive;
            if(alives[flip][x,y] == true)
                isAlive = (count == 2 || count == 3);
            else
                isAlive = count == 3;

            if (isAlive)
                AlivePoints[NextFlip].Add(new Point(x, y));

            return isAlive;
        }

        /// <summary>
        /// すべてのセルを初期化する
        /// </summary>
        public void Clear()
        {
            alives[flip] = new bool?[MaxValue, MaxValue];
            AlivePoints[flip].Clear();
        }

        public void Step()
        {
            Update();
        }

        void AliveInit()
        {
            foreach (Point p in UsedPoints)
                alives[NextFlip][p.X, p.Y] = null;
        }
        
        private int NextFlip
        {
            get { return 1 - flip; }
        }

        /// <summary>
        /// 各セルの生死
        /// </summary>
        static bool?[][,] alives = { new bool?[MaxValue, MaxValue], new bool?[MaxValue, MaxValue] };

        /// <summary>
        /// 生きているセルの座標リスト
        /// </summary>
        static List<Point>[] AlivePoints = { new List<Point>(), new List<Point>() };

        /// <summary>
        /// 最大値
        /// </summary>
        const int MaxValue = 10000;

        int flip = 0;

        List<Point> UsedPoints = new List<Point>();
    }
}
