namespace GME_PLC_EDITOR
{
    partial class DEVICE_SELECT
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            button_ok = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "GME PLC V6" });
            comboBox1.Location = new Point(29, 53);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(175, 40);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 21);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 1;
            label1.Text = "DEVICE SELECT";
            // 
            // button_ok
            // 
            button_ok.DialogResult = DialogResult.OK;
            button_ok.Enabled = false;
            button_ok.Location = new Point(229, 119);
            button_ok.Name = "button_ok";
            button_ok.Size = new Size(111, 44);
            button_ok.TabIndex = 2;
            button_ok.Text = "Ok";
            button_ok.UseVisualStyleBackColor = true;
            button_ok.Click += button_ok_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(12, 119);
            button2.Name = "button2";
            button2.Size = new Size(111, 44);
            button2.TabIndex = 3;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // DEVICE_SELECT
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 175);
            Controls.Add(button2);
            Controls.Add(button_ok);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DEVICE_SELECT";
            StartPosition = FormStartPosition.CenterParent;
            Text = "DEVICE_SELECT";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Button button_ok;
        private Button button2;
    }
}