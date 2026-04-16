using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace ImageConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Botões do menu com arredondamento mínimo
            ApplyRoundedCorners(btnMenuConvert, 2);
            ApplyRoundedCorners(btnMenuResize,  2);
            ApplyRoundedCorners(btnMenuPrefix,  2);
            // Demais botões com arredondamento mínimo
            foreach (var panel in new[] { panelConvert, panelResize, panelPrefix })
                foreach (System.Windows.Forms.Control c in panel.Controls)
                    if (c is System.Windows.Forms.Button btn)
                        ApplyRoundedCorners(btn, 2);
            ShowMenu();
        }

        // ── Navegação ────────────────────────────────────────────────────

        private void ShowMenu()
        {
            panelMenu.Visible    = true;
            panelConvert.Visible = false;
            panelResize.Visible  = false;
            panelPrefix.Visible  = false;
        }

        private void btnMenuConvert_Click(object sender, EventArgs e) { panelMenu.Visible = false; panelConvert.Visible = true; }
        private void btnMenuResize_Click(object sender, EventArgs e)  { panelMenu.Visible = false; panelResize.Visible  = true; }
        private void btnMenuPrefix_Click(object sender, EventArgs e)  { panelMenu.Visible = false; panelPrefix.Visible  = true; }

        private void btnBack_Click(object sender, EventArgs e) => ShowMenu();

        // ── Botões arredondados ──────────────────────────────────────────

        private static void ApplyRoundedCorners(Button btn, int radius)
        {
            btn.Paint += (s, e) =>
            {
                var b    = (Button)s!;
                var rect = new Rectangle(0, 0, b.Width, b.Height);
                using var path  = RoundedRect(rect, radius);
                b.Region = new Region(path);
                using var brush = new SolidBrush(b.BackColor);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(brush, path);
                TextRenderer.DrawText(e.Graphics, b.Text, b.Font, rect, b.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
        }

        private static GraphicsPath RoundedRect(Rectangle b, int r)
        {
            int d = r * 2;
            var p = new GraphicsPath();
            p.AddArc(b.X,             b.Y,              d, d, 180, 90);
            p.AddArc(b.Right - d,     b.Y,              d, d, 270, 90);
            p.AddArc(b.Right - d,     b.Bottom - d,     d, d,   0, 90);
            p.AddArc(b.X,             b.Bottom - d,     d, d,  90, 90);
            p.CloseFigure();
            return p;
        }

        // ── Converter Extensão ───────────────────────────────────────────

        private List<string> _selectedFiles = new();
        private string       _outputFolder  = string.Empty;

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title       = "Selecionar imagens",
                Filter      = "Imagens|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff;*.webp|Todos|*.*",
                Multiselect = true
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _selectedFiles = dlg.FileNames.ToList();
            lstFiles.Items.Clear();
            foreach (var f in _selectedFiles) lstFiles.Items.Add(Path.GetFileName(f));
            lblStatus.Text = $"{_selectedFiles.Count} arquivo(s) selecionado(s).";
        }

        private void btnSelectOutput_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog { Description = "Pasta de destino" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _outputFolder           = dlg.SelectedPath;
            lblOutputPath.Text      = _outputFolder;
            lblOutputPath.ForeColor = Color.Black;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (_selectedFiles.Count == 0) { Warn("Selecione ao menos uma imagem."); return; }
            if (string.IsNullOrEmpty(_outputFolder)) { Warn("Selecione a pasta de saída."); return; }

            string fmt = cmbFormat.SelectedItem?.ToString() ?? "PNG";
            var (imgFmt, ext) = GetFormatInfo(fmt);
            int ok = 0, fail = 0;
            progressBar.Maximum = _selectedFiles.Count;
            progressBar.Value   = 0;

            foreach (var file in _selectedFiles)
            {
                try
                {
                    string dest = Path.Combine(_outputFolder, Path.GetFileNameWithoutExtension(file) + ext);
                    using var img  = Image.FromFile(file);
                    using var out_ = fmt == "JPG" ? ApplyWhiteBackground(img) : img;
                    out_.Save(dest, imgFmt);
                    ok++;
                }
                catch { fail++; }
                finally { progressBar.Value++; Application.DoEvents(); }
            }

            lblStatus.Text = $"Concluído: {ok} convertido(s), {fail} erro(s).";
            Info($"✔ {ok} convertido(s)\n✖ {fail} erro(s)");
        }

        private static Bitmap ApplyWhiteBackground(Image img)
        {
            var bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.DrawImage(img, 0, 0, img.Width, img.Height);
            return bmp;
        }

        private static (ImageFormat f, string ext) GetFormatInfo(string n) => n switch
        {
            "JPG"  => (ImageFormat.Jpeg, ".jpg"),
            "PNG"  => (ImageFormat.Png,  ".png"),
            "BMP"  => (ImageFormat.Bmp,  ".bmp"),
            "GIF"  => (ImageFormat.Gif,  ".gif"),
            "TIFF" => (ImageFormat.Tiff, ".tiff"),
            _      => (ImageFormat.Png,  ".png")
        };

        // ── Redimensionar ────────────────────────────────────────────────

        private List<string> _resizeFiles        = new();
        private string       _resizeOutputFolder = string.Empty;

        private void btnResizeSelectFiles_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title       = "Selecionar imagens",
                Filter      = "Imagens|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff|Todos|*.*",
                Multiselect = true
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _resizeFiles = dlg.FileNames.ToList();
            lstResizeFiles.Items.Clear();
            foreach (var f in _resizeFiles) lstResizeFiles.Items.Add(Path.GetFileName(f));
            lblResizeStatus.Text = $"{_resizeFiles.Count} arquivo(s) selecionado(s).";
        }

        private void btnResizeSelectOutput_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog { Description = "Pasta de destino" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _resizeOutputFolder          = dlg.SelectedPath;
            lblResizeOutputPath.Text      = _resizeOutputFolder;
            lblResizeOutputPath.ForeColor = Color.Black;
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (_resizeFiles.Count == 0) { Warn("Selecione ao menos uma imagem."); return; }
            if (string.IsNullOrEmpty(_resizeOutputFolder)) { Warn("Selecione a pasta de saída."); return; }

            int targetW = (int)numResizeWidth.Value, targetH = (int)numResizeHeight.Value;
            float dpi = (float)numResizeDpi.Value;
            int ok = 0, fail = 0, skipped = 0;
            progressBarResize.Maximum = _resizeFiles.Count;
            progressBarResize.Value   = 0;

            foreach (var file in _resizeFiles)
            {
                try
                {
                    using var img = Image.FromFile(file);
                    string outputPath = Path.Combine(_resizeOutputFolder, Path.GetFileName(file));

                    // Se a imagem já é menor ou igual, apenas copia sem redimensionar
                    if (img.Width <= targetW && img.Height <= targetH)
                    {
                        File.Copy(file, outputPath, overwrite: true);
                        skipped++;
                    }
                    else
                    {
                        // Redimensiona mantendo a proporção
                        using var resized = new Bitmap(targetW, targetH, PixelFormat.Format32bppArgb);
                        resized.SetResolution(dpi, dpi);
                        using (var g = Graphics.FromImage(resized))
                        {
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode     = SmoothingMode.HighQuality;
                            g.PixelOffsetMode   = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                            g.DrawImage(img, 0, 0, targetW, targetH);
                        }
                        resized.Save(outputPath, img.RawFormat);
                    }
                    ok++;
                }
                catch { fail++; }
                finally { progressBarResize.Value++; Application.DoEvents(); }
            }

            lblResizeStatus.Text = $"Concluído: {ok} processado(s) ({skipped} mantido(s)), {fail} erro(s).";
            Info($"✔ {ok} arquivo(s) processado(s)\n→ {skipped} mantido(s) sem redimensionar\n✖ {fail} erro(s)");
        }

        // ── Adicionar Prefixo ────────────────────────────────────────────

        private List<string> _prefixFiles = new();

        private void btnPrefixSelectFiles_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title       = "Selecionar imagens",
                Filter      = "Imagens|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff;*.webp|Todos|*.*",
                Multiselect = true
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _prefixFiles = dlg.FileNames.ToList();
            lstPrefixFiles.Items.Clear();
            foreach (var f in _prefixFiles) lstPrefixFiles.Items.Add(Path.GetFileName(f));
            lblPrefixStatus.Text = $"{_prefixFiles.Count} arquivo(s) selecionado(s).";
            UpdatePrefixPreview();
        }

        private void txtPrefix_TextChanged(object sender, EventArgs e) => UpdatePrefixPreview();

        private void UpdatePrefixPreview()
        {
            string pre = txtPrefix.Text;
            lblPrefixPreview.Text = (_prefixFiles.Count == 0 || string.IsNullOrEmpty(pre))
                ? "Pré-visualização: —"
                : $"Pré-visualização: {pre}{Path.GetFileName(_prefixFiles[0])}";
        }

        private void btnPrefix_Click(object sender, EventArgs e)
        {
            if (_prefixFiles.Count == 0)          { Warn("Selecione ao menos uma imagem."); return; }
            if (string.IsNullOrEmpty(txtPrefix.Text)) { Warn("Digite um prefixo."); return; }

            string pre = txtPrefix.Text;
            int ok = 0, fail = 0;
            progressBarPrefix.Maximum = _prefixFiles.Count;
            progressBarPrefix.Value   = 0;

            foreach (var file in _prefixFiles)
            {
                try
                {
                    string dir     = Path.GetDirectoryName(file)!;
                    string newPath = Path.Combine(dir, pre + Path.GetFileName(file));
                    File.Move(file, newPath, overwrite: false);
                    ok++;
                }
                catch { fail++; }
                finally { progressBarPrefix.Value++; Application.DoEvents(); }
            }

            lblPrefixStatus.Text = $"Concluído: {ok} renomeado(s), {fail} erro(s).";
            // Atualiza a lista com os novos nomes
            lstPrefixFiles.Items.Clear();
            _prefixFiles = _prefixFiles
                .Select(f => Path.Combine(Path.GetDirectoryName(f)!, pre + Path.GetFileName(f)))
                .Where(File.Exists)
                .ToList();
            foreach (var f in _prefixFiles) lstPrefixFiles.Items.Add(Path.GetFileName(f));
            Info($"✔ {ok} arquivo(s) renomeado(s)\n✖ {fail} erro(s)");
        }

        // ── Helpers ──────────────────────────────────────────────────────

        private static void Warn(string msg) =>
            MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static void Info(string msg) =>
            MessageBox.Show(msg, "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
