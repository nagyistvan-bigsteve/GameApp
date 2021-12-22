
namespace GameApp
{
    partial class gameApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gamePanel = new System.Windows.Forms.Panel();
            this.Undo = new System.Windows.Forms.Button();
            this.Redo = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gamePanel.Location = new System.Drawing.Point(12, 12);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(560, 560);
            this.gamePanel.TabIndex = 0;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePanel_Paint);
            // 
            // Undo
            // 
            this.Undo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Undo.Location = new System.Drawing.Point(34, 579);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(154, 43);
            this.Undo.TabIndex = 1;
            this.Undo.TabStop = false;
            this.Undo.Text = "Undo ←";
            this.Undo.UseVisualStyleBackColor = false;
            this.Undo.Click += new System.EventHandler(this.button1_Click);
            // 
            // Redo
            // 
            this.Redo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Redo.Location = new System.Drawing.Point(407, 579);
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(145, 43);
            this.Redo.TabIndex = 2;
            this.Redo.TabStop = false;
            this.Redo.Text = "Redo →";
            this.Redo.UseVisualStyleBackColor = false;
            // 
            // restart
            // 
            this.restart.BackColor = System.Drawing.Color.Wheat;
            this.restart.Location = new System.Drawing.Point(248, 579);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(94, 43);
            this.restart.TabIndex = 3;
            this.restart.TabStop = false;
            this.restart.Text = "Restart ⟲";
            this.restart.UseVisualStyleBackColor = false;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // gameApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 634);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.Redo);
            this.Controls.Add(this.Undo);
            this.Controls.Add(this.gamePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "gameApp";
            this.Text = "GameApp";
            this.Load += new System.EventHandler(this.GameApp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button Redo;
        private System.Windows.Forms.Button restart;
    }
}

