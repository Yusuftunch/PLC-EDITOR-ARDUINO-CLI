using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GME_PLC_EDITOR
{
    public partial class DEVICE_SELECT : Form
    {
        public DEVICE_SELECT()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog1 = new SaveFileDialog();
            savedialog1.Filter = "GME PLC Editor Code | *.ino";

            if (savedialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.IsPathFullyQualified(savedialog1.FileName))
                {
                    MAIN_PAGE.sketchname = Path.GetFileNameWithoutExtension(savedialog1.FileName);//uzantısız dosya ismi
                    MAIN_PAGE.skectpath = Path.GetDirectoryName(savedialog1.FileName);
                    MAIN_PAGE.sketchname_ext = Path.GetFileName(savedialog1.FileName);
                    //text_in_use();
                    string directorypath = MAIN_PAGE.skectpath + "\\" + MAIN_PAGE.sketchname;
                    Directory.CreateDirectory(directorypath);
                    
                    MAIN_PAGE.fullpath = directorypath + "\\" + Path.GetFileName(savedialog1.FileName); 
                    MAIN_PAGE.sketchname = AppContext.BaseDirectory + "\\Templates\\GEM_PLC_V6.dat";//exe programın çalıştığı dizin
                    MAIN_PAGE.skectpath = directorypath;
                    Thread.Sleep(250);
                    //richTextBox_main.SaveFile(fullpath, RichTextBoxStreamType.PlainText);
                    if (MAIN_PAGE.sketchname != null) //ikinci PLC seçiminde bura güncellenmeli
                    {
                        File.Copy(AppContext.BaseDirectory + "\\Templates\\GEM_PLC_V6.dat", MAIN_PAGE.fullpath);
                        File.Copy(AppContext.BaseDirectory + "\\Library\\GME_PLC_V6.cpp", directorypath + "\\GME_PLC_V6.cpp");
                        File.Copy(AppContext.BaseDirectory + "\\Library\\GME_PLC_V6.h", directorypath + "\\GME_PLC_V6.h");
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
                button_ok.Enabled = true;
            else
            {
                button_ok.Enabled = false;
            }
        }
    }
}
