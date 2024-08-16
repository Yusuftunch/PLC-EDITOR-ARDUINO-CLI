using Microsoft.VisualBasic.Devices;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace GME_PLC_EDITOR
{
    public partial class MAIN_PAGE : Form
    {
        public MAIN_PAGE()
        {
            InitializeComponent();
        }
        public static string sketchname;
        public static string sketchname_ext;
        public static string skectpath;
        public static string fullpath;
        bool changed = false;

        public async Task<bool> ExecuteCommandAsync(string command, bool iscmd)
        {
            string cliPath = AppContext.BaseDirectory + @"ARDUINO-CLI\arduino-cli ";
            string fullCommand = cliPath + command;

            if (iscmd) fullCommand = command;
            AppendMessageToRichTextBox("Command="+fullCommand,Color.Blue, new Font(richTextBox_main.Font, FontStyle.Regular));
            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                UseShellExecute = false,
                Arguments = "/C " + fullCommand
            };

            using (Process cmd = new Process())
            {
                cmd.StartInfo = info;
                string output;
                string error;
                cmd.Start();
                try
                {
                    output = await cmd.StandardOutput.ReadToEndAsync();
                    error = await cmd.StandardError.ReadToEndAsync();
                    cmd.WaitForExit();
                }
                catch (Exception hata)
                {
                    AppendMessageToRichTextBox(hata.ToString(), Color.Red, new Font(richTextBox_main.Font, FontStyle.Italic));
                    return false;

                }

                if (!string.IsNullOrEmpty(output))
                {
                    AppendMessageToRichTextBox(output, Color.Green, new Font(richTextBox_main.Font, FontStyle.Regular));
                }

                if (!string.IsNullOrEmpty(error))
                {
                    AppendMessageToRichTextBox("Error: " + error, Color.Red, new Font(richTextBox_main.Font, FontStyle.Italic));
                    return false;
                }

                return cmd.ExitCode == 0;
            }
        }

        public void AppendMessageToRichTextBox(string message)
        {
            if (richTextBox_mesaj.InvokeRequired)
            {
                richTextBox_mesaj.Invoke(new Action<string>(AppendMessageToRichTextBox), message);
            }
            else
            {
                richTextBox_mesaj.AppendText(message + Environment.NewLine);
            }
        }

        public void AppendMessageToRichTextBox(string message, Color color, Font font)
        {
            if (richTextBox_mesaj.InvokeRequired)
            {
                richTextBox_mesaj.Invoke(new Action<string>(AppendMessageToRichTextBox), message);
            }
            else
            {
                int selectionStart = richTextBox_mesaj.TextLength;
                richTextBox_mesaj.AppendText(message + Environment.NewLine);
                richTextBox_mesaj.SelectionStart = selectionStart;
                richTextBox_mesaj.SelectionLength = message.Length;
                richTextBox_mesaj.SelectionColor = color;
                richTextBox_mesaj.SelectionFont = font;
                richTextBox_mesaj.SelectionLength = 0; // Seçimi temizle
                richTextBox_mesaj.SelectionColor = richTextBox_mesaj.ForeColor; // Varsayýlan metin rengine dön
                richTextBox_mesaj.SelectionFont = richTextBox_mesaj.Font; // Varsayýlan fonta dön
                richTextBox_mesaj.ScrollToCaret();
            }
        }

        private async Task<bool> compile()
        {
            bool success = false;
           // AppendMessageToRichTextBox(fullpath);
            if (fullpath != null)
            {
                string boardoption = "\"" + "clock = 16MHz_external, BOD = 2v7, eeprom = keep, LTO = Os_flto, bootloader = uart0, baudrate = default" + "\"";
                string compileCommand = "compile --fqbn MegaCore:avr:64 --board-options " + boardoption + " " + fullpath + " -e";
                success = await ExecuteCommandAsync(compileCommand, false);
                if (success)
                {
                    AppendMessageToRichTextBox("--------------COMPILE DONE-------------", Color.Green, new Font(richTextBox_main.Font, FontStyle.Bold));
                }
                else
                {
                    AppendMessageToRichTextBox("--------------COMPILE ERROR-------------", Color.Red, new Font(richTextBox_main.Font, FontStyle.Bold));
                }
            }
            else
            {
                AppendMessageToRichTextBox("Please before compile, open a file!", Color.Red, new Font(richTextBox_main.Font, FontStyle.Bold));
            }
            return success;
        }

        private async void bootloader()
        {
            AppendMessageToRichTextBox(fullpath);
            string boardoption = "\"" + "clock = 16MHz_external, BOD = 2v7, eeprom = keep, LTO = Os_flto, bootloader = uart0, baudrate = default" + "\"";
            string compileCommand = "burn-bootloader -p usbasp --fqbn MegaCore:megaavr:atmega64 --board-options " + boardoption;
            bool success = await ExecuteCommandAsync(compileCommand, false);
            if (success)
            {
                AppendMessageToRichTextBox("--------------COMPILE DONE-------------", Color.Green, new Font(richTextBox_main.Font, FontStyle.Bold));
            }
            else
            {
                AppendMessageToRichTextBox("--------------COMPILE ERROR-------------", Color.Red, new Font(richTextBox_main.Font, FontStyle.Bold));
            }
        }
        private async void upload(string PORT, string PROGRAMMER)
        {
            bool compiling=await compile();
            if (compiling)
            {

                if (fullpath != null && File.Exists(fullpath))
                {
                    string uploadCommand = "upload -p " + PORT + " --fqbn MegaCore:avr:64 --programmer " + PROGRAMMER + " " + fullpath;
                    bool success = await ExecuteCommandAsync(uploadCommand, false);
                    if (success)
                    {
                        AppendMessageToRichTextBox("--------------UPLOAD DONE-------------", Color.Green, new Font(richTextBox_main.Font, FontStyle.Bold));
                    }
                    else
                    {
                        AppendMessageToRichTextBox("--------------UPLOAD ERROR-------------", Color.Red, new Font(richTextBox_main.Font, FontStyle.Bold));
                    }
                }
            }
        }

        private async void bootlader(string PORT, string PROGRAMMER)
        {
            string boardoption = "\"" + "clock = 16MHz_external, BOD = 2v7, eeprom = keep, LTO = Os_flto, bootloader = uart0, baudrate = default" + "\"";
            string compileCommand = "burn-bootloader -p " + PORT + " --fqbn MegaCore:avr:64 --programmer " + PROGRAMMER + " --board-options " + boardoption;
            bool success = await ExecuteCommandAsync(compileCommand, false);
            if (success)
            {
                AppendMessageToRichTextBox("--------------BOOTLADER DONE-------------", Color.Green, new Font(richTextBox_main.Font, FontStyle.Bold));
            }
            else
            {
                AppendMessageToRichTextBox("--------------BOOTLADER ERROR-------------", Color.Red, new Font(richTextBox_main.Font, FontStyle.Bold));
            }
        }


        private void text_in_use()
        {
            richTextBox_main.Visible = true;
            menu_edit.Enabled = true;
            richeditboxRefresh(richTextBox_main);
            tabPage1.Text = sketchname_ext;
        }

        private void close_all()
        {
            richTextBox_main.Visible = false;
            menu_edit.Enabled = false;
            menu_tools.Enabled = false;
            for (int i = tabControl1.TabPages.Count - 1; i >= 0; i--)
            {
                if (tabControl1.TabPages[i] != tabPage1)
                {
                    tabControl1.TabPages.RemoveAt(i);
                }
            }
        }

        private void open_all_lib_files()
        {
            string[] cppFiles = Directory.GetFiles(skectpath, "*.cpp");
            string[] hFiles = Directory.GetFiles(skectpath, "*.h");
            string[] allFiles = cppFiles.Concat(hFiles).ToArray();
            foreach (string file in allFiles)
            {
                TabPage tabPage = new TabPage(Path.GetFileName(file))
                {
                    Tag = file // Dosya yolunu Tag özelliðine sakla
                };

                RichTextBox richTextBox = new RichTextBox
                {
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                    Dock = DockStyle.Fill,
                    Text = File.ReadAllText(file)
                };
                setupcolours(richTextBox);
                tabPage.Controls.Add(richTextBox);
                tabControl1.TabPages.Add(tabPage);
            }
        }

        private void save_all_lib_files()
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                if (tabPage == tabPage1) continue;
                RichTextBox richTextBox = tabPage.Controls.OfType<RichTextBox>().FirstOrDefault();
                if (richTextBox != null)
                {
                    string filePath = tabPage.Tag as string;
                    if (filePath != null)
                    {
                        File.WriteAllText(filePath, richTextBox.Text);
                    }
                }
            }
        }



        private void open_file()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "GME PLC Editor Code | *.ino";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sketchname = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                sketchname_ext = Path.GetFileName(openFileDialog1.FileName);
                skectpath = Path.GetDirectoryName(openFileDialog1.FileName);
                fullpath = openFileDialog1.FileName;
                this.Text = fullpath;
                AppendMessageToRichTextBox(fullpath);
                richTextBox_main.LoadFile(fullpath, RichTextBoxStreamType.PlainText);
                text_in_use();
                menu_tools.Enabled = true;
                open_all_lib_files();
            }
        }

        private string[] get_lib_files_names(string sourceDir)
        {
            string[] cppFiles = Directory.GetFiles(sourceDir, "*.cpp");
            string[] headerFiles = Directory.GetFiles(sourceDir, "*.h");
            string[] allFiles = new string[cppFiles.Length + headerFiles.Length];
            cppFiles.CopyTo(allFiles, 0);
            headerFiles.CopyTo(allFiles, cppFiles.Length);
            return allFiles;
        }

        private void copy_all_library(string destinationDir, string[] allFiles)
        {
            foreach (string file in allFiles)
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationDir, fileName);
                File.Copy(file, destFile, true);
            }
        }
        private void save_as_file()
        {
            string[] allFiles = get_lib_files_names(skectpath);
            string old_sketch_path= skectpath;
            SaveFileDialog savedialog1 = new SaveFileDialog();
            savedialog1.Filter = "GME PLC Editor Code | *.ino";
            if (savedialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.IsPathFullyQualified(savedialog1.FileName))
                {
                    sketchname = Path.GetFileNameWithoutExtension(savedialog1.FileName);
                    skectpath = Path.GetDirectoryName(savedialog1.FileName);
                    sketchname_ext = Path.GetFileName(savedialog1.FileName);
                    text_in_use();
                    skectpath = skectpath + "\\" + sketchname;
                    Directory.CreateDirectory(skectpath);
                    string newfullpath = skectpath + "\\" + sketchname + ".ino";
                    
                    File.Copy(fullpath, newfullpath, true);
                    fullpath = newfullpath;
                    copy_all_library(skectpath, allFiles);
                    AppendMessageToRichTextBox("Saved successfully!");
                    AppendMessageToRichTextBox(fullpath);
                    AppendMessageToRichTextBox(skectpath);
                    this.Text = fullpath;
                    skectpath = Path.GetDirectoryName(savedialog1.FileName) + "\\" + sketchname;
                    changed = false;
                }
            }
        }

        private void save_file()
        {
            if (fullpath == null) save_as_file();
            else
            {
                richTextBox_main.SaveFile(fullpath, RichTextBoxStreamType.PlainText);
                AppendMessageToRichTextBox("Saved successfully!");
                AppendMessageToRichTextBox(fullpath);
                sketchname = Path.GetFileNameWithoutExtension(fullpath);
                sketchname_ext = Path.GetFileName(fullpath);
                this.Text = fullpath;
                text_in_use();
                save_all_lib_files();
                changed = false;
            }
        }

        private void HighlightText(RichTextBox rtb, string word, Color color, Font fontum)
        {
            int s_start = rtb.SelectionStart, startIndex = 0, index;

            while ((index = rtb.Text.IndexOf(word, startIndex, StringComparison.CurrentCultureIgnoreCase)) != -1)
            {
                rtb.Select(index, word.Length);
                rtb.SelectionColor = color;
                rtb.SelectionFont = fontum;

                startIndex = index + word.Length;
            }

            rtb.SelectionStart = s_start;
            rtb.SelectionLength = 0;
            rtb.SelectionColor = Color.White;
        }

        private void HighlightComments(RichTextBox rtb, string commentStart, Color color)
        {
            int s_start = rtb.SelectionStart, startIndex = 0, index;

            while ((index = rtb.Text.IndexOf(commentStart, startIndex)) != -1)
            {
                int endIndex = rtb.Text.IndexOf('\n', index);
                if (endIndex == -1) endIndex = rtb.Text.Length;

                rtb.Select(index, endIndex - index);
                rtb.SelectionColor = color;
                rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Italic);

                startIndex = endIndex;
            }

            rtb.SelectionStart = s_start;
            rtb.SelectionLength = 0;
            rtb.SelectionColor = Color.White;
        }

        private string[] keywords = { "Delay", "digitalWrite", "digitalRead", "HIGH", "LOW", "switch", "case", "for", "break", "do", "if", "else", "elsif", "#define", "pinMode", "#include" };

        void setupcolours(RichTextBox richTextBox)
        {
            // Tüm anahtar kelimeleri vurgula
            foreach (var keyword in keywords)
            {
                HighlightText(richTextBox, keyword, Color.YellowGreen, new Font(richTextBox_main.SelectionFont, FontStyle.Italic));
            }
            HighlightText(richTextBox, "setup", Color.PaleGreen, new Font(richTextBox_main.SelectionFont, FontStyle.Italic));
            HighlightText(richTextBox, "loop", Color.PaleGreen, new Font(richTextBox_main.SelectionFont, FontStyle.Italic));
            HighlightText(richTextBox, "{", Color.White, new Font(richTextBox_main.SelectionFont, FontStyle.Regular));
            HighlightText(richTextBox, "}", Color.White, new Font(richTextBox_main.SelectionFont, FontStyle.Regular));
            HighlightText(richTextBox, ")", Color.Blue, new Font(richTextBox_main.SelectionFont, FontStyle.Regular));
            HighlightText(richTextBox, "(", Color.Blue, new Font(richTextBox_main.SelectionFont, FontStyle.Regular));
            HighlightText(richTextBox, "void", Color.Orange, new Font(richTextBox_main.SelectionFont, FontStyle.Italic));
            HighlightComments(richTextBox, "//", Color.Gray);
        }

        void richeditboxRefresh(RichTextBox richTextBox)
        {
            //richeditbox refresh
            richTextBox.SuspendLayout();
            int originalSelectionStart = richTextBox_main.SelectionStart;
            int originalSelectionLength = richTextBox_main.SelectionLength;
            setupcolours(richTextBox_main);
            richTextBox.SelectionStart = originalSelectionStart;
            richTextBox.SelectionLength = originalSelectionLength;
            richTextBox.ResumeLayout();
        }

        void RefreshCurrentLine()
        {
            // Suspend the layout to avoid flickering
            richTextBox_main.SuspendLayout();

            int originalSelectionStart = richTextBox_main.SelectionStart;
            int originalSelectionLength = richTextBox_main.SelectionLength;

            // Find the start of the current line
            int lineStart = richTextBox_main.GetFirstCharIndexOfCurrentLine();
            int lineEnd = richTextBox_main.Text.IndexOf('\n', lineStart);
            if (lineEnd == -1) lineEnd = richTextBox_main.Text.Length;

            // Extract the line text
            string currentLineText = richTextBox_main.Text.Substring(lineStart, lineEnd - lineStart);

            // Clear the formatting for the current line
            richTextBox_main.Select(lineStart, lineEnd - lineStart);
            richTextBox_main.SelectionColor = Color.White;
            richTextBox_main.SelectionFont = new Font(richTextBox_main.SelectionFont, FontStyle.Regular);

            // Apply highlighting to the current line
            foreach (var keyword in keywords)
            {
                int index;
                int startIndex = 0;
                while ((index = currentLineText.IndexOf(keyword, startIndex, StringComparison.CurrentCultureIgnoreCase)) != -1)
                {
                    richTextBox_main.Select(lineStart + index, keyword.Length);
                    richTextBox_main.SelectionColor = Color.YellowGreen;
                    richTextBox_main.SelectionFont = new Font(richTextBox_main.SelectionFont, FontStyle.Italic);
                    startIndex = index + keyword.Length;
                }
            }

            // Additional highlighting for specific words and characters
            string[] specialWords = { "setup", "loop", "void" };
            Color[] specialColors = { Color.PaleGreen, Color.PaleGreen, Color.Orange };
            for (int i = 0; i < specialWords.Length; i++)
            {
                int index;
                int startIndex = 0;
                while ((index = currentLineText.IndexOf(specialWords[i], startIndex, StringComparison.CurrentCultureIgnoreCase)) != -1)
                {
                    richTextBox_main.Select(lineStart + index, specialWords[i].Length);
                    richTextBox_main.SelectionColor = specialColors[i];
                    richTextBox_main.SelectionFont = new Font(richTextBox_main.SelectionFont, FontStyle.Italic);
                    startIndex = index + specialWords[i].Length;
                }
            }

            char[] specialChars = { '{', '}', '(', ')', '[', ']' };
            Color[] charColors = { Color.White, Color.White, Color.Blue, Color.Blue, Color.Orange };
            foreach (char specialChar in specialChars)
            {
                int index = currentLineText.IndexOf(specialChar);
                if (index != -1)
                {
                    richTextBox_main.Select(lineStart + index, 1);
                    richTextBox_main.SelectionColor = charColors[Array.IndexOf(specialChars, specialChar)];
                    richTextBox_main.SelectionFont = new Font(richTextBox_main.SelectionFont, FontStyle.Regular);
                }
            }

            // Highlight comments
            int commentIndex = currentLineText.IndexOf("//");
            if (commentIndex != -1)
            {
                richTextBox_main.Select(lineStart + commentIndex, currentLineText.Length - commentIndex);
                richTextBox_main.SelectionColor = Color.Gray;
                richTextBox_main.SelectionFont = new Font(richTextBox_main.SelectionFont, FontStyle.Italic);
            }

            // Restore the original selection
            richTextBox_main.SelectionStart = originalSelectionStart;
            richTextBox_main.SelectionLength = originalSelectionLength;
            richTextBox_main.SelectionColor = Color.White;

            // Resume the layout
            richTextBox_main.ResumeLayout();
        }

        private void resetasnew()
        {
            sketchname = "";
            skectpath = "";
            fullpath = null;
            richTextBox_main.Visible = false;
            richTextBox_mesaj.Clear();
            changed = false;
            sketchname_ext = "";
            text_in_use();
        }

        private void close_editor(bool isexit)
        {
            if (changed)
            {
                DialogResult dialogResult = MessageBox.Show("Save File:", "File not Saved!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    save_file();
                }
                else if (dialogResult == DialogResult.No)
                {
                    resetasnew();
                    richTextBox_main.Clear();
                }
            }
            if (isexit) Application.Exit();
            resetasnew();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                IndentSelection();
                return true; // Tab tuþunu iþlediðimizi belirtmek için true döneriz
            }
            else if (keyData == (Keys.Shift | Keys.Tab))
            {
                OutdentSelection();
                return true; // Shift+Tab tuþunu iþlediðimizi belirtmek için true döneriz
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void IndentSelection()
        {
            int start = richTextBox_main.SelectionStart;
            int length = richTextBox_main.SelectionLength;

            // Seçili metni al
            string selectedText = richTextBox_main.SelectedText;

            // Satýrlarý ayýr ve her satýrýn baþýna bir sekme ekle
            var lines = selectedText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = "\t" + lines[i];
            }

            // Satýrlarý birleþtir ve deðiþtirilmiþ metni geri koy
            string indentedText = string.Join("\n", lines);
            richTextBox_main.SelectedText = indentedText;

            // Seçimi korumak için SelectionStart ve SelectionLength'i ayarla
            richTextBox_main.SelectionStart = start;
            richTextBox_main.SelectionLength = indentedText.Length;
        }
        private void OutdentSelection()
        {
            int start = richTextBox_main.SelectionStart;
            int length = richTextBox_main.SelectionLength;

            // Seçili metni al
            string selectedText = richTextBox_main.SelectedText;

            // Satýrlarý ayýr ve her satýrýn baþýndaki sekmeleri kaldýr
            var lines = selectedText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("\t"))
                {
                    lines[i] = lines[i].Substring(1);
                }
            }

            // Satýrlarý birleþtir ve deðiþtirilmiþ metni geri koy
            string outdentedText = string.Join("\n", lines);
            richTextBox_main.SelectedText = outdentedText;

            // Seçimi korumak için SelectionStart ve SelectionLength'i ayarla
            richTextBox_main.SelectionStart = start;
            richTextBox_main.SelectionLength = outdentedText.Length;
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (changed)
            {
                DialogResult dialogResult = MessageBox.Show("Save File:", "File not Saved!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    save_file();
                }
            } else
                open_file();
        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (fullpath != null)
                save_file();
            else
                save_as_file();            
            menu_tools.Enabled = true;
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_as_file();
            changed = false;
            menu_tools.Enabled = true;
        }
        private void closeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            close_editor(false);
            resetasnew();
            close_all();
        }
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            close_editor(true);
            menu_tools.Enabled = false;
        }
        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_mesaj.Clear();
            if (changed)
            {
                DialogResult dialogResult = MessageBox.Show("Save File:", "File not Saved!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    save_file();
                    compile();
                }
            } else
                compile();

        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_main.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_main.Paste();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox_main.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox_main.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox_main.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_main.SelectAll();
        }


        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox_main.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_main.Cut();
        }

        private void forLoopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_main.SelectedText = "for (int i=0; i<=16; i++) \r\n {\r\n  i++; \r\n }" + System.Environment.NewLine;
        }

        private void richTextBox_main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true; // Tab tuþunun varsayýlan davranýþýný engeller
                richTextBox_main.SelectedText = "\t"; // Sekme karakteri ekler
            }
            changed = true;
        }

        private void ChangeFontSize(int delta)
        {
            // Seçili metin varsa sadece seçili metnin boyutunu deðiþtir
            if (richTextBox_main.SelectionLength > 0)
            {
                ChangeSelectedTextFontSize(delta);
            }
            else
            {
                // Seçili metin yoksa tüm metnin boyutunu deðiþtir
                richTextBox_main.Font = new System.Drawing.Font(richTextBox_main.Font.FontFamily, richTextBox_main.Font.Size + delta);
            }
        }

        private void ChangeSelectedTextFontSize(int delta)
        {
            int selectionStart = richTextBox_main.SelectionStart;
            int selectionLength = richTextBox_main.SelectionLength;
            string selectedText = richTextBox_main.SelectedText;

            richTextBox_main.SelectionStart = selectionStart;
            richTextBox_main.SelectionLength = 0;

            for (int i = selectionStart; i < selectionStart + selectionLength; i++)
            {
                richTextBox_main.Select(i, 1);
                var currentFont = richTextBox_main.SelectionFont;
                var newFontSize = currentFont.Size + delta;
                if (newFontSize > 0)
                {
                    richTextBox_main.SelectionFont = new System.Drawing.Font(currentFont.FontFamily, newFontSize, currentFont.Style);
                }
            }

            richTextBox_main.SelectionStart = selectionStart;
            richTextBox_main.SelectionLength = selectionLength;
        }


        private async void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            richTextBox_mesaj.Clear();
            bool success=false;
            if (changed)
            {
                DialogResult dialogResult = MessageBox.Show("Save File:", "File not Saved!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    save_file();
                    success=await compile();
                }
            }
            else
                success = await compile();
            if (success) 
            upload("usb", "usbasp");
        }

        private void ifelsetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_main.SelectedText = "if (condition) {\r\n  // Code to be executed if the condition is true\r\n} else {\r\n  // Code to be executed if the condition is false\r\n}" + System.Environment.NewLine;
        }

        private void switchcasetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_main.SelectedText = "switch (var) {\r\n  case label1:\r\n    // statements\r\n    break;\r\n  case label2:\r\n    // statements\r\n    break;\r\n  default:\r\n    // statements\r\n    break;\r\n}" + System.Environment.NewLine;
        }

        private void doWhileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_main.SelectedText = "do {\r\n  // statement block\r\n} while (condition);" + System.Environment.NewLine;
        }


        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            bootlader("usb", "usbasp");
        }

        private async void cmd_cli(string command, string successed_msg, string fail_msg, bool is_cmd)
        {
            bool success = await ExecuteCommandAsync(command, is_cmd);
            if (success)
            {
                AppendMessageToRichTextBox("--------------" + successed_msg + "-------------", Color.Green, new Font(richTextBox_main.Font, FontStyle.Bold));
            }
            else
            {
                AppendMessageToRichTextBox("--------------" + fail_msg + "-------------", Color.Red, new Font(richTextBox_main.Font, FontStyle.Bold));
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            cmd_cli("version", "CMD DONE", "ERROR", false);
        }

        private void cLIHELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmd_cli("help", "CMD DONE", "ERROR", false);
        }

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmd_cli(toolStripTextBox2.Text, "CMD DONE", "ERROR", true);
            }
        }

        private void toolStripTextBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmd_cli(toolStripTextBox1.Text, "CLI CMD DONE", "ERROR", false);
            }
        }


        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            AppendMessageToRichTextBox("Wait a approximately 5 minutes, if it's not already setup", Color.Yellow, new Font(richTextBox_main.Font, FontStyle.Bold));
            string command = "core install MicroCore:avr --additional-urls https://mcudude.github.io/MicroCore/package_MCUdude_MicroCore_index.json";
            cmd_cli(command, "CMD DONE", "ERROR", false);
        }

        private void richTextBox_main_KeyPress(object sender, KeyPressEventArgs e)
        {
            changed = true;
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            IO_PAGE tag_page = new IO_PAGE();
            IO_PAGE.full_path = skectpath;
            if (tag_page.ShowDialog() == DialogResult.OK)
            {
                //tag oluþtur.
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richeditboxRefresh(richTextBox_main);
        }

        private void richTextBox_main_TextChanged(object sender, EventArgs e)
        {
            RefreshCurrentLine();
        }

        private void toolStripMenuItem_megacore_Click(object sender, EventArgs e)
        {
            AppendMessageToRichTextBox("Wait a approximately 5 minutes, if it's not already setup", Color.Yellow, new Font(richTextBox_main.Font, FontStyle.Bold));
            string command = "core install MegaCore:avr --additional-urls https://mcudude.github.io/MegaCore/package_MCUdude_MegaCore_index.json";
            cmd_cli(command, "CMD DONE", "ERROR", false);
        }

        private void toolStripMenuItem_setfont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox_main.SelectionFont;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox_main.SelectionFont = fontDialog1.Font;
            }
        }

        private void toolStripMenuItem15_Click_1(object sender, EventArgs e)
        {
            richTextBox_mesaj.Clear();
            bootlader("usb", "usbasp_slow");
        }

        private void toolStripMenuItem_new_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                close_editor(true);
                menu_tools.Enabled = false;
                save_file();//yes no sorulacak
                Thread.Sleep(250);
            }

            DEVICE_SELECT deviceselect = new DEVICE_SELECT();
            if (deviceselect.ShowDialog()==DialogResult.OK)
            {
                text_in_use();
                richTextBox_main.LoadFile(fullpath, RichTextBoxStreamType.PlainText);
                setupcolours(richTextBox_main);
                open_all_lib_files();
            }

        }

        private void MAIN_PAGE_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed)
            {
                DialogResult dialogResult = MessageBox.Show("Save File:", "File not Saved!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    save_file();
                }
            }
        }

    }
}

