using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BeatSaberTrackManagerSharp
{
    public class Form1 : Form
    {
        public Button button1;
        public ListBox listBox1;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private Button button2;
        private TextBox textBox1;

        public Form1()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.Location = new System.Drawing.Point(26, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(500, 459);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(26, 512);
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
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox1.Size = new System.Drawing.Size(261, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.AcceptsReturn = true;
            this.textBox2.AcceptsTab = true;
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(830, 38);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(212, 459);
            this.textBox2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(532, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "AAA";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(532, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 35);
            this.label2.TabIndex = 6;
            this.label2.Text = "AAA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(535, 373);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(535, 132);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 124);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(532, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 35);
            this.label3.TabIndex = 9;
            this.label3.Text = "AAA";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(532, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 35);
            this.label4.TabIndex = 8;
            this.label4.Text = "AAA";
            // 
            // textBox3
            // 
            this.textBox3.AcceptsReturn = true;
            this.textBox3.AcceptsTab = true;
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(650, 512);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(392, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "F:\\Games\\Beat Saber 1.8.0\\Beat Saber_Data\\CustomLevels";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(967, 553);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Reset combo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AccessibleName = "Form1";
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1086, 600);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
            string[] subdirs = Directory.GetDirectories(textBox3.Text)
            .Select(Path.GetFileName)
            .ToArray();

            foreach (string i in subdirs)
            {
                listBox1.Items.Add(i);
            }
        }

        public void clear_info()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear_info();
            try
            {
                using (StreamReader file = File.OpenText(textBox3.Text + @"\" + listBox1.Text + @"\video.json"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o2 = (JObject)JToken.ReadFrom(reader);
                    //IList<string> keys = o2.Properties().Select(p => p.Name).ToList();

                    var video_json = o2.ToString();
                    //var fdate = JObject.Parse(track_json)["title"];

                    //textBox2.Text = video_json;
                    label1.Text = (string)o2["videos"][0]["title"];
                    label2.Text = (string)o2["videos"][0]["duration"];
                    var thumbnail_url = (string)o2["videos"][0]["thumbnailURL"];
                    thumbnail_url = (string)o2["videos"][0]["thumbnailURL"];
                    thumbnail_url = thumbnail_url.Substring(0, thumbnail_url.LastIndexOf("?"));
                    pictureBox1.Load(thumbnail_url);
                }
            }
            catch (FileNotFoundException)
            {
            
            }

            catch (System.ArgumentException)
            {
            //TODO Figure out a way to display webp (21c2)
            }

            catch (DirectoryNotFoundException)
            {

            }

            catch (System.Net.WebException)
            {
                pictureBox1.Load("https://s.ytimg.com/yts/img/no_thumbnail-vfl4t3-4R.jpg");
            }

            try
            {
                using (StreamReader file = File.OpenText(textBox3.Text + @"\" + listBox1.Text + @"\info.dat"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o2 = (JObject)JToken.ReadFrom(reader);
                    //IList<string> keys = o2.Properties().Select(p => p.Name).ToList();

                    var track_json = o2.ToString();
                    //var fdate = JObject.Parse(track_json)["title"];

                    textBox1.Text = (string)o2["_songName"] + "  " + (string)o2["_songAuthorName"];

                    textBox2.Text = track_json;
                    label4.Text = (string)o2["_songName"] + " - " + (string)o2["_levelAuthorName"];
                    label3.Text = "Duration not yet calculated";
                    pictureBox2.Load(textBox3.Text + @"\" + listBox1.Text + @"\" + (string)o2["_coverImageFilename"]);
                }
            }
            catch (FileNotFoundException)
            {

            }

            catch (DirectoryNotFoundException)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //TODO Making this dynamic causes issues
                string[] subdirs = Directory.GetDirectories(textBox3.Text)
               .Select(Path.GetFileName)
               .ToArray();

                listBox1.Items.Clear();
                clear_info();

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
                        if (File.Exists(textBox3.Text + @"\" + i + @"\video.json") == false)
                        {

                            listBox1.Items.Add(i);
                        }
                    }
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    foreach (string i in subdirs)
                    {
                        if (File.Exists(textBox3.Text + @"\" + i + @"\video.json") == true)
                        {

                            listBox1.Items.Add(i);
                        }
                    }
                }
                
            }
            catch (System.ArgumentException)
                {
                listBox1.Items.Clear();
                comboBox1.Enabled = false;
                }

        }   

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
        }
    }
}


