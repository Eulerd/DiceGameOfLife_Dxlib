﻿using DxLibDLL;
using System;

namespace DiceGameOfLife_Dxlib
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DX.ChangeWindowMode(DX.TRUE);
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);

            DX.DxLib_Init();

            int Width, Height;
            DX.POINTDATA mp = new DX.POINTDATA();
            DX.GetWindowSize(out Width, out Height);

            core = new Core();
            drawer = new Drawer(Width, Height);
            cells = new Cells(drawer.X, drawer.Y);
            key = new Key();
            mouse = new Mouse();

            CellEnable = false;

            while (DX.ProcessMessage() != -1)
            {
                DX.ClearDrawScreen();

                DX.GetMousePoint(out mp.x, out mp.y);

                if (CellEnable)
                    cells.Update(drawer.X, drawer.Y);

                drawer.Update(cells);
                key.Update();
                mouse.Update();

                // key
                if (key.IsPressed(DX.KEY_INPUT_ESCAPE))
                    break;
                if (key.IsPressing(DX.KEY_INPUT_MINUS))
                    drawer.GridCount++;
                if (key.IsPressing(DX.KEY_INPUT_SEMICOLON))
                    drawer.GridCount--;
                if (key.IsPressed(DX.KEY_INPUT_SPACE))
                    CellEnable = !CellEnable;
                if (key.IsPressed(DX.KEY_INPUT_C))
                    cells.Clear();
                if (key.IsPressed(DX.KEY_INPUT_G))
                    drawer.ChangeGridDrawing();

                // mouse
                if (mouse.IsPressing(DX.MOUSE_INPUT_LEFT))
                    cells.alives[(int)(mp.x / drawer.Grid), (int)(mp.y / drawer.Grid)] = true;
                if (mouse.IsPressing(DX.MOUSE_INPUT_RIGHT))
                    cells.alives[(int)(mp.x / drawer.Grid), (int)(mp.y / drawer.Grid)] = false;
                
                DX.ScreenFlip();
            }

            DX.DxLib_End();
        }

        static bool CellEnable;
        static Core core;
        static Drawer drawer;
        static Cells cells;
        static Key key;
        static Mouse mouse;
    }
}
