using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameApp
{
    class Grid
    {
        private Button[,] grid;
        private Action<int, int> clickAction;
        public Grid(Control parent, Pawn pawn)
        {
            CreateGrid(parent);
            DrawnPawn(pawn);
        }

        public void OnCellClick(Action<int, int> method)
        {
            clickAction = method;
        }
        public void MovePawn(Pawn pawn)
        {
            DrawnPawn(pawn);
        }

        public void LastMove(Pawn pawn)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (grid[i, j].Text != "")
                        grid[i, j].Text = "";
                    if (grid[i, j].Enabled == true)
                        grid[i, j].Enabled = false;
                }

            grid[pawn.x, pawn.y].Text = "♙";
        }
        private void DrawnPawn(Pawn pawn) 
        {
            for(int i = 0; i < 8; i++)
                for(int j = 0; j < 8; j++)
                {
                    if (grid[i, j].Text != "")
                        grid[i, j].Text = "";
                    if (grid[i, j].Enabled == true)
                        grid[i, j].Enabled = false;
                }

            grid[pawn.x, pawn.y].Text = "♙";

            grid[pawn.x+1, pawn.y].Enabled = true;
            grid[pawn.x-1, pawn.y].Enabled = true;
            grid[pawn.x, pawn.y+1].Enabled = true;
            grid[pawn.x, pawn.y-1].Enabled = true;

            grid[pawn.x + 1, pawn.y].Text = "→";
            grid[pawn.x - 1, pawn.y].Text = "←";
            grid[pawn.x, pawn.y + 1].Text = "↓";
            grid[pawn.x, pawn.y - 1].Text = "↑";

        }

        public void FillWay(List<Move> list)
        {
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                {
                    if (i == 0 || j == 0 || i == 7 || j == 7)
                        grid[i, j].BackColor = Color.IndianRed;
                    else
                        grid[i, j].BackColor = Color.AntiqueWhite; 
                }
            for(var i = 0; i < list.Count(); i++)
            {
                var move = list[i] as MoveCommand;
                grid[move.x, move.y].BackColor = Color.CornflowerBlue;
            }
        }

        private void CreateGrid(Control parent)
        {
            grid = new Button[8, 8];

            int w = parent.Width / 8;
            int h = parent.Height / 8;

            for(int i = 0; i< 8; i++)
                for(int j = 0; j< 8; j++)
                {
                    grid[i, j] = new Button();

                    grid[i, j].Width = w;
                    grid[i, j].Height = h;
                    grid[i, j].Left = i* w;
                    grid[i, j].Top = j* h;
                    grid[i, j].TabStop = false;
                    grid[i, j].Enabled = false;

                    parent.Controls.Add(grid[i, j]);

                    grid[i, j].Click += MoveToCell;

                    grid[i, j].Font = new Font("Microsoft Sans Serif",
                      24F,
                      System.Drawing.FontStyle.Regular,
                      System.Drawing.GraphicsUnit.Point,
                      ((byte)(0)));
                }
        }

        private void MoveToCell(object sender, EventArgs e)
        {
            if(clickAction != null)
            {
                Button btn = sender as Button;

                int x = btn.Left / btn.Width;
                int y = btn.Top / btn.Height;

                clickAction(x, y);
            }
        }
    }
}
