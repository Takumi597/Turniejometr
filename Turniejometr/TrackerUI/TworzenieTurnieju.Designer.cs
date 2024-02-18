
namespace UI
{
    partial class TworzenieTurnieju
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TworzenieTurnieju));
            label1 = new Label();
            label2 = new Label();
            PoleNazwyTurnieju = new TextBox();
            label3 = new Label();
            PoleKwoty = new TextBox();
            WybierzDruzyne = new ComboBox();
            label4 = new Label();
            DodajDruzyne = new LinkLabel();
            DodajDruzynePrzycisk = new Button();
            DodajNagrodePrzycisk = new Button();
            label5 = new Label();
            ListaGraczy = new ListBox();
            ListaNagrod = new ListBox();
            label6 = new Label();
            UsunGraczy = new Button();
            UsunNagrody = new Button();
            StworzTurniej = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 27.75F);
            label1.Location = new Point(52, 53);
            label1.Margin = new Padding(13, 0, 13, 0);
            label1.Name = "label1";
            label1.Size = new Size(252, 42);
            label1.TabIndex = 1;
            label1.Text = "Stwórz Turniej";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(63, 104);
            label2.Margin = new Padding(13, 0, 13, 0);
            label2.Name = "label2";
            label2.Size = new Size(241, 36);
            label2.TabIndex = 2;
            label2.Text = "Nazwa Turnieju:";
            // 
            // PoleNazwyTurnieju
            // 
            PoleNazwyTurnieju.Location = new Point(63, 143);
            PoleNazwyTurnieju.Name = "PoleNazwyTurnieju";
            PoleNazwyTurnieju.Size = new Size(241, 44);
            PoleNazwyTurnieju.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(63, 213);
            label3.Margin = new Padding(13, 0, 13, 0);
            label3.Name = "label3";
            label3.Size = new Size(116, 36);
            label3.TabIndex = 4;
            label3.Text = "Opłata:";
            // 
            // PoleKwoty
            // 
            PoleKwoty.Location = new Point(182, 210);
            PoleKwoty.Name = "PoleKwoty";
            PoleKwoty.Size = new Size(122, 44);
            PoleKwoty.TabIndex = 5;
            // 
            // WybierzDruzyne
            // 
            WybierzDruzyne.FormattingEnabled = true;
            WybierzDruzyne.Location = new Point(63, 304);
            WybierzDruzyne.Name = "WybierzDruzyne";
            WybierzDruzyne.Size = new Size(241, 44);
            WybierzDruzyne.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(52, 257);
            label4.Margin = new Padding(13, 0, 13, 0);
            label4.Name = "label4";
            label4.Size = new Size(255, 36);
            label4.TabIndex = 7;
            label4.Text = "Wybierz Drużynę";
            // 
            // DodajDruzyne
            // 
            DodajDruzyne.AutoSize = true;
            DodajDruzyne.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            DodajDruzyne.Location = new Point(52, 369);
            DodajDruzyne.Name = "DodajDruzyne";
            DodajDruzyne.Size = new Size(281, 32);
            DodajDruzyne.TabIndex = 8;
            DodajDruzyne.TabStop = true;
            DodajDruzyne.Text = "Stwórz Nową Drużynę";
            DodajDruzyne.LinkClicked += DodajDruzyne_LinkClicked_1;
            // 
            // DodajDruzynePrzycisk
            // 
            DodajDruzynePrzycisk.Location = new Point(310, 305);
            DodajDruzynePrzycisk.Name = "DodajDruzynePrzycisk";
            DodajDruzynePrzycisk.Size = new Size(106, 43);
            DodajDruzynePrzycisk.TabIndex = 9;
            DodajDruzynePrzycisk.Text = "Dodaj";
            DodajDruzynePrzycisk.UseVisualStyleBackColor = true;
            DodajDruzynePrzycisk.Click += DodajDruzynePrzycisk_Click;
            // 
            // DodajNagrodePrzycisk
            // 
            DodajNagrodePrzycisk.Location = new Point(63, 417);
            DodajNagrodePrzycisk.Name = "DodajNagrodePrzycisk";
            DodajNagrodePrzycisk.Size = new Size(244, 48);
            DodajNagrodePrzycisk.TabIndex = 10;
            DodajNagrodePrzycisk.Text = "Dodaj Nagrodę";
            DodajNagrodePrzycisk.UseVisualStyleBackColor = true;
            DodajNagrodePrzycisk.Click += DodajNagrodePrzycisk_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(422, 104);
            label5.Name = "label5";
            label5.Size = new Size(258, 36);
            label5.TabIndex = 11;
            label5.Text = "Drużyny / Gracze";
            // 
            // ListaGraczy
            // 
            ListaGraczy.BorderStyle = BorderStyle.FixedSingle;
            ListaGraczy.FormattingEnabled = true;
            ListaGraczy.ItemHeight = 36;
            ListaGraczy.Location = new Point(422, 143);
            ListaGraczy.Name = "ListaGraczy";
            ListaGraczy.Size = new Size(262, 254);
            ListaGraczy.TabIndex = 12;
            // 
            // ListaNagrod
            // 
            ListaNagrod.BorderStyle = BorderStyle.FixedSingle;
            ListaNagrod.FormattingEnabled = true;
            ListaNagrod.ItemHeight = 36;
            ListaNagrod.Location = new Point(422, 442);
            ListaNagrod.Name = "ListaNagrod";
            ListaNagrod.Size = new Size(262, 254);
            ListaNagrod.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(422, 403);
            label6.Name = "label6";
            label6.Size = new Size(132, 36);
            label6.TabIndex = 13;
            label6.Text = "Nagrody";
            // 
            // UsunGraczy
            // 
            UsunGraczy.Location = new Point(705, 238);
            UsunGraczy.Name = "UsunGraczy";
            UsunGraczy.Size = new Size(106, 43);
            UsunGraczy.TabIndex = 15;
            UsunGraczy.Text = "Usuń";
            UsunGraczy.UseVisualStyleBackColor = true;
            UsunGraczy.Click += UsunGraczy_Click;
            // 
            // UsunNagrody
            // 
            UsunNagrody.Location = new Point(705, 548);
            UsunNagrody.Name = "UsunNagrody";
            UsunNagrody.Size = new Size(106, 43);
            UsunNagrody.TabIndex = 16;
            UsunNagrody.Text = "Usuń";
            UsunNagrody.UseVisualStyleBackColor = true;
            UsunNagrody.Click += UsunNagrody_Click;
            // 
            // StworzTurniej
            // 
            StworzTurniej.Location = new Point(63, 569);
            StworzTurniej.Name = "StworzTurniej";
            StworzTurniej.Size = new Size(241, 99);
            StworzTurniej.TabIndex = 17;
            StworzTurniej.Text = "Stwórz Turniej";
            StworzTurniej.UseVisualStyleBackColor = true;
            StworzTurniej.Click += StworzTurniej_Click;
            // 
            // TworzenieTurnieju
            // 
            AutoScaleDimensions = new SizeF(18F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(1924, 1061);
            Controls.Add(StworzTurniej);
            Controls.Add(UsunNagrody);
            Controls.Add(UsunGraczy);
            Controls.Add(ListaNagrod);
            Controls.Add(label6);
            Controls.Add(ListaGraczy);
            Controls.Add(label5);
            Controls.Add(DodajNagrodePrzycisk);
            Controls.Add(DodajDruzynePrzycisk);
            Controls.Add(DodajDruzyne);
            Controls.Add(label4);
            Controls.Add(WybierzDruzyne);
            Controls.Add(PoleKwoty);
            Controls.Add(label3);
            Controls.Add(PoleNazwyTurnieju);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(8, 7, 8, 7);
            Name = "TworzenieTurnieju";
            Text = "Stwórz Turniej";
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion

        private Label label1;
        private Label label2;
        private TextBox PoleNazwyTurnieju;
        private Label label3;
        private TextBox PoleKwoty;
        private ComboBox WybierzDruzyne;
        private Label label4;
        private LinkLabel DodajDruzyne;
        private Button DodajDruzynePrzycisk;
        private Button DodajNagrodePrzycisk;
        private Label label5;
        private ListBox ListaGraczy;
        private ListBox ListaNagrod;
        private Label label6;
        private Button UsunGraczy;
        private Button UsunNagrody;
        private Button StworzTurniej;
    }
}