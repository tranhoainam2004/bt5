using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soanthaovanban
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.ForeColor = fontDlg.Color;
                richText.Font = fontDlg.Font;
            }
        }

        private void cmbFonts_Click(object sender, EventArgs e)
        {
            if (cmbFonts.SelectedItem != null)
            {
                string fontName = cmbFonts.SelectedItem.ToString();

                if (richText.SelectionFont != null)
                {
                    richText.SelectionFont = new Font(fontName, richText.SelectionFont.Size, richText.SelectionFont.Style);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbFonts.Text = "Tahoma";
            cmbSize.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                cmbFonts.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                cmbSize.Items.Add(s);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richText.Clear();
            richText.Font = new Font("Tahoma", 14);


            richText.ForeColor = Color.Black;
            richText.BackColor = Color.White;
            cmbFonts.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = 14;
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Clear();
            richText.Font = new Font("Tahoma", 14);


            richText.ForeColor = Color.Black;
            richText.BackColor = Color.White;
            cmbFonts.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = 14;
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
                openFileDialog.Title = "Mở Tập Tin Văn Bản";


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string filePath = openFileDialog.FileName;


                    if (filePath.EndsWith(".txt"))
                    {
                        richText.LoadFile(filePath, RichTextBoxStreamType.PlainText);
                    }
                    else if (filePath.EndsWith(".rtf"))
                    {
                        richText.LoadFile(filePath, RichTextBoxStreamType.RichText);
                    }
                }
            }
        }
        private bool isNewDocument = true;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (isNewDocument)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {

                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";
                    saveFileDialog.Title = "Lưu Tập Tin Văn Bản";
                    saveFileDialog.DefaultExt = "rtf";


                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        richText.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                        isNewDocument = false;
                        MessageBox.Show("Lưu văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {

                MessageBox.Show("Văn bản đã được lưu trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool NewDocument = true;
        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewDocument)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {

                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";
                    saveFileDialog.Title = "Lưu Tập Tin Văn Bản";
                    saveFileDialog.DefaultExt = "rtf";


                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        richText.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                        isNewDocument = false;
                        MessageBox.Show("Lưu văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {

                MessageBox.Show("Văn bản đã được lưu trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                Font currentFont = richText.SelectionFont;
                FontStyle newFontStyle;

                if (currentFont.Bold)
                {
                    newFontStyle = currentFont.Style & ~FontStyle.Bold;
                }
                else
                {
                    newFontStyle = currentFont.Style | FontStyle.Bold;
                }

                richText.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Font currentFont = richText.SelectionFont;

            if (currentFont == null)
            {
                richText.SelectionFont = new Font(richText.Font.FontFamily, richText.Font.Size, FontStyle.Italic);
                return;
            }

            FontStyle newFontStyle;


            if (currentFont.Italic)
            {
                newFontStyle = currentFont.Style & ~FontStyle.Italic;
            }
            else
            {
                newFontStyle = currentFont.Style | FontStyle.Italic;
            }

            richText.SelectionFont = new Font(currentFont, newFontStyle);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (cmbFonts.SelectedItem != null)
            {
                string fontName = cmbFonts.SelectedItem.ToString();

                if (richText.SelectionFont != null)
                {
                    richText.SelectionFont = new Font(fontName, richText.SelectionFont.Size, richText.SelectionFont.Style);
                }
                else
                {
                    richText.Font = new Font(fontName, richText.Font.Size, richText.Font.Style);
                }
            }
        }

        private void cmbSize_Click(object sender, EventArgs e)
        {
            if (cmbSize.SelectedItem != null)
            {
                float fontSize;
                if (float.TryParse(cmbSize.SelectedItem.ToString(), out fontSize))
                {
                    
                    if (richText.SelectionFont != null)
                    {
                        richText.SelectionFont = new Font(richText.SelectionFont.FontFamily, fontSize, richText.SelectionFont.Style);
                    }
                }
            }
        }
    }
}

