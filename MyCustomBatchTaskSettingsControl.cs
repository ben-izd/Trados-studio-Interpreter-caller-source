using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Interfaces;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace python_caller
{
    class MyCustomBatchTaskSettingsControl : UserControl, ISettingsAware<MyCustomBatchTaskSettings>, IUISettingsControl
    {
        private TextBox textBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label8;
        private Label label9;
        private TextBox textBox4;
        private Label label10;
        private GroupBox groupBox3;
        private CheckBox checkBox2;
        private ComboBox comboBox1;
        private Label label11;
        private TextBox textBox5;
        private CheckBox checkBox1;
        private Label label13;
        private ComboBox comboBox2;
        private CheckBox checkBox3;
        private ComboBox comboBox3;
        private Label label15;
        private ComboBox comboBox4;
        private TextBox textBox2;
        // private MyCustomBatchTaskSettings _settings = new MyCustomBatchTaskSettings();


        public MyCustomBatchTaskSettings Settings { get; set; }

        public MyCustomBatchTaskSettingsControl()
        {
            InitializeComponent();
        }

        private void SetSettings(MyCustomBatchTaskSettings value)
        {

            Settings = value;



            SettingsBinder.DataBindSetting<string>(textBox1, "Text", Settings, nameof(Settings.SettingsPythonPath));

            SettingsBinder.DataBindSetting<string>(textBox2, "Text", Settings, nameof(Settings.SettingsPythonFile));

            SettingsBinder.DataBindSetting<string>(textBox4, "Text", Settings, nameof(Settings.SettingsPythonFileForDebug));

            SettingsBinder.DataBindSetting<string>(textBox5, "Text", Settings, nameof(Settings.SettingsSkippingKeyword));



            SettingsBinder.DataBindSetting<int>(numericUpDown1, "Value", Settings, nameof(Settings.SettingsLimitRangeStart));

            SettingsBinder.DataBindSetting<int>(numericUpDown2, "Value", Settings, nameof(Settings.SettingsLimitRangeEnd));





            SettingsBinder.DataBindSetting<bool>(checkBox1, "Checked", Settings, nameof(Settings.SettingsUseSkippingKeyword));

            SettingsBinder.DataBindSetting<bool>(checkBox2, "Checked", Settings, nameof(Settings.SettingsUseReturnText));

            SettingsBinder.DataBindSetting<bool>(checkBox3, "Checked", Settings, nameof(Settings.SettingsChangeStatus));




            SettingsBinder.DataBindSetting<int>(comboBox1, "SelectedIndex", Settings, nameof(Settings.SettingsApplyModeIndex));

            SettingsBinder.DataBindSetting<int>(comboBox2, "SelectedIndex", Settings, nameof(Settings.SettingsStatusIndex));

            SettingsBinder.DataBindSetting<int>(comboBox3, "SelectedIndex", Settings, nameof(Settings.SettingsFilterStatusIndex));

            SettingsBinder.DataBindSetting<int>(comboBox4, "SelectedIndex", Settings, nameof(Settings.SettingsReturnTextUsageIndex));

            // MyCustomBatchTaskSettings.SettingsIdPythonFile);

            UpdateUi(value);
        }

        private void UpdateSettings(MyCustomBatchTaskSettings mySettings)
        {
            Settings = mySettings;
        }

        // Updates the UI elements to the corresponding settings
        private void UpdateUi(MyCustomBatchTaskSettings mySettings)
        {

            Settings = mySettings;

            this.UpdateSettings(Settings);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SetSettings(Settings);

        }

        private void InitializeComponent()
        {
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.groupBox1 = new GroupBox();
            this.label13 = new Label();
            this.label1 = new Label();
            this.label4 = new Label();
            this.groupBox2 = new GroupBox();
            this.label2 = new Label();
            this.label3 = new Label();
            this.textBox3 = new TextBox();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.numericUpDown1 = new NumericUpDown();
            this.numericUpDown2 = new NumericUpDown();
            this.label8 = new Label();
            this.label9 = new Label();
            this.textBox4 = new TextBox();
            this.label10 = new Label();
            this.groupBox3 = new GroupBox();
            this.comboBox4 = new ComboBox();
            this.comboBox3 = new ComboBox();
            this.comboBox2 = new ComboBox();
            this.comboBox1 = new ComboBox();
            this.checkBox3 = new CheckBox();
            this.checkBox1 = new CheckBox();
            this.checkBox2 = new CheckBox();
            this.textBox5 = new TextBox();
            this.label15 = new Label();
            this.label11 = new Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = SystemColors.WindowText;
            this.textBox1.Location = new Point(23, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(447, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new Point(23, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(447, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = FlatStyle.System;
            this.groupBox1.Font = new Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new Point(9, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(477, 72);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script File Path:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new Font("Microsoft Sans Serif", 7F);
            this.label13.ForeColor = SystemColors.ControlDarkDark;
            this.label13.Location = new Point(11, 51);
            this.label13.Name = "label13";
            this.label13.Size = new Size(379, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Directory of this field will be used as working directory which calls the Interpr" +
    "eter.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 7.5F);
            this.label1.Location = new Point(95, 2);
            this.label1.Name = "label1";
            this.label1.Size = new Size(103, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "(e.g. \"C:\\my_file.py\")";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Microsoft Sans Serif", 7F);
            this.label4.ForeColor = SystemColors.ControlDarkDark;
            this.label4.Location = new Point(32, 109);
            this.label4.Name = "label4";
            this.label4.Size = new Size(275, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Returning specified keyword will skip the running segment";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new Font("Microsoft Sans Serif", 9F);
            this.groupBox2.Location = new Point(9, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(477, 60);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interpreter Executable Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 7.5F);
            this.label2.Location = new Point(163, 2);
            this.label2.Name = "label2";
            this.label2.Size = new Size(156, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "(e.g. \"C:\\python38\\python.exe\")";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(7, 426);
            this.label3.Name = "label3";
            this.label3.Size = new Size(435, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "For using \"UTF-8\" encoding in sending translations from python, instead of \"print" +
    "\", use this:";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = BorderStyle.None;
            this.textBox3.ForeColor = SystemColors.WindowText;
            this.textBox3.Location = new Point(19, 447);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new Size(283, 30);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "import sys\r\nsys.stdout.buffer.write(bytes(\"YOUR_STRING\",\"utf-8\"))";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new Point(7, 487);
            this.label5.Name = "label5";
            this.label5.Size = new Size(36, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Note: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new Point(41, 487);
            this.label6.Name = "label6";
            this.label6.Size = new Size(350, 39);
            this.label6.TabIndex = 6;
            this.label6.Text = "A copy of the file will be saved next to the modified version but will not be\r\nad" +
    "ded to the Project Files.\r\nFor restoring the original file simply add the backup" +
    " file to your project.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new Point(96, 169);
            this.label7.Name = "label7";
            this.label7.Size = new Size(129, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "from segment number";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new Font("Microsoft Sans Serif", 7.5F);
            this.numericUpDown1.Location = new Point(231, 168);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new Size(76, 19);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new Font("Microsoft Sans Serif", 7.5F);
            this.numericUpDown2.Location = new Point(334, 168);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new Size(70, 19);
            this.numericUpDown2.TabIndex = 7;
            this.numericUpDown2.ValueChanged += new EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new Point(312, 170);
            this.label8.Name = "label8";
            this.label8.Size = new Size(17, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "to";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Microsoft Sans Serif", 7F);
            this.label9.ForeColor = SystemColors.ControlDarkDark;
            this.label9.Location = new Point(410, 170);
            this.label9.Name = "label9";
            this.label9.Size = new Size(51, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "(0 is max)";
            // 
            // textBox4
            // 
            this.textBox4.Font = new Font("Microsoft Sans Serif", 7.5F);
            this.textBox4.Location = new Point(186, 233);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(275, 19);
            this.textBox4.TabIndex = 8;
            this.textBox4.TextChanged += new EventHandler(this.textBox4_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new Point(20, 391);
            this.label10.Name = "label10";
            this.label10.Size = new Size(145, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Script file path for debugging:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.numericUpDown2);
            this.groupBox3.Controls.Add(this.comboBox4);
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.FlatStyle = FlatStyle.System;
            this.groupBox3.Font = new Font("Microsoft Sans Serif", 9F);
            this.groupBox3.Location = new Point(9, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(477, 264);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Segment Translation",
            "Segment Status",
            "Segment Source"});
            this.comboBox4.Location = new Point(186, 23);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new Size(173, 23);
            this.comboBox4.TabIndex = 5;
            this.comboBox4.SelectedIndexChanged += new EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Any",
            "Not Translated",
            "Draft",
            "Translated",
            "Translation Rejected",
            "Translation Approved",
            "Sign-off Rejected",
            "Signed Off"});
            this.comboBox3.Location = new Point(195, 197);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new Size(140, 23);
            this.comboBox3.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Not Translated",
            "Draft",
            "Translated",
            "Translation Rejected",
            "Translation Approved",
            "Sign-off Rejected",
            "Signed Off"});
            this.comboBox2.Location = new Point(186, 55);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(173, 23);
            this.comboBox2.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All Segments",
            "Segments with Translation",
            "Segments with Plain Text Translation",
            "Segments with Plain Text Source",
            "Segments with No Translation"});
            this.comboBox1.Location = new Point(98, 135);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(306, 23);
            this.comboBox1.TabIndex = 5;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new Point(14, 57);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new Size(120, 19);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "Change status to:";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(14, 87);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(148, 19);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Use skipping keyword:";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = CheckState.Checked;
            this.checkBox2.Font = new Font("Microsoft Sans Serif", 9F);
            this.checkBox2.Location = new Point(14, 25);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(138, 19);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Use returned text as:";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Font = new Font("Microsoft Sans Serif", 7.5F);
            this.textBox5.Location = new Point(186, 87);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Size(173, 19);
            this.textBox5.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new Point(98, 200);
            this.label15.Name = "label15";
            this.label15.Size = new Size(91, 15);
            this.label15.TabIndex = 6;
            this.label15.Text = "Status equal to:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new Point(11, 138);
            this.label11.Name = "label11";
            this.label11.Size = new Size(77, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "Apply only to:";
            // 
            // MyCustomBatchTaskSettingsControl
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "MyCustomBatchTaskSettingsControl";
            this.Size = new Size(498, 535);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox5.Enabled = this.checkBox1.Checked;
        }



        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool temp = this.checkBox2.Checked;
            this.checkBox1.Enabled = temp;
            this.textBox5.Enabled = temp && this.checkBox1.Checked;
            this.comboBox4.Enabled = temp;

            if (temp && this.comboBox4.SelectedIndex == 1)
            {
                this.checkBox3.Checked = false;
                this.checkBox3.Enabled = false;
            }
            else
            {
                this.checkBox3.Enabled = true;
            }

            // this.checkBox3.Enabled = !temp || (temp && this.comboBox4.SelectedIndex != 1);



        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBox2.Enabled = this.checkBox3.Checked;
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox4.SelectedIndex == 1)
            {
                this.comboBox2.Enabled = false;
                this.checkBox3.Enabled = false;
                this.checkBox3.Checked = false;
            }
            else
            {
                this.checkBox3.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.ForeColor = File.Exists(this.textBox1.Text) ? Color.Black : Color.Red;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.textBox2.ForeColor = File.Exists(this.textBox2.Text) ? Color.Black : Color.Red;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.textBox4.ForeColor = File.Exists(this.textBox4.Text) ? Color.Black : Color.Red;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Color temp_color = (this.numericUpDown1.Value > this.numericUpDown2.Value && this.numericUpDown2.Value != 0) ? Color.Red : Color.Black;
            this.numericUpDown1.ForeColor = temp_color;
            this.numericUpDown2.ForeColor = temp_color;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Color temp_color = (this.numericUpDown1.Value > this.numericUpDown2.Value && this.numericUpDown2.Value != 0) ? Color.Red : Color.Black;
            this.numericUpDown1.ForeColor = temp_color;
            this.numericUpDown2.ForeColor = temp_color;
        }
    }
}
