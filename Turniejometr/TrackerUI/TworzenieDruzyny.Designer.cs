namespace UI
{
    partial class TworzenieDruzyny
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TworzenieDruzyny));
            PoleNazwyDruzyny = new TextBox();
            label2 = new Label();
            label1 = new Label();
            DodajCzlonkaDruzynyPrzycisk = new Button();
            label4 = new Label();
            WybierzCzlonkaDruzyny = new ComboBox();
            groupBox1 = new GroupBox();
            DodajCzlonkaPrzycisk = new Button();
            WprowadzNazwisko = new TextBox();
            WprowadzImie = new TextBox();
            label5 = new Label();
            label3 = new Label();
            CzlonkowieDruzyny = new ListBox();
            UsunCzlonka = new Button();
            DodajDruzyne = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // PoleNazwyDruzyny
            // 
            PoleNazwyDruzyny.Location = new Point(49, 107);
            PoleNazwyDruzyny.Margin = new Padding(2, 3, 2, 3);
            PoleNazwyDruzyny.Name = "PoleNazwyDruzyny";
            PoleNazwyDruzyny.Size = new Size(198, 44);
            PoleNazwyDruzyny.TabIndex = 6;
            PoleNazwyDruzyny.TextChanged += PoleNazwyDruzyny_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(49, 74);
            label2.Margin = new Padding(11, 0, 11, 0);
            label2.Name = "label2";
            label2.Size = new Size(243, 36);
            label2.TabIndex = 5;
            label2.Text = "Nazwa Drużyny:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 27.75F);
            label1.Location = new Point(40, 30);
            label1.Margin = new Padding(11, 0, 11, 0);
            label1.Name = "label1";
            label1.Size = new Size(277, 42);
            label1.TabIndex = 4;
            label1.Text = "Stwórz Drużynę";
            // 
            // DodajCzlonkaDruzynyPrzycisk
            // 
            DodajCzlonkaDruzynyPrzycisk.Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            DodajCzlonkaDruzynyPrzycisk.Location = new Point(89, 260);
            DodajCzlonkaDruzynyPrzycisk.Margin = new Padding(2, 3, 2, 3);
            DodajCzlonkaDruzynyPrzycisk.Name = "DodajCzlonkaDruzynyPrzycisk";
            DodajCzlonkaDruzynyPrzycisk.Size = new Size(123, 49);
            DodajCzlonkaDruzynyPrzycisk.TabIndex = 12;
            DodajCzlonkaDruzynyPrzycisk.Text = "Dodaj";
            DodajCzlonkaDruzynyPrzycisk.UseVisualStyleBackColor = true;
            DodajCzlonkaDruzynyPrzycisk.Click += DodajCzlonkaDruzynyPrzycisk_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(49, 171);
            label4.Margin = new Padding(11, 0, 11, 0);
            label4.Name = "label4";
            label4.Size = new Size(375, 36);
            label4.TabIndex = 11;
            label4.Text = "Wybierz Członka Drużyny";
            // 
            // WybierzCzlonkaDruzyny
            // 
            WybierzCzlonkaDruzyny.FormattingEnabled = true;
            WybierzCzlonkaDruzyny.Location = new Point(49, 212);
            WybierzCzlonkaDruzyny.Margin = new Padding(2, 3, 2, 3);
            WybierzCzlonkaDruzyny.Name = "WybierzCzlonkaDruzyny";
            WybierzCzlonkaDruzyny.Size = new Size(198, 44);
            WybierzCzlonkaDruzyny.TabIndex = 10;
            WybierzCzlonkaDruzyny.SelectedIndexChanged += WybierzCzlonkaDruzyny_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DodajCzlonkaPrzycisk);
            groupBox1.Controls.Add(WprowadzNazwisko);
            groupBox1.Controls.Add(WprowadzImie);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Arial", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            groupBox1.Location = new Point(49, 315);
            groupBox1.Margin = new Padding(2, 3, 2, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 3, 2, 3);
            groupBox1.Size = new Size(307, 259);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj nowego członka";
            // 
            // DodajCzlonkaPrzycisk
            // 
            DodajCzlonkaPrzycisk.Font = new Font("Arial", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            DodajCzlonkaPrzycisk.Location = new Point(95, 183);
            DodajCzlonkaPrzycisk.Margin = new Padding(2, 3, 2, 3);
            DodajCzlonkaPrzycisk.Name = "DodajCzlonkaPrzycisk";
            DodajCzlonkaPrzycisk.Size = new Size(123, 48);
            DodajCzlonkaPrzycisk.TabIndex = 16;
            DodajCzlonkaPrzycisk.Text = "Dodaj";
            DodajCzlonkaPrzycisk.UseVisualStyleBackColor = true;
            DodajCzlonkaPrzycisk.Click += DodajCzlonkaPrzycisk_Click;
            // 
            // WprowadzNazwisko
            // 
            WprowadzNazwisko.Location = new Point(160, 122);
            WprowadzNazwisko.Margin = new Padding(2, 3, 2, 3);
            WprowadzNazwisko.Name = "WprowadzNazwisko";
            WprowadzNazwisko.Size = new Size(83, 41);
            WprowadzNazwisko.TabIndex = 15;
            // 
            // WprowadzImie
            // 
            WprowadzImie.Location = new Point(160, 66);
            WprowadzImie.Margin = new Padding(2, 3, 2, 3);
            WprowadzImie.Name = "WprowadzImie";
            WprowadzImie.Size = new Size(83, 41);
            WprowadzImie.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 122);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(147, 33);
            label5.TabIndex = 14;
            label5.Text = "Nazwisko:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 69);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(78, 33);
            label3.TabIndex = 14;
            label3.Text = "Imie:";
            // 
            // CzlonkowieDruzyny
            // 
            CzlonkowieDruzyny.BorderStyle = BorderStyle.FixedSingle;
            CzlonkowieDruzyny.FormattingEnabled = true;
            CzlonkowieDruzyny.ItemHeight = 36;
            CzlonkowieDruzyny.Location = new Point(419, 93);
            CzlonkowieDruzyny.Margin = new Padding(2, 3, 2, 3);
            CzlonkowieDruzyny.Name = "CzlonkowieDruzyny";
            CzlonkowieDruzyny.Size = new Size(371, 470);
            CzlonkowieDruzyny.TabIndex = 14;
            CzlonkowieDruzyny.SelectedIndexChanged += CzlonkowieDruzyny_SelectedIndexChanged;
            // 
            // UsunCzlonka
            // 
            UsunCzlonka.Location = new Point(545, 44);
            UsunCzlonka.Name = "UsunCzlonka";
            UsunCzlonka.Size = new Size(106, 43);
            UsunCzlonka.TabIndex = 16;
            UsunCzlonka.Text = "Usuń";
            UsunCzlonka.UseVisualStyleBackColor = true;
            UsunCzlonka.Click += UsunCzlonka_Click;
            // 
            // DodajDruzyne
            // 
            DodajDruzyne.Font = new Font("Arial", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            DodajDruzyne.Location = new Point(238, 599);
            DodajDruzyne.Margin = new Padding(2, 3, 2, 3);
            DodajDruzyne.Name = "DodajDruzyne";
            DodajDruzyne.Size = new Size(252, 49);
            DodajDruzyne.TabIndex = 17;
            DodajDruzyne.Text = "Stwórz Drużynę";
            DodajDruzyne.UseVisualStyleBackColor = true;
            DodajDruzyne.Click += DodajDruzyne_Click;
            // 
            // TworzenieDruzyny
            // 
            AutoScaleDimensions = new SizeF(18F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1574, 909);
            Controls.Add(DodajDruzyne);
            Controls.Add(UsunCzlonka);
            Controls.Add(CzlonkowieDruzyny);
            Controls.Add(groupBox1);
            Controls.Add(DodajCzlonkaDruzynyPrzycisk);
            Controls.Add(label4);
            Controls.Add(WybierzCzlonkaDruzyny);
            Controls.Add(PoleNazwyDruzyny);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(7);
            Name = "TworzenieDruzyny";
            Text = "Stwórz Drużynę";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PoleNazwyDruzyny;
        private Label label2;
        private Label label1;
        private Button DodajCzlonkaDruzynyPrzycisk;
        private Label label4;
        private ComboBox WybierzCzlonkaDruzyny;
        private GroupBox groupBox1;
        private Button DodajCzlonkaPrzycisk;
        private TextBox WprowadzNazwisko;
        private TextBox WprowadzImie;
        private Label label5;
        private Label label3;
        private ListBox CzlonkowieDruzyny;
        private Button UsunCzlonka;
        private Button DodajDruzyne;
    }
}