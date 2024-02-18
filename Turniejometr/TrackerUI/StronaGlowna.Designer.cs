namespace UI
{
    partial class StronaGlowna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StronaGlowna));
            label1 = new Label();
            label4 = new Label();
            WybierzCzlonkaDruzyny = new ComboBox();
            WczytajTurniej = new Button();
            stworzTurniej = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(372, 30);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(224, 42);
            label1.TabIndex = 6;
            label1.Text = "Turniejometr";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(387, 127);
            label4.Margin = new Padding(11, 0, 11, 0);
            label4.Name = "label4";
            label4.Size = new Size(203, 32);
            label4.TabIndex = 13;
            label4.Text = "Wybierz Turniej";
            // 
            // WybierzCzlonkaDruzyny
            // 
            WybierzCzlonkaDruzyny.FormattingEnabled = true;
            WybierzCzlonkaDruzyny.Location = new Point(324, 178);
            WybierzCzlonkaDruzyny.Margin = new Padding(2, 3, 2, 3);
            WybierzCzlonkaDruzyny.Name = "WybierzCzlonkaDruzyny";
            WybierzCzlonkaDruzyny.Size = new Size(328, 32);
            WybierzCzlonkaDruzyny.TabIndex = 12;
            // 
            // WczytajTurniej
            // 
            WczytajTurniej.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            WczytajTurniej.Location = new Point(384, 230);
            WczytajTurniej.Margin = new Padding(2, 3, 2, 3);
            WczytajTurniej.Name = "WczytajTurniej";
            WczytajTurniej.Size = new Size(212, 48);
            WczytajTurniej.TabIndex = 19;
            WczytajTurniej.Text = "Wczytaj Turniej";
            WczytajTurniej.UseVisualStyleBackColor = true;
            WczytajTurniej.Click += WczytajTurniej_Click;
            // 
            // stworzTurniej
            // 
            stworzTurniej.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            stworzTurniej.Location = new Point(384, 322);
            stworzTurniej.Margin = new Padding(2, 3, 2, 3);
            stworzTurniej.Name = "stworzTurniej";
            stworzTurniej.RightToLeft = RightToLeft.No;
            stworzTurniej.Size = new Size(212, 48);
            stworzTurniej.TabIndex = 20;
            stworzTurniej.Text = "Stwórz Turniej";
            stworzTurniej.UseVisualStyleBackColor = true;
            stworzTurniej.Click += stworzTurniej_Click;
            // 
            // StronaGlowna
            // 
            AutoScaleDimensions = new SizeF(12F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(1049, 606);
            Controls.Add(stworzTurniej);
            Controls.Add(WczytajTurniej);
            Controls.Add(label4);
            Controls.Add(WybierzCzlonkaDruzyny);
            Controls.Add(label1);
            Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            Name = "StronaGlowna";
            Text = "Strona Główna";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label4;
        private ComboBox WybierzCzlonkaDruzyny;
        private Button WczytajTurniej;
        private Button stworzTurniej;
    }
}