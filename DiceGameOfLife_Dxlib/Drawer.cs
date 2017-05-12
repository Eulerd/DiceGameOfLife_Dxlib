using System;
using System.Collections.Generic;
using DxLibDLL;

namespace DiceGameOfLife_Dxlib
{
    class Drawer
    {
        public int Width
        {
            get { return width; }
            set { width = (value <= 0) ? 1 : value; }
        }

        public int Height
        {
            get { return height; }
            set { height = (value <= 0) ? 1 : value; }
        }

        public int GridCount
        {
            get { return gridCount; }
            set { gridCount = (value <= 0) ? 1 : value; }
        }

        public int Grid { get { return System.Math.Min(Width, Height) / GridCount; } }
        
        public Point Origin
        {
            get { return origin; }
            set { origin = new Point(value.X, value.Y); }
        }
        
        public Drawer(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public void ChangeGridDrawing()
        {
            IsGridDrawing = !IsGridDrawing;
        }

        public void Draw(List<Point> AlivesPoint, int cell_origin)
        {
            // 格子を描画
            if (IsGridDrawing)
            {
                // y軸方向
                for (int i = 0; i < Width; i++)
                {
                    int pos = Grid * i;
                    DX.DrawLine(pos, 0, pos, Height,
                        (Math.Abs(i - Origin.X) % 10 == 0) 
                        ? DX.GetColor(128, 128, 128) : DX.GetColor(64, 64, 64));
                }

                // x軸方向
                for (int i = 0; i < Height; i++)
                {
                    int pos = Grid * i;
                    DX.DrawLine(0, pos, Width, pos,
                        (Math.Abs(i - Origin.Y) % 10 == 0)
                        ? DX.GetColor(128, 128, 128) : DX.GetColor(64, 64, 64));
                }
            }

            // セルを描画
            foreach (Point p in AlivesPoint)
            {
                pos = new Point(p.X - cell_origin + Origin.X, p.Y - cell_origin + Origin.Y);
                
                DX.DrawFillBox(
                    Grid * pos.X, Grid * pos.Y,
                    Grid * (pos.X + 1), Grid * (pos.Y + 1),
                    DX.GetColor(0, 255, 0));
            }
        }

        public Point GetDrawPos(Point p)
        {
            return new Point(p.X / Grid - Origin.X, p.Y / Grid - Origin.Y);
        }
        
        bool IsGridDrawing = true;
        const int MinCount = 30;
        int gridCount = MinCount;
        int width, height;
        Point origin = new Point(0, 0);
        Point pos;
    }
}
