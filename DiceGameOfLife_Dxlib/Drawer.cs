using DxLibDLL;

namespace DiceGameOfLife_Dxlib
{
    class Drawer
    {
        bool IsGridDrawing = true;

        public void ChangeGridDrawing()
        {
            IsGridDrawing = !IsGridDrawing;
        }
        
        public void Update(Core core, Cells cells)
        {
            int X = core.X;
            int Y = core.Y;
            
            double grid = core.Grid;

            // セルを描画

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if(cells.alives[i,j])
                        DX.DrawFillBox((int)grid * i, (int)grid * j, (int)grid * (i + 1), (int)grid * (j + 1), DX.GetColor(0, 255, 0));
                }
            }
            

            // 格子を描画
            if(IsGridDrawing)
            {
                // y軸方向
                for (int i = 0; i < X; i++)
                {
                    int pos = (int)grid * i;
                    DX.DrawLine(pos, 0, pos, Y,
                        (i % 10 == 0) ? DX.GetColor(128, 128, 128) : DX.GetColor(64, 64, 64));
                }

                // x軸方向
                for (int i = 0; i < Y; i++)
                {
                    int pos = (int)grid * i;
                    DX.DrawLine(0, pos, X, pos,
                        (i % 10 == 0) ? DX.GetColor(128, 128, 128) : DX.GetColor(64,64,64));
                }
            }
            
        }
    }
}
