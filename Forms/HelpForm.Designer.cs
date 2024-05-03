namespace Forms
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            label1 = new Label();
            textHelp = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 22);
            label1.Name = "label1";
            label1.Size = new Size(747, 32);
            label1.TabIndex = 0;
            label1.Text = "Справка для правильного использования приложения";
            // 
            // textHelp
            // 
            textHelp.Font = new Font("Segoe UI", 14F);
            textHelp.Location = new Point(12, 72);
            textHelp.Multiline = true;
            textHelp.Name = "textHelp";
            textHelp.ScrollBars = ScrollBars.Vertical;
            textHelp.Size = new Size(747, 315);
            textHelp.TabIndex = 1;
            textHelp.Text = resources.GetString("textHelp.Text");
            // 
            // HelpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 399);
            Controls.Add(textHelp);
            Controls.Add(label1);
            Name = "HelpForm";
            Text = "HelpForm";
            Load += HelpForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textHelp;
    }
}