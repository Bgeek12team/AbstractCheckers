namespace Forms
{
    partial class MainBoard
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
            label1 = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            b_stopGame = new Button();
            label2 = new Label();
            txbx_leading = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(840, 56);
            label1.Name = "label1";
            label1.Size = new Size(46, 22);
            label1.TabIndex = 1;
            label1.Text = "Ход:";
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(840, 311);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(279, 166);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(840, 139);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(279, 166);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "groupBox3";
            // 
            // b_stopGame
            // 
            b_stopGame.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            b_stopGame.Location = new Point(823, 604);
            b_stopGame.Name = "b_stopGame";
            b_stopGame.Size = new Size(279, 68);
            b_stopGame.TabIndex = 4;
            b_stopGame.Text = "Завершить";
            b_stopGame.UseVisualStyleBackColor = true;
            b_stopGame.Click += b_stopGame_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(840, 7);
            label2.Name = "label2";
            label2.Size = new Size(60, 22);
            label2.TabIndex = 5;
            label2.Text = "Ходят";
            label2.Click += label2_Click;
            // 
            // txbx_leading
            // 
            txbx_leading.AutoSize = true;
            txbx_leading.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            txbx_leading.Location = new Point(910, 7);
            txbx_leading.Name = "txbx_leading";
            txbx_leading.Size = new Size(0, 22);
            txbx_leading.TabIndex = 6;
            // 
            // MainBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 680);
            Controls.Add(txbx_leading);
            Controls.Add(label2);
            Controls.Add(b_stopGame);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label1);
            Name = "MainBoard";
            Text = "mainBoard";
            Load += mainBoard_Load;
            MouseDown += mainBoard_MouseDown_1;
            MouseUp += mainBoard_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button b_stopGame;
        private Label label2;
        private Label txbx_leading;
    }
}
