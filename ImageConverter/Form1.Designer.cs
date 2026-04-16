namespace ImageConverter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Painéis principais
        private System.Windows.Forms.PictureBox  picBackground;
        private System.Windows.Forms.Panel       panelMenu;
        private System.Windows.Forms.Panel       panelConvert;
        private System.Windows.Forms.Panel       panelResize;
        private System.Windows.Forms.Panel       panelPrefix;

        // Menu
        private System.Windows.Forms.Button btnMenuConvert;
        private System.Windows.Forms.Button btnMenuResize;
        private System.Windows.Forms.Button btnMenuPrefix;

        // Converter Extensão
        private System.Windows.Forms.Button      btnSelectFiles;
        private System.Windows.Forms.Button      btnConvert;
        private System.Windows.Forms.Button      btnSelectOutput;
        private System.Windows.Forms.Button      btnBackConvert;
        private System.Windows.Forms.ListBox     lstFiles;
        private System.Windows.Forms.ComboBox    cmbFormat;
        private System.Windows.Forms.Label       lblFormat;
        private System.Windows.Forms.Label       lblFiles;
        private System.Windows.Forms.Label       lblOutput;
        private System.Windows.Forms.Label       lblOutputPath;
        private System.Windows.Forms.Label       lblStatus;
        private System.Windows.Forms.ProgressBar progressBar;

        // Redimensionar
        private System.Windows.Forms.Button        btnResizeSelectFiles;
        private System.Windows.Forms.Button        btnResizeSelectOutput;
        private System.Windows.Forms.Button        btnResize;
        private System.Windows.Forms.Button        btnBackResize;
        private System.Windows.Forms.ListBox       lstResizeFiles;
        private System.Windows.Forms.Label         lblResizeFiles;
        private System.Windows.Forms.Label         lblResizeOutput;
        private System.Windows.Forms.Label         lblResizeOutputPath;
        private System.Windows.Forms.Label         lblResizeWidth;
        private System.Windows.Forms.Label         lblResizeHeight;
        private System.Windows.Forms.Label         lblResizeDpi;
        private System.Windows.Forms.Label         lblResizeStatus;
        private System.Windows.Forms.NumericUpDown numResizeWidth;
        private System.Windows.Forms.NumericUpDown numResizeHeight;
        private System.Windows.Forms.NumericUpDown numResizeDpi;
        private System.Windows.Forms.ProgressBar   progressBarResize;

        // Adicionar Prefixo
        private System.Windows.Forms.Button      btnPrefixSelectFiles;
        private System.Windows.Forms.Button      btnPrefix;
        private System.Windows.Forms.Button      btnBackPrefix;
        private System.Windows.Forms.ListBox     lstPrefixFiles;
        private System.Windows.Forms.Label       lblPrefixFiles;
        private System.Windows.Forms.Label       lblPrefixText;
        private System.Windows.Forms.Label       lblPrefixPreview;
        private System.Windows.Forms.Label       lblPrefixStatus;
        private System.Windows.Forms.TextBox     txtPrefix;
        private System.Windows.Forms.ProgressBar progressBarPrefix;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // instâncias
            picBackground        = new System.Windows.Forms.PictureBox();
            panelMenu            = new System.Windows.Forms.Panel();
            panelConvert         = new System.Windows.Forms.Panel();
            panelResize          = new System.Windows.Forms.Panel();
            panelPrefix          = new System.Windows.Forms.Panel();

            btnMenuConvert       = new System.Windows.Forms.Button();
            btnMenuResize        = new System.Windows.Forms.Button();
            btnMenuPrefix        = new System.Windows.Forms.Button();

            btnSelectFiles       = new System.Windows.Forms.Button();
            btnConvert           = new System.Windows.Forms.Button();
            btnSelectOutput      = new System.Windows.Forms.Button();
            btnBackConvert       = new System.Windows.Forms.Button();
            lstFiles             = new System.Windows.Forms.ListBox();
            cmbFormat            = new System.Windows.Forms.ComboBox();
            lblFormat            = new System.Windows.Forms.Label();
            lblFiles             = new System.Windows.Forms.Label();
            lblOutput            = new System.Windows.Forms.Label();
            lblOutputPath        = new System.Windows.Forms.Label();
            lblStatus            = new System.Windows.Forms.Label();
            progressBar          = new System.Windows.Forms.ProgressBar();

            btnResizeSelectFiles  = new System.Windows.Forms.Button();
            btnResizeSelectOutput = new System.Windows.Forms.Button();
            btnResize             = new System.Windows.Forms.Button();
            btnBackResize         = new System.Windows.Forms.Button();
            lstResizeFiles        = new System.Windows.Forms.ListBox();
            lblResizeFiles        = new System.Windows.Forms.Label();
            lblResizeOutput       = new System.Windows.Forms.Label();
            lblResizeOutputPath   = new System.Windows.Forms.Label();
            lblResizeWidth        = new System.Windows.Forms.Label();
            lblResizeHeight       = new System.Windows.Forms.Label();
            lblResizeDpi          = new System.Windows.Forms.Label();
            lblResizeStatus       = new System.Windows.Forms.Label();
            numResizeWidth        = new System.Windows.Forms.NumericUpDown();
            numResizeHeight       = new System.Windows.Forms.NumericUpDown();
            numResizeDpi          = new System.Windows.Forms.NumericUpDown();
            progressBarResize     = new System.Windows.Forms.ProgressBar();

            btnPrefixSelectFiles  = new System.Windows.Forms.Button();
            btnPrefix             = new System.Windows.Forms.Button();
            btnBackPrefix         = new System.Windows.Forms.Button();
            lstPrefixFiles        = new System.Windows.Forms.ListBox();
            lblPrefixFiles        = new System.Windows.Forms.Label();
            lblPrefixText         = new System.Windows.Forms.Label();
            lblPrefixPreview      = new System.Windows.Forms.Label();
            lblPrefixStatus       = new System.Windows.Forms.Label();
            txtPrefix             = new System.Windows.Forms.TextBox();
            progressBarPrefix     = new System.Windows.Forms.ProgressBar();

            SuspendLayout();

            // ── PictureBox background ────────────────────────────────────
            picBackground.Dock     = System.Windows.Forms.DockStyle.Fill;
            picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picBackground.Image    = System.Drawing.Image.FromFile(
                System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "background.png"));

            // ── Helpers de estilo ────────────────────────────────────────
            var orange   = System.Drawing.Color.FromArgb(230, 100, 20);
            var boldFont = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            var uiFont   = new System.Drawing.Font("Segoe UI", 9.5f);

            void MenuBtn(System.Windows.Forms.Button b, string text, int y, System.EventHandler h)
            {
                b.Text      = text;
                b.Size      = new System.Drawing.Size(200, 42);
                b.Location  = new System.Drawing.Point(30, y);
                b.BackColor = orange;
                b.ForeColor = System.Drawing.Color.White;
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Font      = boldFont;
                b.Cursor    = System.Windows.Forms.Cursors.Hand;
                b.Click    += h;
            }

            void BackBtn(System.Windows.Forms.Button b)
            {
                b.Text      = "← Voltar";
                b.Size      = new System.Drawing.Size(90, 26);
                b.Location  = new System.Drawing.Point(8, 8);
                b.BackColor = System.Drawing.Color.FromArgb(76, 75, 99);  // #4C4B63
                b.ForeColor = System.Drawing.Color.White;
                b.Font      = new System.Drawing.Font("Segoe UI", 8.5f);
                b.Cursor    = System.Windows.Forms.Cursors.Hand;
                b.Click    += new System.EventHandler(this.btnBack_Click);
            }

            void ActionBtn(System.Windows.Forms.Button b, string text, System.Drawing.Point loc, System.EventHandler h)
            {
                b.Text      = text;
                b.Size      = new System.Drawing.Size(135, 32);
                b.Location  = loc;
                b.BackColor = System.Drawing.Color.FromArgb(230, 100, 20);  // Laranja
                b.ForeColor = System.Drawing.Color.White;
                b.Click    += h;
            }

            // ── Panel Menu ───────────────────────────────────────────────
            panelMenu.Bounds          = new System.Drawing.Rectangle(0, 0, 700, 500);
            panelMenu.BackColor       = System.Drawing.Color.Transparent;

            MenuBtn(btnMenuConvert, "Converter Extensão", 316, new System.EventHandler(this.btnMenuConvert_Click));
            MenuBtn(btnMenuResize,  "Redimensionar",      368, new System.EventHandler(this.btnMenuResize_Click));
            MenuBtn(btnMenuPrefix,  "Adicionar Prefixo",  420, new System.EventHandler(this.btnMenuPrefix_Click));

            panelMenu.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnMenuConvert, btnMenuResize, btnMenuPrefix
            });

            // ── Panel Converter Extensão ─────────────────────────────────
            panelConvert.Bounds    = new System.Drawing.Rectangle(0, 0, 700, 500);
            panelConvert.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            panelConvert.Visible   = false;
            panelConvert.Font      = uiFont;

            BackBtn(btnBackConvert);

            lblFiles.Text     = "Imagens selecionadas:";
            lblFiles.Location = new System.Drawing.Point(20, 48);
            lblFiles.Size     = new System.Drawing.Size(160, 20);

            lstFiles.Location            = new System.Drawing.Point(20, 70);
            lstFiles.Size                = new System.Drawing.Size(660, 150);
            lstFiles.ScrollAlwaysVisible = true;

            btnSelectFiles.Text      = "Selecionar Imagens";
            btnSelectFiles.Location  = new System.Drawing.Point(20, 232);
            btnSelectFiles.Size      = new System.Drawing.Size(150, 30);
            btnSelectFiles.BackColor = System.Drawing.Color.FromArgb(76, 75, 99);  // #4C4B63
            btnSelectFiles.ForeColor = System.Drawing.Color.White;
            btnSelectFiles.Font      = new System.Drawing.Font("Segoe UI", 9f);
            btnSelectFiles.Cursor    = System.Windows.Forms.Cursors.Hand;
            btnSelectFiles.Click    += new System.EventHandler(this.btnSelectFiles_Click);

            lblOutput.Text     = "Pasta de saída:";
            lblOutput.Location = new System.Drawing.Point(20, 282);
            lblOutput.Size     = new System.Drawing.Size(95, 20);

            lblOutputPath.Text         = "Nenhuma pasta selecionada";
            lblOutputPath.Location     = new System.Drawing.Point(120, 282);
            lblOutputPath.Size         = new System.Drawing.Size(420, 20);
            lblOutputPath.ForeColor    = System.Drawing.Color.Gray;
            lblOutputPath.AutoEllipsis = true;

            btnSelectOutput.Text      = "Selecionar Pasta";
            btnSelectOutput.Location  = new System.Drawing.Point(548, 278);
            btnSelectOutput.Size      = new System.Drawing.Size(132, 28);
            btnSelectOutput.BackColor = System.Drawing.Color.FromArgb(76, 75, 99);  // #4C4B63
            btnSelectOutput.ForeColor = System.Drawing.Color.White;
            btnSelectOutput.Font      = new System.Drawing.Font("Segoe UI", 9f);
            btnSelectOutput.Cursor    = System.Windows.Forms.Cursors.Hand;
            btnSelectOutput.Click    += new System.EventHandler(this.btnSelectOutput_Click);

            lblFormat.Text     = "Converter para:";
            lblFormat.Location = new System.Drawing.Point(20, 326);
            lblFormat.Size     = new System.Drawing.Size(95, 20);

            cmbFormat.Location      = new System.Drawing.Point(120, 323);
            cmbFormat.Size          = new System.Drawing.Size(110, 24);
            cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbFormat.Items.AddRange(new object[] { "PNG", "JPG", "BMP", "GIF", "TIFF" });
            cmbFormat.SelectedIndex = 0;

            ActionBtn(btnConvert, "Converter", new System.Drawing.Point(545, 319), new System.EventHandler(this.btnConvert_Click));

            progressBar.Location = new System.Drawing.Point(20, 368);
            progressBar.Size     = new System.Drawing.Size(660, 20);

            lblStatus.Text      = "Pronto.";
            lblStatus.Location  = new System.Drawing.Point(20, 396);
            lblStatus.Size      = new System.Drawing.Size(660, 20);
            lblStatus.ForeColor = System.Drawing.Color.DimGray;

            panelConvert.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnBackConvert, lblFiles, lstFiles, btnSelectFiles,
                lblOutput, lblOutputPath, btnSelectOutput,
                lblFormat, cmbFormat, btnConvert,
                progressBar, lblStatus
            });

            // ── Panel Redimensionar ──────────────────────────────────────
            panelResize.Bounds    = new System.Drawing.Rectangle(0, 0, 700, 500);
            panelResize.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            panelResize.Visible   = false;
            panelResize.Font      = uiFont;

            BackBtn(btnBackResize);

            lblResizeFiles.Text     = "Imagens selecionadas:";
            lblResizeFiles.Location = new System.Drawing.Point(20, 48);
            lblResizeFiles.Size     = new System.Drawing.Size(160, 20);

            lstResizeFiles.Location            = new System.Drawing.Point(20, 70);
            lstResizeFiles.Size                = new System.Drawing.Size(660, 140);
            lstResizeFiles.ScrollAlwaysVisible = true;

            btnResizeSelectFiles.Text      = "Selecionar Imagens";
            btnResizeSelectFiles.Location  = new System.Drawing.Point(20, 222);
            btnResizeSelectFiles.Size      = new System.Drawing.Size(150, 30);
            btnResizeSelectFiles.BackColor = System.Drawing.Color.FromArgb(76, 75, 99);  // #4C4B63
            btnResizeSelectFiles.ForeColor = System.Drawing.Color.White;
            btnResizeSelectFiles.Font      = new System.Drawing.Font("Segoe UI", 9f);
            btnResizeSelectFiles.Cursor    = System.Windows.Forms.Cursors.Hand;
            btnResizeSelectFiles.Click    += new System.EventHandler(this.btnResizeSelectFiles_Click);

            lblResizeOutput.Text     = "Pasta de saída:";
            lblResizeOutput.Location = new System.Drawing.Point(20, 270);
            lblResizeOutput.Size     = new System.Drawing.Size(95, 20);

            lblResizeOutputPath.Text         = "Nenhuma pasta selecionada";
            lblResizeOutputPath.Location     = new System.Drawing.Point(120, 270);
            lblResizeOutputPath.Size         = new System.Drawing.Size(420, 20);
            lblResizeOutputPath.ForeColor    = System.Drawing.Color.Gray;
            lblResizeOutputPath.AutoEllipsis = true;

            btnResizeSelectOutput.Text      = "Selecionar Pasta";
            btnResizeSelectOutput.Location  = new System.Drawing.Point(548, 266);
            btnResizeSelectOutput.Size      = new System.Drawing.Size(132, 28);
            btnResizeSelectOutput.BackColor = System.Drawing.Color.FromArgb(76, 75, 99);  // #4C4B63
            btnResizeSelectOutput.ForeColor = System.Drawing.Color.White;
            btnResizeSelectOutput.Font      = new System.Drawing.Font("Segoe UI", 9f);
            btnResizeSelectOutput.Cursor    = System.Windows.Forms.Cursors.Hand;
            btnResizeSelectOutput.Click    += new System.EventHandler(this.btnResizeSelectOutput_Click);

            lblResizeWidth.Text     = "Largura (px):";
            lblResizeWidth.Location = new System.Drawing.Point(20, 314);
            lblResizeWidth.Size     = new System.Drawing.Size(90, 20);

            numResizeWidth.Location  = new System.Drawing.Point(114, 311);
            numResizeWidth.Size      = new System.Drawing.Size(100, 24);
            numResizeWidth.Minimum   = 1; numResizeWidth.Maximum = 99999;
            numResizeWidth.Value     = 1920; numResizeWidth.Increment = 10;

            lblResizeHeight.Text     = "Altura (px):";
            lblResizeHeight.Location = new System.Drawing.Point(240, 314);
            lblResizeHeight.Size     = new System.Drawing.Size(80, 20);

            numResizeHeight.Location  = new System.Drawing.Point(324, 311);
            numResizeHeight.Size      = new System.Drawing.Size(100, 24);
            numResizeHeight.Minimum   = 1; numResizeHeight.Maximum = 99999;
            numResizeHeight.Value     = 1080; numResizeHeight.Increment = 10;

            lblResizeDpi.Text     = "DPI:";
            lblResizeDpi.Location = new System.Drawing.Point(20, 354);
            lblResizeDpi.Size     = new System.Drawing.Size(90, 20);

            numResizeDpi.Location  = new System.Drawing.Point(114, 351);
            numResizeDpi.Size      = new System.Drawing.Size(100, 24);
            numResizeDpi.Minimum   = 1; numResizeDpi.Maximum = 9600;
            numResizeDpi.Value     = 72; numResizeDpi.Increment = 1;

            ActionBtn(btnResize, "Redimensionar", new System.Drawing.Point(545, 347), new System.EventHandler(this.btnResize_Click));

            progressBarResize.Location = new System.Drawing.Point(20, 396);
            progressBarResize.Size     = new System.Drawing.Size(660, 20);

            lblResizeStatus.Text      = "Pronto.";
            lblResizeStatus.Location  = new System.Drawing.Point(20, 424);
            lblResizeStatus.Size      = new System.Drawing.Size(660, 20);
            lblResizeStatus.ForeColor = System.Drawing.Color.DimGray;

            panelResize.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnBackResize, lblResizeFiles, lstResizeFiles, btnResizeSelectFiles,
                lblResizeOutput, lblResizeOutputPath, btnResizeSelectOutput,
                lblResizeWidth, numResizeWidth, lblResizeHeight, numResizeHeight,
                lblResizeDpi, numResizeDpi,
                btnResize, progressBarResize, lblResizeStatus
            });

            // ── Panel Adicionar Prefixo ──────────────────────────────────
            panelPrefix.Bounds    = new System.Drawing.Rectangle(0, 0, 700, 500);
            panelPrefix.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            panelPrefix.Visible   = false;
            panelPrefix.Font      = uiFont;

            BackBtn(btnBackPrefix);

            lblPrefixFiles.Text     = "Imagens selecionadas:";
            lblPrefixFiles.Location = new System.Drawing.Point(20, 48);
            lblPrefixFiles.Size     = new System.Drawing.Size(160, 20);

            lstPrefixFiles.Location            = new System.Drawing.Point(20, 70);
            lstPrefixFiles.Size                = new System.Drawing.Size(660, 200);
            lstPrefixFiles.ScrollAlwaysVisible = true;

            btnPrefixSelectFiles.Text      = "Selecionar Imagens";
            btnPrefixSelectFiles.Location  = new System.Drawing.Point(20, 282);
            btnPrefixSelectFiles.Size      = new System.Drawing.Size(160, 32);
            btnPrefixSelectFiles.BackColor = System.Drawing.Color.FromArgb(76, 75, 99);  // #4C4B63
            btnPrefixSelectFiles.ForeColor = System.Drawing.Color.White;
            btnPrefixSelectFiles.Font      = new System.Drawing.Font("Segoe UI", 9f);
            btnPrefixSelectFiles.Cursor    = System.Windows.Forms.Cursors.Hand;
            btnPrefixSelectFiles.Click    += new System.EventHandler(this.btnPrefixSelectFiles_Click);

            lblPrefixText.Text     = "Prefixo:";
            lblPrefixText.Location = new System.Drawing.Point(20, 334);
            lblPrefixText.Size     = new System.Drawing.Size(55, 20);

            txtPrefix.Location        = new System.Drawing.Point(80, 331);
            txtPrefix.Size            = new System.Drawing.Size(220, 24);
            txtPrefix.PlaceholderText = "Ex: MARCA_";
            txtPrefix.TextChanged    += new System.EventHandler(this.txtPrefix_TextChanged);

            lblPrefixPreview.Text      = "Pré-visualização: —";
            lblPrefixPreview.Location  = new System.Drawing.Point(20, 368);
            lblPrefixPreview.Size      = new System.Drawing.Size(660, 20);
            lblPrefixPreview.ForeColor = System.Drawing.Color.DimGray;

            ActionBtn(btnPrefix, "Aplicar Prefixo", new System.Drawing.Point(545, 327), new System.EventHandler(this.btnPrefix_Click));

            progressBarPrefix.Location = new System.Drawing.Point(20, 400);
            progressBarPrefix.Size     = new System.Drawing.Size(660, 20);

            lblPrefixStatus.Text      = "Pronto.";
            lblPrefixStatus.Location  = new System.Drawing.Point(20, 428);
            lblPrefixStatus.Size      = new System.Drawing.Size(660, 20);
            lblPrefixStatus.ForeColor = System.Drawing.Color.DimGray;

            panelPrefix.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnBackPrefix, lblPrefixFiles, lstPrefixFiles, btnPrefixSelectFiles,
                lblPrefixText, txtPrefix, lblPrefixPreview,
                btnPrefix, progressBarPrefix, lblPrefixStatus
            });

            // ── Form ─────────────────────────────────────────────────────
            Text            = "Image Tools";
            ClientSize      = new System.Drawing.Size(700, 500);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox     = false;
            StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;

            // ordem: background primeiro, painéis por cima
            picBackground.Controls.Add(panelMenu);
            Controls.Add(panelConvert);
            Controls.Add(panelResize);
            Controls.Add(panelPrefix);
            Controls.Add(picBackground);

            ResumeLayout(false);
        }
    }
}
