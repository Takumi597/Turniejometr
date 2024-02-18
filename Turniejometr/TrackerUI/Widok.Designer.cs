namespace UI
{
    partial class Widok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Widok));
            label1 = new Label();
            TurniejNazwa = new Label();
            label2 = new Label();
            RundaNumer = new ComboBox();
            CzyTylkoNoweRundy = new CheckBox();
            ListaMeczy = new ListBox();
            Druzyna1 = new Label();
            Druzyna2 = new Label();
            Wynik1label = new Label();
            Wynik2label = new Label();
            Wynik1 = new TextBox();
            Wynik2 = new TextBox();
            VSlabel = new Label();
            PotwierdzWynik = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 27.75F);
            label1.Location = new Point(50, 51);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(140, 42);
            label1.TabIndex = 0;
            label1.Text = "Turniej:";
            // 
            // TurniejNazwa
            // 
            TurniejNazwa.AutoSize = true;
            TurniejNazwa.Font = new Font("Arial", 27.75F);
            TurniejNazwa.Location = new Point(200, 51);
            TurniejNazwa.Margin = new Padding(5, 0, 5, 0);
            TurniejNazwa.Name = "TurniejNazwa";
            TurniejNazwa.Size = new Size(113, 42);
            TurniejNazwa.TabIndex = 1;
            TurniejNazwa.Text = "<n/a>";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 113);
            label2.Name = "label2";
            label2.Size = new Size(117, 36);
            label2.TabIndex = 2;
            label2.Text = "Runda:";
            // 
            // RundaNumer
            // 
            RundaNumer.FormattingEnabled = true;
            RundaNumer.Location = new Point(196, 113);
            RundaNumer.Name = "RundaNumer";
            RundaNumer.Size = new Size(149, 44);
            RundaNumer.TabIndex = 3;
            RundaNumer.SelectedIndexChanged += RundaNumer_SelectedIndexChanged;
            // 
            // CzyTylkoNoweRundy
            // 
            CzyTylkoNoweRundy.AutoSize = true;
            CzyTylkoNoweRundy.Location = new Point(73, 163);
            CzyTylkoNoweRundy.Name = "CzyTylkoNoweRundy";
            CzyTylkoNoweRundy.Size = new Size(462, 40);
            CzyTylkoNoweRundy.TabIndex = 4;
            CzyTylkoNoweRundy.Text = "Wyświetl tylko pozostałe rundy";
            CzyTylkoNoweRundy.UseVisualStyleBackColor = true;
            CzyTylkoNoweRundy.CheckedChanged += CzyTylkoNoweRundy_CheckedChanged;
            // 
            // ListaMeczy
            // 
            ListaMeczy.BorderStyle = BorderStyle.FixedSingle;
            ListaMeczy.FormattingEnabled = true;
            ListaMeczy.ItemHeight = 36;
            ListaMeczy.Location = new Point(73, 209);
            ListaMeczy.Name = "ListaMeczy";
            ListaMeczy.Size = new Size(437, 290);
            ListaMeczy.TabIndex = 5;
            ListaMeczy.SelectedIndexChanged += ListaMeczy_SelectedIndexChanged;
            // 
            // Druzyna1
            // 
            Druzyna1.AutoSize = true;
            Druzyna1.Location = new Point(563, 209);
            Druzyna1.Name = "Druzyna1";
            Druzyna1.Size = new Size(97, 36);
            Druzyna1.TabIndex = 6;
            Druzyna1.Text = "<n/a>";
            // 
            // Druzyna2
            // 
            Druzyna2.AutoSize = true;
            Druzyna2.Location = new Point(563, 319);
            Druzyna2.Name = "Druzyna2";
            Druzyna2.Size = new Size(97, 36);
            Druzyna2.TabIndex = 7;
            Druzyna2.Text = "<n/a>";
            // 
            // Wynik1label
            // 
            Wynik1label.AutoSize = true;
            Wynik1label.Location = new Point(563, 263);
            Wynik1label.Name = "Wynik1label";
            Wynik1label.Size = new Size(112, 36);
            Wynik1label.TabIndex = 8;
            Wynik1label.Text = "Wynik:";
            // 
            // Wynik2label
            // 
            Wynik2label.AutoSize = true;
            Wynik2label.Location = new Point(563, 371);
            Wynik2label.Name = "Wynik2label";
            Wynik2label.Size = new Size(112, 36);
            Wynik2label.TabIndex = 9;
            Wynik2label.Text = "Wynik:";
            // 
            // Wynik1
            // 
            Wynik1.Location = new Point(681, 260);
            Wynik1.Name = "Wynik1";
            Wynik1.Size = new Size(100, 44);
            Wynik1.TabIndex = 10;
            
            // 
            // Wynik2
            // 
            Wynik2.Location = new Point(681, 368);
            Wynik2.Name = "Wynik2";
            Wynik2.Size = new Size(100, 44);
            Wynik2.TabIndex = 11;
            
            // 
            // VSlabel
            // 
            VSlabel.AutoSize = true;
            VSlabel.Location = new Point(516, 299);
            VSlabel.Name = "VSlabel";
            VSlabel.Size = new Size(57, 36);
            VSlabel.TabIndex = 12;
            VSlabel.Text = "VS";
            // 
            // PotwierdzWynik
            // 
            PotwierdzWynik.FlatStyle = FlatStyle.Popup;
            PotwierdzWynik.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            PotwierdzWynik.Location = new Point(794, 312);
            PotwierdzWynik.Name = "PotwierdzWynik";
            PotwierdzWynik.Size = new Size(87, 43);
            PotwierdzWynik.TabIndex = 13;
            PotwierdzWynik.Text = "Wynik";
            PotwierdzWynik.UseVisualStyleBackColor = true;
            PotwierdzWynik.Click += PotwierdzWynik_Click;
                
            // 
            // Widok
            // 
            AutoScaleDimensions = new SizeF(18F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(1574, 909);
            Controls.Add(PotwierdzWynik);
            Controls.Add(VSlabel);
            Controls.Add(Wynik2);
            Controls.Add(Wynik1);
            Controls.Add(Wynik2label);
            Controls.Add(Wynik1label);
            Controls.Add(Druzyna2);
            Controls.Add(Druzyna1);
            Controls.Add(ListaMeczy);
            Controls.Add(CzyTylkoNoweRundy);
            Controls.Add(RundaNumer);
            Controls.Add(label2);
            Controls.Add(TurniejNazwa);
            Controls.Add(label1);
            Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(7, 8, 7, 8);
            Name = "Widok";
            Text = "Turniejometr";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label TurniejNazwa;
        private Label label2;
        private ComboBox RundaNumer;
        private CheckBox CzyTylkoNoweRundy;
        private ListBox ListaMeczy;
        private Label Druzyna1;
        private Label Druzyna2;
        private Label Wynik1label;
        private Label Wynik2label;
        private TextBox Wynik1;
        private TextBox Wynik2;
        private Label VSlabel;
        private Button PotwierdzWynik;
    }
}
