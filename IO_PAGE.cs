using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GME_PLC_EDITOR
{
    public partial class IO_PAGE : Form
    {
        public static string full_path;
        public static string file_name;

        List<IO_TAGS> all_io = new List<IO_TAGS>();
        public IO_PAGE()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IO_TAGS iolar = new IO_TAGS();
            iolar.INPUT1 = textBox_I1.Text;
            iolar.INPUT2 = textBox_I2.Text;
            iolar.INPUT3 = textBox_I3.Text;
            iolar.INPUT4 = textBox_I4.Text;
            iolar.INPUT5 = textBox_I5.Text;
            iolar.INPUT6 = textBox_I6.Text;
            iolar.INPUT7 = textBox_I7.Text;
            iolar.INPUT8 = textBox_I8.Text;
            iolar.INPUT9 = textBox_I9.Text;
            iolar.INPUT10 = textBox_I10.Text;
            iolar.INPUT11 = textBox_I11.Text;
            iolar.INPUT12 = textBox_I12.Text;
            iolar.INPUT13 = textBox_I13.Text;
            iolar.INPUT14 = textBox_I14.Text;
            iolar.INPUT15 = textBox_I15.Text;
            iolar.INPUT16 = textBox_I16.Text;
            iolar.OUTPUT1 = textBox_Q1.Text;
            iolar.OUTPUT2 = textBox_Q2.Text;
            iolar.OUTPUT3 = textBox_Q3.Text;
            iolar.OUTPUT4 = textBox_Q4.Text;
            iolar.OUTPUT5 = textBox_Q5.Text;
            iolar.OUTPUT6 = textBox_Q6.Text;
            iolar.OUTPUT7 = textBox_Q7.Text;
            iolar.OUTPUT8 = textBox_Q8.Text;
            iolar.OUTPUT9 = textBox_Q9.Text;
            iolar.OUTPUT10 = textBox_Q10.Text;
            iolar.OUTPUT11 = textBox_Q11.Text;
            iolar.OUTPUT12 = textBox_Q12.Text;
            iolar.OUTPUT13 = textBox_Q13.Text;
            iolar.OUTPUT14 = textBox_Q14.Text;
            iolar.OUTPUT15 = textBox_Q15.Text;
            iolar.OUTPUT16 = textBox_Q16.Text;
            open_save_file_xml.io_tags.Add(iolar);
            CPP_OLUSTUR(iolar);
            h_dosyasini_olustur(iolar);
            open_save_file_xml.Serialize(open_save_file_xml.io_tags, full_path + "\\IO_NAMES.dat");
            Close();
        }

        void CPP_OLUSTUR(IO_TAGS iolar)
        {
            RichTextBox richeditbox = new RichTextBox();
            richeditbox.Clear();
            richeditbox.AppendText("#include \"GME_PLC_V6.h\"\r\n");
            richeditbox.AppendText("#include <Arduino.h>\r\n");
            richeditbox.AppendText("\r\n");
            richeditbox.AppendText("//PINS\r\n");
            richeditbox.AppendText("//INPUT PINS\r\n");
            richeditbox.AppendText("#define INPIN1   30 //PC2\r\n");
            richeditbox.AppendText("#define INPIN2   31 //PC3\r\n");
            richeditbox.AppendText("#define INPIN3   32 //PC4\r\n");
            richeditbox.AppendText("#define INPIN4   33 //PC5\r\n");
            richeditbox.AppendText("#define INPIN5   34 //PC6\r\n");
            richeditbox.AppendText("#define INPIN6   35 //PC7\r\n");
            richeditbox.AppendText("#define INPIN7   50 //PF5\r\n");
            richeditbox.AppendText("#define INPIN8   49 //PF4\r\n");
            richeditbox.AppendText("#define INPIN9   48 //PF3\r\n");
            richeditbox.AppendText("#define INPIN10  47 //PF2\r\n");
            richeditbox.AppendText("#define INPIN11  46 //PF1\r\n");
            richeditbox.AppendText("#define INPIN12  45 //PF0\r\n");
            richeditbox.AppendText("#define INPIN13  2  //PE2\r\n");
            richeditbox.AppendText("#define INPIN14  3  //PE3\r\n");
            richeditbox.AppendText("#define INPIN15  4  //PE4\r\n");
            richeditbox.AppendText("#define INPIN16  5  //PE5\r\n");
            richeditbox.AppendText("\r\n");
            //OUTPUT PINS
            richeditbox.AppendText("#define OUTPIN1   29  //PC1\r\n");
            richeditbox.AppendText("#define OUTPIN2   28  //PC0\r\n");
            richeditbox.AppendText("#define OUTPIN3   27  //PG1\r\n");
            richeditbox.AppendText("#define OUTPIN4   26  //PG0\r\n");
            richeditbox.AppendText("#define OUTPIN5   25  //PD7\r\n");
            richeditbox.AppendText("#define OUTPIN6   24  //PD6\r\n");
            richeditbox.AppendText("#define OUTPIN7   23  //PD5\r\n");
            richeditbox.AppendText("#define OUTPIN8   22  //PD4\r\n");
            richeditbox.AppendText("#define OUTPIN9   17  //PG4\r\n");
            richeditbox.AppendText("#define OUTPIN10  16  //PG3\r\n");
            richeditbox.AppendText("#define OUTPIN11  15  //PB7\r\n");
            richeditbox.AppendText("#define OUTPIN12  14  //PB6\r\n");
            richeditbox.AppendText("#define OUTPIN13  13  //PB5\r\n");
            richeditbox.AppendText("#define OUTPIN14  12  //PB4\r\n");
            richeditbox.AppendText("#define OUTPIN15  7   //PE7\r\n");
            richeditbox.AppendText("#define OUTPIN16  6   //PE6\r\n");
            richeditbox.AppendText("#define OUTENPIN  38  //PA6\r\n");
            richeditbox.AppendText("#define PLCRUN   51   //PF6---A6\r\n");
            richeditbox.AppendText("\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT1 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT2 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT3 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT4 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT5 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT6 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT7 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT8 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT9 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT10 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT11 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT12 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT13 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT14 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT15 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.INPUT16 + ";\r\n");
            richeditbox.AppendText("\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT1 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT2 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT3 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT4 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT5 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT6 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT7 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT8 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT9 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT10 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT11 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT12 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT13 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT14 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT15 + ";\r\n");
            richeditbox.AppendText("bool " + iolar.OUTPUT16 + ";\r\n");
            richeditbox.AppendText("\r\n");
            richeditbox.AppendText("void PLC_IO_SETUP()\r\n");
            richeditbox.AppendText("{\r\n");
            richeditbox.AppendText("pinMode(INPIN1,  INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN2,  INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN3,  INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN4,  INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN5,  INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN6,  INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN7,  INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN8,  INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN9,  INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN10, INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN11, INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN12, INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN13, INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN14, INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN15, INPUT);\r\n");
            richeditbox.AppendText("pinMode(INPIN16, INPUT);\r\n");
            richeditbox.AppendText("\r\n");
            richeditbox.AppendText("pinMode(OUTPIN1,  OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN2,  OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN3,  OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN4,  OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN5,  OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN6,  OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN7,  OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN8,  OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN9,  OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN10, OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN11, OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN12, OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN13, OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN14, OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN15, OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTPIN16, OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(PLCRUN, OUTPUT);\r\n");
            richeditbox.AppendText("pinMode(OUTENPIN, OUTPUT);\r\n");
            richeditbox.AppendText("}\n");
            richeditbox.AppendText("\r\n");

            richeditbox.AppendText("///IO SYNC\n");
            richeditbox.AppendText("void IO_SYNC()\n");
            richeditbox.AppendText("{\n");            //INPUTLAR

            richeditbox.AppendText(iolar.INPUT1 + "=digitalRead(INPIN1);\n");
            richeditbox.AppendText(iolar.INPUT2 + "=digitalRead(INPIN2);\n");
            richeditbox.AppendText(iolar.INPUT3 + "=digitalRead(INPIN3);\n");
            richeditbox.AppendText(iolar.INPUT4 + "=digitalRead(INPIN4);\n");
            richeditbox.AppendText(iolar.INPUT5 + "=digitalRead(INPIN5);\n");
            richeditbox.AppendText(iolar.INPUT6 + "=digitalRead(INPIN6);\n");
            richeditbox.AppendText(iolar.INPUT7 + "=digitalRead(INPIN7);\n");
            richeditbox.AppendText(iolar.INPUT8 + "=digitalRead(INPIN8);\n");
            richeditbox.AppendText(iolar.INPUT9 + "=digitalRead(INPIN9);\n");
            richeditbox.AppendText(iolar.INPUT10 + "=digitalRead(INPIN10);\n");
            richeditbox.AppendText(iolar.INPUT11 + "=digitalRead(INPIN11);\n");
            richeditbox.AppendText(iolar.INPUT12 + "=digitalRead(INPIN12);\n");
            richeditbox.AppendText(iolar.INPUT13 + "=digitalRead(INPIN13);\n");
            richeditbox.AppendText(iolar.INPUT14 + "=digitalRead(INPIN14);\n");
            richeditbox.AppendText(iolar.INPUT15 + "=digitalRead(INPIN15);\n");
            richeditbox.AppendText(iolar.INPUT16 + "=digitalRead(INPIN16);\n");

            //OUTPUTLAR
            richeditbox.AppendText("digitalWrite(OUTPIN1," + iolar.OUTPUT1 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN2," + iolar.OUTPUT2 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN3," + iolar.OUTPUT3 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN4," + iolar.OUTPUT4 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN5," + iolar.OUTPUT5 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN6," + iolar.OUTPUT6 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN7," + iolar.OUTPUT7 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN8," + iolar.OUTPUT8 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN9," + iolar.OUTPUT9 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN10," + iolar.OUTPUT10 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN11," + iolar.OUTPUT11 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN12," + iolar.OUTPUT12 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN13," + iolar.OUTPUT13 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN14," + iolar.OUTPUT14 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN15," + iolar.OUTPUT15 + ");\n");
            richeditbox.AppendText("digitalWrite(OUTPIN16," + iolar.OUTPUT16 + ");\n");
            richeditbox.AppendText("}\n");
            richeditbox.SaveFile(full_path + "\\GME_PLC_V6.cpp", RichTextBoxStreamType.PlainText);

        }

        void h_dosyasini_olustur(IO_TAGS iolar)
        {
            RichTextBox richeditbox = new RichTextBox();
            richeditbox.Clear();
            richeditbox.AppendText("#ifndef GME_PLC_V6_H\r\n");
            richeditbox.AppendText("#define GME_PLC_V6_H\r\n");
            richeditbox.AppendText("\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT1 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT2 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT3 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT4 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT5 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT6 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT7 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT8 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT9 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT10 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT11 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT12 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT13 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT14 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT15 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.INPUT16 + ";\r\n");
            richeditbox.AppendText("\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT1 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT2 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT3 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT4 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT5 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT6 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT7 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT8 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT9 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT10 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT11 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT12 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT13 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT14 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT15 + ";\r\n");
            richeditbox.AppendText("extern bool " + iolar.OUTPUT16 + ";\r\n");
            richeditbox.AppendText("\r\n");
            richeditbox.AppendText("void PLC_IO_SETUP();\r\n");
            richeditbox.AppendText("void IO_SYNC();\r\n");
            richeditbox.AppendText("#endif\r\n");
            richeditbox.SaveFile(full_path + "\\GME_PLC_V6.h", RichTextBoxStreamType.PlainText);
        }

        private void IO_PAGE_Load(object sender, EventArgs e)
        {
            if (File.Exists(full_path + "\\IO_NAMES.dat"))
            {
                all_io = open_save_file_xml.Deserialize(full_path + "\\IO_NAMES.dat");
                IO_TAGS iolar = new IO_TAGS();
                iolar = all_io[0];
                textBox_I1.Text = iolar.INPUT1;
                textBox_I2.Text = iolar.INPUT2;
                textBox_I3.Text = iolar.INPUT3;
                textBox_I4.Text = iolar.INPUT4;
                textBox_I5.Text = iolar.INPUT5;
                textBox_I6.Text = iolar.INPUT6;
                textBox_I7.Text = iolar.INPUT7;
                textBox_I8.Text = iolar.INPUT8;
                textBox_I9.Text = iolar.INPUT9;
                textBox_I10.Text = iolar.INPUT10;
                textBox_I11.Text = iolar.INPUT11;
                textBox_I12.Text = iolar.INPUT12;
                textBox_I13.Text = iolar.INPUT13;
                textBox_I14.Text = iolar.INPUT14;
                textBox_I15.Text = iolar.INPUT15;
                textBox_I16.Text = iolar.INPUT16;
                textBox_Q1.Text  = iolar.OUTPUT1;
                textBox_Q2.Text  = iolar.OUTPUT2;
                textBox_Q3.Text  = iolar.OUTPUT3;
                textBox_Q4.Text  = iolar.OUTPUT4;
                textBox_Q5.Text  = iolar.OUTPUT5;
                textBox_Q6.Text  = iolar.OUTPUT6;
                textBox_Q7.Text  = iolar.OUTPUT7;
                textBox_Q8.Text  = iolar.OUTPUT8;
                textBox_Q9.Text  = iolar.OUTPUT9;
                textBox_Q10.Text = iolar.OUTPUT10;
                textBox_Q11.Text = iolar.OUTPUT11;
                textBox_Q12.Text = iolar.OUTPUT12;
                textBox_Q13.Text = iolar.OUTPUT13;
                textBox_Q14.Text = iolar.OUTPUT14;
                textBox_Q15.Text = iolar.OUTPUT15;
                textBox_Q16.Text = iolar.OUTPUT16;
            }
        }
    }
}
