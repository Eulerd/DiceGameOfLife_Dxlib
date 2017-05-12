using DxLibDLL;

namespace DiceGameOfLife_Dxlib
{
    class Drawer
    {
        bool IsGridDrawing = true;
        const int MinCount = 30;
        int gridCount = MinCount;
        int x, y;

        public int X
        {
            get { return x; }
            set { x = (value <= 0) ? 1 : value; }
        }

        public int Y
        {
            get { return y; }
            set { y = (value <= 0) ? 1 : value; }
        }

        public int Grid { get { return System.Math.Min(X, Y) / GridCount; } }
        
        public int GridCount
        {
            get { return gridCount; }
            set { gridCount = (value <= 0) ? MinCount : value; }
        }

        public Drawer(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void ChangeGridDrawing()
        {
            IsGridDrawing = !IsGridDrawing;
        }
        
        public void Update(Cells cells)
        {
            // セルを描画

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if(cells.alives[i,j])
                        DX.DrawFillBox(Grid * i, Grid * j, Grid * (i + 1), Grid * (j + 1), DX.GetColor(0, 255, 0));
                }
            }
            

            // 格子を描画
            if(IsGridDrawing)
            {
                // y軸方向
                for (int i = 0; i < X; i++)
                {
                    int pos = Grid * i;
                    DX.DrawLine(pos, 0, pos, Y,
                        (i % 10 == 0) ? DX.GetColor(128, 128, 128) : DX.GetColor(64, 64, 64));
                }

                // x軸方向
                for (int i = 0; i < Y; i++)
                {
                    int pos = Grid * i;
                    DX.DrawLine(0, pos, X, pos,
                        (i % 10 == 0) ? DX.GetColor(128, 128, 128) : DX.GetColor(64,64,64));
                }
            }

        }
    }
}
