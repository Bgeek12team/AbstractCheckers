namespace Forms
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            b_startStandartGame = new Button();
            button2 = new Button();
            button3 = new Button();
            help = new Button();
            SuspendLayout();
            // 
            // b_startStandartGame
            // 
            b_startStandartGame.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            b_startStandartGame.Location = new Point(437, 13);
            b_startStandartGame.Margin = new Padding(3, 4, 3, 4);
            b_startStandartGame.Name = "b_startStandartGame";
            b_startStandartGame.Size = new Size(390, 99);
            b_startStandartGame.TabIndex = 0;
            b_startStandartGame.Text = "Стандартная игра";
            b_startStandartGame.UseVisualStyleBackColor = true;
            b_startStandartGame.Click += b_startStandartGame_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            button2.Location = new Point(437, 207);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(390, 99);
            button2.TabIndex = 2;
            button2.Text = "Демо-сценарий";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            button3.Location = new Point(437, 460);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(390, 99);
            button3.TabIndex = 3;
            button3.Text = "Случайные события";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // help
            // 
            help.Font = new Font("Tahoma", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            help.Location = new Point(23, 480);
            help.Name = "help";
            help.Size = new Size(85, 79);
            help.TabIndex = 4;
            help.Text = "?";
            help.UseVisualStyleBackColor = true;
            help.Click += help_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(839, 572);
            Controls.Add(help);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(b_startStandartGame);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Menu";
            Text = "menu";
            ResumeLayout(false);
        }

        #endregion

        private Button b_startStandartGame;
        private Button button2;
        private Button button3;
        private Button help;
    }
}