namespace Forms
{
    partial class mainBoard
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
            gB_board = new GroupBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            b_stopGame = new Button();
            SuspendLayout();
            // 
            // gB_board
            // 
            gB_board.Location = new Point(14, 16);
            gB_board.Margin = new Padding(3, 4, 3, 4);
            gB_board.Name = "gB_board";
            gB_board.Padding = new Padding(3, 4, 3, 4);
            gB_board.Size = new Size(921, 880);
            gB_board.TabIndex = 0;
            gB_board.TabStop = false;
            gB_board.Text = "Поле";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(960, 16);
            label1.Name = "label1";
            label1.Size = new Size(58, 26);
            label1.TabIndex = 1;
            label1.Text = "Ход:";
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(960, 415);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(319, 221);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(960, 185);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(319, 221);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "groupBox3";
            // 
            // b_stopGame
            // 
            b_stopGame.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            b_stopGame.Location = new Point(941, 805);
            b_stopGame.Margin = new Padding(3, 4, 3, 4);
            b_stopGame.Name = "b_stopGame";
            b_stopGame.Size = new Size(319, 91);
            b_stopGame.TabIndex = 4;
            b_stopGame.Text = "Завершить";
            b_stopGame.UseVisualStyleBackColor = true;
            b_stopGame.Click += b_stopGame_Click;
            // 
            // mainBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1291, 922);
            Controls.Add(b_stopGame);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label1);
            Controls.Add(gB_board);
            Margin = new Padding(3, 4, 3, 4);
            Name = "mainBoard";
            Text = "mainBoard";
            Load += mainBoard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gB_board;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button b_stopGame;
    }
}
