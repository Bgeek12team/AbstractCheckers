namespace Forms
{
    partial class menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            b_startStandartGame = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // b_startStandartGame
            // 
            b_startStandartGame.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            b_startStandartGame.Location = new Point(80, 65);
            b_startStandartGame.Name = "b_startStandartGame";
            b_startStandartGame.Size = new Size(341, 74);
            b_startStandartGame.TabIndex = 0;
            b_startStandartGame.Text = "Стандартная игра";
            b_startStandartGame.UseVisualStyleBackColor = true;
            b_startStandartGame.Click += b_startStandartGame_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            button2.Location = new Point(80, 145);
            button2.Name = "button2";
            button2.Size = new Size(341, 74);
            button2.TabIndex = 2;
            button2.Text = "Пользовательские события";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            button3.Location = new Point(80, 225);
            button3.Name = "button3";
            button3.Size = new Size(341, 74);
            button3.TabIndex = 3;
            button3.Text = "Случайные события";
            button3.UseVisualStyleBackColor = true;
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(450, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(b_startStandartGame);
            Name = "menu";
            Text = "menu";
            ResumeLayout(false);
        }

        #endregion

        private Button b_startStandartGame;
        private Button button2;
        private Button button3;
    }
}