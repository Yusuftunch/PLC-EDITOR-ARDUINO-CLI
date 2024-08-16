namespace GME_PLC_EDITOR
{
    partial class MAIN_PAGE
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAIN_PAGE));
            contextMenuStrip1 = new ContextMenuStrip(components);
            cutToolStripMenuItem1 = new ToolStripMenuItem();
            copyToolStripMenuItem1 = new ToolStripMenuItem();
            pasteToolStripMenuItem1 = new ToolStripMenuItem();
            selectAllToolStripMenuItem1 = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            fontDialog1 = new FontDialog();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem_new = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripSeparator5 = new ToolStripSeparator();
            closeToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menu_edit = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripMenuItem_setfont = new ToolStripMenuItem();
            addToolStripMenuItem = new ToolStripMenuItem();
            forLoopToolStripMenuItem = new ToolStripMenuItem();
            ifelsetoolStripMenuItem = new ToolStripMenuItem();
            switchcasetoolStripMenuItem = new ToolStripMenuItem();
            doWhileToolStripMenuItem = new ToolStripMenuItem();
            menu_tools = new ToolStripMenuItem();
            compileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem15 = new ToolStripMenuItem();
            toolStripMenuItem16 = new ToolStripMenuItem();
            komutToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            toolStripTextBox2 = new ToolStripTextBox();
            toolStripMenuItem12 = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStripMenuItem14 = new ToolStripMenuItem();
            toolStripMenuItem_megacore = new ToolStripMenuItem();
            toolStripMenuItem13 = new ToolStripMenuItem();
            cLIHELPToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            richTextBox_main = new RichTextBox();
            richTextBox_mesaj = new RichTextBox();
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { cutToolStripMenuItem1, copyToolStripMenuItem1, pasteToolStripMenuItem1, selectAllToolStripMenuItem1, refreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(141, 124);
            // 
            // cutToolStripMenuItem1
            // 
            cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            cutToolStripMenuItem1.Size = new Size(140, 24);
            cutToolStripMenuItem1.Text = "Cut";
            cutToolStripMenuItem1.Click += cutToolStripMenuItem1_Click;
            // 
            // copyToolStripMenuItem1
            // 
            copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            copyToolStripMenuItem1.Size = new Size(140, 24);
            copyToolStripMenuItem1.Text = "Copy";
            copyToolStripMenuItem1.Click += copyToolStripMenuItem1_Click;
            // 
            // pasteToolStripMenuItem1
            // 
            pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            pasteToolStripMenuItem1.Size = new Size(140, 24);
            pasteToolStripMenuItem1.Text = "Paste";
            pasteToolStripMenuItem1.Click += pasteToolStripMenuItem1_Click;
            // 
            // selectAllToolStripMenuItem1
            // 
            selectAllToolStripMenuItem1.Name = "selectAllToolStripMenuItem1";
            selectAllToolStripMenuItem1.Size = new Size(140, 24);
            selectAllToolStripMenuItem1.Text = "Select All";
            selectAllToolStripMenuItem1.Click += selectAllToolStripMenuItem1_Click;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(140, 24);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, menu_edit, menu_tools, komutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1176, 30);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_new, toolStripSeparator2, openToolStripMenuItem, toolStripSeparator1, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator6, toolStripSeparator5, closeToolStripMenuItem, toolStripSeparator4, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem_new
            // 
            toolStripMenuItem_new.Name = "toolStripMenuItem_new";
            toolStripMenuItem_new.Size = new Size(224, 26);
            toolStripMenuItem_new.Text = "New";
            toolStripMenuItem_new.Click += toolStripMenuItem_new_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(221, 6);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(224, 26);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click_1;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(224, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click_1;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(224, 26);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(221, 6);
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(221, 6);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(224, 26);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click_1;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(221, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(224, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click_1;
            // 
            // menu_edit
            // 
            menu_edit.DropDownItems.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, selectAllToolStripMenuItem, toolStripSeparator3, toolStripMenuItem_setfont, addToolStripMenuItem });
            menu_edit.Enabled = false;
            menu_edit.Name = "menu_edit";
            menu_edit.Size = new Size(49, 24);
            menu_edit.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(154, 26);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += cutToolStripMenuItem1_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(154, 26);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(154, 26);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new Size(154, 26);
            selectAllToolStripMenuItem.Text = "Select All";
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem1_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(151, 6);
            // 
            // toolStripMenuItem_setfont
            // 
            toolStripMenuItem_setfont.Name = "toolStripMenuItem_setfont";
            toolStripMenuItem_setfont.Size = new Size(154, 26);
            toolStripMenuItem_setfont.Text = "Set Font";
            toolStripMenuItem_setfont.Click += toolStripMenuItem_setfont_Click;
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { forLoopToolStripMenuItem, ifelsetoolStripMenuItem, switchcasetoolStripMenuItem, doWhileToolStripMenuItem });
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(154, 26);
            addToolStripMenuItem.Text = "Insert";
            // 
            // forLoopToolStripMenuItem
            // 
            forLoopToolStripMenuItem.Name = "forLoopToolStripMenuItem";
            forLoopToolStripMenuItem.Size = new Size(171, 26);
            forLoopToolStripMenuItem.Text = "For loop";
            forLoopToolStripMenuItem.Click += forLoopToolStripMenuItem_Click;
            // 
            // ifelsetoolStripMenuItem
            // 
            ifelsetoolStripMenuItem.Name = "ifelsetoolStripMenuItem";
            ifelsetoolStripMenuItem.Size = new Size(171, 26);
            ifelsetoolStripMenuItem.Text = "If else";
            ifelsetoolStripMenuItem.Click += ifelsetoolStripMenuItem_Click;
            // 
            // switchcasetoolStripMenuItem
            // 
            switchcasetoolStripMenuItem.Name = "switchcasetoolStripMenuItem";
            switchcasetoolStripMenuItem.Size = new Size(171, 26);
            switchcasetoolStripMenuItem.Text = "switch...case";
            switchcasetoolStripMenuItem.Click += switchcasetoolStripMenuItem_Click;
            // 
            // doWhileToolStripMenuItem
            // 
            doWhileToolStripMenuItem.Name = "doWhileToolStripMenuItem";
            doWhileToolStripMenuItem.Size = new Size(171, 26);
            doWhileToolStripMenuItem.Text = "Do While";
            doWhileToolStripMenuItem.Click += doWhileToolStripMenuItem_Click;
            // 
            // menu_tools
            // 
            menu_tools.DropDownItems.AddRange(new ToolStripItem[] { compileToolStripMenuItem, toolStripMenuItem3, toolStripMenuItem15, toolStripMenuItem16 });
            menu_tools.Enabled = false;
            menu_tools.Name = "menu_tools";
            menu_tools.Size = new Size(58, 24);
            menu_tools.Text = "Tools";
            // 
            // compileToolStripMenuItem
            // 
            compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            compileToolStripMenuItem.Size = new Size(173, 26);
            compileToolStripMenuItem.Text = "Compile";
            compileToolStripMenuItem.Click += compileToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(173, 26);
            toolStripMenuItem3.Text = "Upload";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem15
            // 
            toolStripMenuItem15.Name = "toolStripMenuItem15";
            toolStripMenuItem15.Size = new Size(173, 26);
            toolStripMenuItem15.Text = "Bootloader";
            toolStripMenuItem15.Click += toolStripMenuItem15_Click_1;
            // 
            // toolStripMenuItem16
            // 
            toolStripMenuItem16.Name = "toolStripMenuItem16";
            toolStripMenuItem16.Size = new Size(173, 26);
            toolStripMenuItem16.Text = "PLC IO TAGS";
            toolStripMenuItem16.Click += toolStripMenuItem16_Click;
            // 
            // komutToolStripMenuItem
            // 
            komutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem9, toolStripMenuItem14, toolStripMenuItem13, cLIHELPToolStripMenuItem });
            komutToolStripMenuItem.Name = "komutToolStripMenuItem";
            komutToolStripMenuItem.Size = new Size(91, 24);
            komutToolStripMenuItem.Text = "Type CMD";
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem10, toolStripMenuItem12 });
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(211, 26);
            toolStripMenuItem9.Text = "Enter a Command";
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox2 });
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(181, 26);
            toolStripMenuItem10.Text = "Enter CMD";
            // 
            // toolStripTextBox2
            // 
            toolStripTextBox2.Name = "toolStripTextBox2";
            toolStripTextBox2.Size = new Size(100, 27);
            toolStripTextBox2.Text = "dir";
            toolStripTextBox2.KeyDown += toolStripTextBox2_KeyDown;
            // 
            // toolStripMenuItem12
            // 
            toolStripMenuItem12.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox1 });
            toolStripMenuItem12.Name = "toolStripMenuItem12";
            toolStripMenuItem12.Size = new Size(181, 26);
            toolStripMenuItem12.Text = "CMD with CLI";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 27);
            toolStripTextBox1.Text = "help";
            toolStripTextBox1.KeyDown += toolStripTextBox1_KeyDown_1;
            // 
            // toolStripMenuItem14
            // 
            toolStripMenuItem14.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_megacore });
            toolStripMenuItem14.Name = "toolStripMenuItem14";
            toolStripMenuItem14.Size = new Size(211, 26);
            toolStripMenuItem14.Text = "Setup";
            // 
            // toolStripMenuItem_megacore
            // 
            toolStripMenuItem_megacore.Name = "toolStripMenuItem_megacore";
            toolStripMenuItem_megacore.Size = new Size(171, 26);
            toolStripMenuItem_megacore.Text = "GME PLC V6";
            toolStripMenuItem_megacore.Click += toolStripMenuItem_megacore_Click;
            // 
            // toolStripMenuItem13
            // 
            toolStripMenuItem13.Name = "toolStripMenuItem13";
            toolStripMenuItem13.Size = new Size(211, 26);
            toolStripMenuItem13.Text = "CLI VERSION";
            toolStripMenuItem13.Click += toolStripMenuItem13_Click;
            // 
            // cLIHELPToolStripMenuItem
            // 
            cLIHELPToolStripMenuItem.Name = "cLIHELPToolStripMenuItem";
            cLIHELPToolStripMenuItem.Size = new Size(211, 26);
            cLIHELPToolStripMenuItem.Text = "CLI HELP";
            cLIHELPToolStripMenuItem.Click += cLIHELPToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 30);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(richTextBox_mesaj);
            splitContainer1.Panel2.Margin = new Padding(23, 27, 23, 27);
            splitContainer1.Size = new Size(1176, 834);
            splitContainer1.SplitterDistance = 553;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 12;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(23, 27, 23, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1176, 553);
            tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(richTextBox_main);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(1168, 520);
            tabPage1.TabIndex = 0;
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox_main
            // 
            richTextBox_main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox_main.BackColor = Color.Black;
            richTextBox_main.BorderStyle = BorderStyle.FixedSingle;
            richTextBox_main.ContextMenuStrip = contextMenuStrip1;
            richTextBox_main.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox_main.ForeColor = Color.White;
            richTextBox_main.Location = new Point(7, 8);
            richTextBox_main.Margin = new Padding(11, 13, 11, 13);
            richTextBox_main.Name = "richTextBox_main";
            richTextBox_main.Size = new Size(1153, 503);
            richTextBox_main.TabIndex = 11;
            richTextBox_main.Text = "";
            richTextBox_main.Visible = false;
            richTextBox_main.KeyDown += richTextBox_main_KeyDown;
            // 
            // richTextBox_mesaj
            // 
            richTextBox_mesaj.BackColor = Color.Black;
            richTextBox_mesaj.Dock = DockStyle.Fill;
            richTextBox_mesaj.ForeColor = Color.White;
            richTextBox_mesaj.Location = new Point(0, 0);
            richTextBox_mesaj.Margin = new Padding(29, 33, 29, 33);
            richTextBox_mesaj.Name = "richTextBox_mesaj";
            richTextBox_mesaj.ReadOnly = true;
            richTextBox_mesaj.Size = new Size(1176, 276);
            richTextBox_mesaj.TabIndex = 12;
            richTextBox_mesaj.Text = "";
            // 
            // MAIN_PAGE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1176, 864);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            ForeColor = Color.FromArgb(64, 64, 64);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "MAIN_PAGE";
            Text = "GME PLC Editor";
            FormClosing += MAIN_PAGE_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cutToolStripMenuItem1;
        private ToolStripMenuItem copyToolStripMenuItem1;
        private ToolStripMenuItem pasteToolStripMenuItem1;
        private ToolStripMenuItem selectAllToolStripMenuItem1;
        private FontDialog fontDialog1;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem_new;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem menu_edit;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolStripMenuItem_setfont;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem forLoopToolStripMenuItem;
        private ToolStripMenuItem ifelsetoolStripMenuItem;
        private ToolStripMenuItem switchcasetoolStripMenuItem;
        private ToolStripMenuItem doWhileToolStripMenuItem;
        private ToolStripMenuItem menu_tools;
        private ToolStripMenuItem compileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem15;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripMenuItem komutToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripMenuItem toolStripMenuItem_megacore;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripMenuItem cLIHELPToolStripMenuItem;
        private SplitContainer splitContainer1;
        private RichTextBox richTextBox_mesaj;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private RichTextBox richTextBox_main;
    }
}