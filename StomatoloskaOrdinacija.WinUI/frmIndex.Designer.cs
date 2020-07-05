namespace StomatoloskaOrdinacija.WinUI
{
    partial class frmIndex
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKorisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacijentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviPacijentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.skladisteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosMaterijalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.unosNovogPregledaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaPregledaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledSvihTerminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajNoviPopustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.najboljiKorisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisniciPoDatumuRegistrovanjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.top10MaterijalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.top10NajboljeOcjenjenihUslugaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.pacijentiToolStripMenuItem,
            this.skladisteToolStripMenuItem,
            this.pregledToolStripMenuItem1,
            this.terminiToolStripMenuItem,
            this.popustToolStripMenuItem,
            this.reportiToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1040, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviKorisnikToolStripMenuItem,
            this.pretragaToolStripMenuItem});
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // noviKorisnikToolStripMenuItem
            // 
            this.noviKorisnikToolStripMenuItem.Name = "noviKorisnikToolStripMenuItem";
            this.noviKorisnikToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.noviKorisnikToolStripMenuItem.Text = "Novi korisnik";
            this.noviKorisnikToolStripMenuItem.Click += new System.EventHandler(this.noviKorisnikToolStripMenuItem_Click);
            // 
            // pretragaToolStripMenuItem
            // 
            this.pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            this.pretragaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.pretragaToolStripMenuItem.Text = "Pretraga";
            this.pretragaToolStripMenuItem.Click += new System.EventHandler(this.pretragaToolStripMenuItem_Click);
            // 
            // pacijentiToolStripMenuItem
            // 
            this.pacijentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviPacijentToolStripMenuItem,
            this.pretragaToolStripMenuItem1});
            this.pacijentiToolStripMenuItem.Name = "pacijentiToolStripMenuItem";
            this.pacijentiToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.pacijentiToolStripMenuItem.Text = "Pacijenti";
            // 
            // noviPacijentToolStripMenuItem
            // 
            this.noviPacijentToolStripMenuItem.Name = "noviPacijentToolStripMenuItem";
            this.noviPacijentToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.noviPacijentToolStripMenuItem.Text = "Novi pacijent";
            this.noviPacijentToolStripMenuItem.Click += new System.EventHandler(this.noviPacijentToolStripMenuItem_Click);
            // 
            // pretragaToolStripMenuItem1
            // 
            this.pretragaToolStripMenuItem1.Name = "pretragaToolStripMenuItem1";
            this.pretragaToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.pretragaToolStripMenuItem1.Text = "Pretraga";
            this.pretragaToolStripMenuItem1.Click += new System.EventHandler(this.pretragaToolStripMenuItem1_Click);
            // 
            // skladisteToolStripMenuItem
            // 
            this.skladisteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledToolStripMenuItem,
            this.unosMaterijalaToolStripMenuItem});
            this.skladisteToolStripMenuItem.Name = "skladisteToolStripMenuItem";
            this.skladisteToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.skladisteToolStripMenuItem.Text = "Skladiste";
            // 
            // pregledToolStripMenuItem
            // 
            this.pregledToolStripMenuItem.Name = "pregledToolStripMenuItem";
            this.pregledToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.pregledToolStripMenuItem.Text = "Pregled";
            this.pregledToolStripMenuItem.Click += new System.EventHandler(this.pregledToolStripMenuItem_Click);
            // 
            // unosMaterijalaToolStripMenuItem
            // 
            this.unosMaterijalaToolStripMenuItem.Name = "unosMaterijalaToolStripMenuItem";
            this.unosMaterijalaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.unosMaterijalaToolStripMenuItem.Text = "Unos materijala";
            this.unosMaterijalaToolStripMenuItem.Click += new System.EventHandler(this.unosMaterijalaToolStripMenuItem_Click);
            // 
            // pregledToolStripMenuItem1
            // 
            this.pregledToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unosNovogPregledaToolStripMenuItem,
            this.pretragaPregledaToolStripMenuItem});
            this.pregledToolStripMenuItem1.Name = "pregledToolStripMenuItem1";
            this.pregledToolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.pregledToolStripMenuItem1.Text = "Pregled";
            // 
            // unosNovogPregledaToolStripMenuItem
            // 
            this.unosNovogPregledaToolStripMenuItem.Name = "unosNovogPregledaToolStripMenuItem";
            this.unosNovogPregledaToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.unosNovogPregledaToolStripMenuItem.Text = "Unos novog pregleda";
            this.unosNovogPregledaToolStripMenuItem.Click += new System.EventHandler(this.unosNovogPregledaToolStripMenuItem_Click);
            // 
            // pretragaPregledaToolStripMenuItem
            // 
            this.pretragaPregledaToolStripMenuItem.Name = "pretragaPregledaToolStripMenuItem";
            this.pretragaPregledaToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.pretragaPregledaToolStripMenuItem.Text = "Pretraga pregleda";
            this.pretragaPregledaToolStripMenuItem.Click += new System.EventHandler(this.pretragaPregledaToolStripMenuItem_Click);
            // 
            // terminiToolStripMenuItem
            // 
            this.terminiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledSvihTerminaToolStripMenuItem});
            this.terminiToolStripMenuItem.Name = "terminiToolStripMenuItem";
            this.terminiToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.terminiToolStripMenuItem.Text = "Termini";
            // 
            // pregledSvihTerminaToolStripMenuItem
            // 
            this.pregledSvihTerminaToolStripMenuItem.Name = "pregledSvihTerminaToolStripMenuItem";
            this.pregledSvihTerminaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.pregledSvihTerminaToolStripMenuItem.Text = "Pregled svih termina";
            this.pregledSvihTerminaToolStripMenuItem.Click += new System.EventHandler(this.pregledSvihTerminaToolStripMenuItem_Click);
            // 
            // popustToolStripMenuItem
            // 
            this.popustToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajNoviPopustToolStripMenuItem});
            this.popustToolStripMenuItem.Name = "popustToolStripMenuItem";
            this.popustToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.popustToolStripMenuItem.Text = "Popust";
            // 
            // dodajNoviPopustToolStripMenuItem
            // 
            this.dodajNoviPopustToolStripMenuItem.Name = "dodajNoviPopustToolStripMenuItem";
            this.dodajNoviPopustToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.dodajNoviPopustToolStripMenuItem.Text = "Dodaj novi popust";
            this.dodajNoviPopustToolStripMenuItem.Click += new System.EventHandler(this.dodajNoviPopustToolStripMenuItem_Click);
            // 
            // reportiToolStripMenuItem
            // 
            this.reportiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.najboljiKorisniciToolStripMenuItem,
            this.korisniciPoDatumuRegistrovanjaToolStripMenuItem,
            this.top10MaterijalaToolStripMenuItem,
            this.top10NajboljeOcjenjenihUslugaToolStripMenuItem});
            this.reportiToolStripMenuItem.Name = "reportiToolStripMenuItem";
            this.reportiToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.reportiToolStripMenuItem.Text = "Reporti";
            // 
            // najboljiKorisniciToolStripMenuItem
            // 
            this.najboljiKorisniciToolStripMenuItem.Name = "najboljiKorisniciToolStripMenuItem";
            this.najboljiKorisniciToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.najboljiKorisniciToolStripMenuItem.Text = "Najbolji korisnici";
            this.najboljiKorisniciToolStripMenuItem.Click += new System.EventHandler(this.najboljiKorisniciToolStripMenuItem_Click);
            // 
            // korisniciPoDatumuRegistrovanjaToolStripMenuItem
            // 
            this.korisniciPoDatumuRegistrovanjaToolStripMenuItem.Name = "korisniciPoDatumuRegistrovanjaToolStripMenuItem";
            this.korisniciPoDatumuRegistrovanjaToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.korisniciPoDatumuRegistrovanjaToolStripMenuItem.Text = "Korisnici po datumu registrovanja";
            this.korisniciPoDatumuRegistrovanjaToolStripMenuItem.Click += new System.EventHandler(this.korisniciPoDatumuRegistrovanjaToolStripMenuItem_Click);
            // 
            // top10MaterijalaToolStripMenuItem
            // 
            this.top10MaterijalaToolStripMenuItem.Name = "top10MaterijalaToolStripMenuItem";
            this.top10MaterijalaToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.top10MaterijalaToolStripMenuItem.Text = "Top 10 materijala";
            this.top10MaterijalaToolStripMenuItem.Click += new System.EventHandler(this.top10MaterijalaToolStripMenuItem_Click);
            // 
            // top10NajboljeOcjenjenihUslugaToolStripMenuItem
            // 
            this.top10NajboljeOcjenjenihUslugaToolStripMenuItem.Name = "top10NajboljeOcjenjenihUslugaToolStripMenuItem";
            this.top10NajboljeOcjenjenihUslugaToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.top10NajboljeOcjenjenihUslugaToolStripMenuItem.Text = "Top 10 najbolje ocjenjenih usluga";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 496);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1040, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1040, 518);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmIndex";
            this.Text = "frmIndex";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIndex_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviKorisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pacijentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviPacijentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem skladisteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosMaterijalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem unosNovogPregledaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaPregledaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledSvihTerminaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem popustToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajNoviPopustToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisniciPoDatumuRegistrovanjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem top10MaterijalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem top10NajboljeOcjenjenihUslugaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem najboljiKorisniciToolStripMenuItem;
    }
}



