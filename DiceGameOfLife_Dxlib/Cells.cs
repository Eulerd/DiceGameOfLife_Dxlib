using System.Collections.Generic;

namespace DiceGameOfLife_Dxlib
{
    class Cells
    {
        public void SetAlive(Point p)
        {
            if (AlivePoints[flip].IndexOf(p) != -1)
                return;

            if (alives[flip].ContainsKey(p))
                alives[flip][p] = true; 
            else
                alives[flip].Add(p, true);

            AlivePoints[flip].Add(p);
        }

        public void SetDead(Point p)
        {
            if (AlivePoints[flip].Count == 0)
                return;

            if (alives[flip].ContainsKey(p))
                alives[flip][p] = false;
            else
                alives[flip].Add(p, false);
            AlivePoints[flip].Remove(p);
        }

        public List<Point> GetAlivePoints()
        {
            return AlivePoints[flip];
        }

        public void Update()
        {
            AlivePoints[NextFlip].Clear();

            alives[NextFlip].Clear();

            foreach (Point p in AlivePoints[flip])
            {
                for (int i = p.X - 1; i <= p.X + 1; i++)
                {
                    for (int j = p.Y - 1; j <= p.Y + 1; j++)
                    {
                        // 未確定なら
                        Point pos = new Point(i, j);
                        if (!alives[NextFlip].ContainsKey(pos))
                        {
                            alives[NextFlip][pos] = IsAliveNext(i, j);
                            UsedPoints.Add(pos);
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

                    Point p = new Point(i, j);
                    if (alives[flip].ContainsKey(p) && alives[flip][p] == true)
                        count++;
                }
            }

            bool isAlive;
            if(alives[flip].ContainsKey(new Point(x, y)) && alives[flip][new Point(x, y)] == true)
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
            alives[NextFlip].Clear();
            AlivePoints[flip].Clear();
        }

        public void Step()
        {
            Update();
        }
        
        
        private int NextFlip
        {
            get { return 1 - flip; }
        }

        /// <summary>
        /// 各セルの生死
        /// </summary>
        static Dictionary<Point, bool?>[] alives = { new Dictionary<Point, bool?>(), new Dictionary<Point, bool?>() };
        
        /// <summary>
        /// 生きているセルの座標リスト
        /// </summary>
        static List<Point>[] AlivePoints = { new List<Point>(), new List<Point>() };
        
        int flip = 0;

        List<Point> UsedPoints = new List<Point>();
    }
}
