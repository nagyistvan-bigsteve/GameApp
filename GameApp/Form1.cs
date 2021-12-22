using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameApp
{
    public partial class gameApp : Form
    {
        private MineSweeper MS;
        private List<Move> moves = new List<Move>();
        protected static gameApp gameA = null;
        private bool undoMove = false;
        private bool redoMove = false;
        private int currentIndex = -1;
        private void Start()
        {
            MS = MineSweeper.Instance(gamePanel, Undo, Redo);
            MS.OnFinished(success => 
            {
                MessageBox.Show(success ? "The end" : "Error");
            });
        }

        public static gameApp Instance()
        {
            if (gameA == null)
                gameA = new gameApp();
            return gameA;
        }

        private gameApp()
        {
            InitializeComponent();
            Start();

            Undo.Click += UndoMethod;

            Redo.Click += RedoMethod;

            History();
        }

        private void UndoMethod(object sender, EventArgs e)
        {
            if (moves.Any())
            {
                if (currentIndex > 0)
                {
                    currentIndex--;
                    undoMove = true;
                    moves[currentIndex].UnExecute();
                }
            }
        }

        private void RedoMethod(object sender, EventArgs e)
        {
            if (currentIndex < moves.Count()-1)
            {
                currentIndex++;
                redoMove = true;
                moves[currentIndex].UnExecute();
            }
            else
            if (currentIndex == moves.Count()-1)
            {
                moves[currentIndex].Execute();
            }
        }

    

        public void History()
        {
            Move command = new MoveCommand(MS);
            if (!undoMove && !redoMove)
            {
                if (currentIndex < moves.Count() - 1)
                {
                        moves.RemoveRange(currentIndex+1, moves.Count() -1 - currentIndex);   
                }
                moves.Add(command);
                currentIndex=moves.Count()-1;
                
                MS.FillWay(moves);
             
            }
            undoMove = false;
            redoMove = false;
        }
        private void GameApp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void restart_Click(object sender, EventArgs e)
        {          
            currentIndex = -1;
            moves[0].UnExecute();
            moves.Clear();
            MS.restart();
        }
    }
}
