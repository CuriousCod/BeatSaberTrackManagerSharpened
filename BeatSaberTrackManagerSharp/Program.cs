using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace BeatSaberTrackManagerSharp
{
    public class Form1 : Form
    {
        public Button button1;
        public ListBox listBox1;
        private ComboBox comboBox1;
        private TextBox textBox1;

        public Form1()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.Location = new System.Drawing.Point(26, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(500, 394);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(26, 438);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(500, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All tracks",
            "Tracks without video",
            "Tracks with video"});
            this.comboBox1.Location = new System.Drawing.Point(26, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(261, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AccessibleName = "Form1";
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }

        [STAThread]
        static void Main()
        {

            Form1 a = new Form1();
            a.fill_listbox();

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(a);

        }

        public void fill_listbox()
        {
            string[] subdirs = Directory.GetDirectories(@"F:\Games\Beat Saber 1.8.0\Beat Saber_Data\CustomLevels")
            .Select(Path.GetFileName)
            .ToArray();

            foreach (string i in subdirs)
            {
                listBox1.Items.Add(i);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] subdirs = Directory.GetDirectories(@"F:\Games\Beat Saber 1.8.0\Beat Saber_Data\CustomLevels")
           .Select(Path.GetFileName)
           .ToArray();

            listBox1.Items.Clear();

            // switch (comboBox1.SelectedIndex) - doesn't work

            if (comboBox1.SelectedIndex == 0)
            {
                foreach (string i in subdirs)
                {
                    listBox1.Items.Add(i);
                }
            }            
            if (comboBox1.SelectedIndex == 1)
            {
                foreach (string i in subdirs)
                {
                    if (File.Exists(@"F:\Games\Beat Saber 1.8.0\Beat Saber_Data\CustomLevels\" + i + @"\video.json") == false)
                    {

                        listBox1.Items.Add(i);
                    }
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                foreach (string i in subdirs)
                {
                    if (File.Exists(@"F:\Games\Beat Saber 1.8.0\Beat Saber_Data\CustomLevels\" + i + @"\video.json") == true)
                    {

                        listBox1.Items.Add(i);
                    }
                }
            }
        }
    }
}

