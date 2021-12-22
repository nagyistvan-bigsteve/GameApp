using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    class Pawn
    {
        protected static Pawn _pawn = null;
        public int x { get; set; } = 3;
        public int y { get; set; } = 3;
        private Pawn()
        {
        }

        public Pawn setPawn(int x, int y)
        {
            this.x = x;
            this.y = y;
            return this;
        }

        public static Pawn instance()
        {
            if (_pawn == null)
            {
                _pawn = new Pawn();
            }            
            return _pawn;

        }
    }
}
