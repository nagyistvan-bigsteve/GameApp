using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameApp
{
    class MineSweeper
    {
        private Grid grid;
        private Action<bool> finishMethod;
        private bool game;
        public Pawn pawn;
        private Button undo, redo;
        public int lastX;
        public int lastY;
        protected static MineSweeper MS = null;
        private MineSweeper(Control target, Button undo, Button redo)
        {
            pawn = Pawn.instance();

            this.undo = undo;
            this.redo = redo;

            lastX = pawn.x;
            lastY = pawn.y;

            grid = new Grid(target, pawn);
            grid.OnCellClick(CellClick);

            game = true;
        }

        public static MineSweeper Instance(Control target, Button undo, Button redo)
        {
            if (MS == null)
                MS = new MineSweeper(target,undo,redo);
            return MS;
        }

        public void OnFinished(Action<bool> method)
        {
            finishMethod = method;
        }

        public void FillWay(List<Move> list)
        {
            grid.FillWay(list);
        }

        public void CellClick(int x, int y)
        {
            if (x == 0 || x == 7 || y == 0 || y == 7)
            {
                game = false;
                undo.Enabled = false;
                redo.Enabled = false;
                finishMethod(true);
                pawn.setPawn(x, y);
                grid.LastMove(pawn);
            }
            if (game)
            {
                lastX = pawn.x;
                lastY = pawn.y;
                pawn.setPawn(x, y);
                grid.MovePawn(pawn);
            }
            gameApp.Instance().History();

        }

        public void restart()
        {
            game = true;
            CellClick(3, 3);
            undo.Enabled = true;
            redo.Enabled = true;
        }
    }
}
