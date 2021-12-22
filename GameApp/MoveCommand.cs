using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    class MoveCommand : Move
    {
        private Pawn pawn;
        public int x;
        public int y;
        private MineSweeper MS;
        public MoveCommand(MineSweeper MS)
        {
            this.MS = MS;
            pawn = Pawn.instance();
            x = pawn.x;
            y = pawn.y;

        }

        public override void Execute()
        {
            if (MS.lastX > pawn.x)
                MS.CellClick(pawn.x - 1, pawn.y);
            else
            if (MS.lastX < pawn.x)
                MS.CellClick(pawn.x + 1, pawn.y);
            else
            if (MS.lastY > pawn.y)
                MS.CellClick(pawn.x, pawn.y - 1);
            else
            if (MS.lastY < pawn.y)
                MS.CellClick(pawn.x, pawn.y + 1);
        }

        public override void UnExecute()
        {
            MS.CellClick(x, y);
        }

        public override string ToString()
        {
            return $"x:{x} ,y: {y}";
        }
    }
}
