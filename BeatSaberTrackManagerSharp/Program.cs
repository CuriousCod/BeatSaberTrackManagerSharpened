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
using NLog;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MediaToolkit.Model;
using MediaToolkit;
using System.Text.RegularExpressions;

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
        private MenuStrip menuStrip1;
        private ContextMenuStrip contextMenuStrip1;
        private IContainer components;
        private ToolStripMenuItem aToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private TextBox textBox1;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private Button button3;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public Form1()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.Location = new System.Drawing.Point(26, 60);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(500, 459);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem1.Text = "Search Youtube";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem2.Text = "Open track folder";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(26, 534);
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
            this.comboBox1.Location = new System.Drawing.Point(26, 33);
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
            this.textBox2.Location = new System.Drawing.Point(830, 60);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(212, 459);
            this.textBox2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(532, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "AAA";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(532, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 35);
            this.label2.TabIndex = 6;
            this.label2.Text = "AAA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(535, 395);
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
            this.pictureBox2.Location = new System.Drawing.Point(535, 154);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 124);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(532, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 35);
            this.label3.TabIndex = 9;
            this.label3.Text = "AAA";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(532, 63);
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
            this.textBox3.Location = new System.Drawing.Point(650, 534);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(392, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "F:\\Games\\Beat Saber 1.8.0\\Beat Saber_Data\\CustomLevels";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(967, 575);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Reset combo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.aboutToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1086, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem3.Text = "File";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItem4.Text = "Select CustomLevels Folder";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItem5.Text = "Exit";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem.Text = "Settings";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1});
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(26, 577);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Search Youtube";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AccessibleName = "Form1";
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1086, 612);
            this.Controls.Add(this.button3);
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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

        public dynamic fetch_video_json(string track_path)
        {
            var video_json = "";
            JObject o2 = null;

            if (File.Exists(track_path + @"\video.json"))
            {
                using (StreamReader file = File.OpenText(track_path + @"\video.json"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    o2 = (JObject)JToken.ReadFrom(reader);

                    video_json = o2.ToString();
                    Console.WriteLine(video_json);
                }

                if (o2["videos"] == null)
                {
                    string newJson = "{activeVideo: '0', videos: [" + video_json + "]}";
                    o2 = JObject.Parse(newJson);
                    Console.WriteLine(o2.ToString());
                }

                int av = (int)o2["activeVideo"];

                if (o2["videos"][av]["videopath"] != null)
                {
                    o2["videos"][av]["videoPath"] = o2["videos"][av]["videopath"];
                    o2["videos"][av]["videopath"].Remove();
                }
                //TODO Replace bad symbols here

                video_json = o2.ToString();
                Console.WriteLine(video_json);

                //Serialize json. Conversion process adds unnecessary stuff to the json, gotta replace that.
                var serialize = JsonConvert.SerializeObject(video_json, Formatting.None).Replace(@"\r\n", "").Replace("\\", "");
                serialize = Regex.Replace(serialize, @"\s+", " ");
                Console.WriteLine(serialize);
                File.WriteAllText(track_path + @"\video.json", video_json);

                return video_json;


            }
            else
            {
                return false;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear_info();
            var video_json = fetch_video_json(textBox3.Text + @"\" + listBox1.Text);


            if (video_json == string)
            {
                try
                {
                    JObject o2 = JObject.Parse(video_json);

                    //textBox2.Text = video_json;
                    label1.Text = (string)o2["videos"][0]["title"];
                    label2.Text = (string)o2["videos"][0]["duration"];
                    var thumbnail_url = (string)o2["videos"][0]["thumbnailURL"];
                    thumbnail_url = thumbnail_url.Replace("_webp", "").Replace("webp", "jpg");
                    thumbnail_url = thumbnail_url.Substring(0, thumbnail_url.LastIndexOf("jpg") + 3);
                    pictureBox1.Load(thumbnail_url);
                }
                catch (FileNotFoundException ex)
                {
                    Logger.Error(ex);
                }

                catch (ArgumentException ex)
                {
                    //Figure out a way to display webp (21c2)
                    //Actually don't, just use the jpg image instead
                    //C# and webp don't blend well
                    //TODO Get rid of this part
                    Logger.Error(ex, listBox1.Text + " - Thumbnail format not supported -> webp? ");
                }

                catch (DirectoryNotFoundException ex)
                {
                    Logger.Error(ex, textBox3.Text + " - Not the BS directory ");
                }

                catch (System.Net.WebException ex)
                {
                    pictureBox1.Load("https://s.ytimg.com/yts/img/no_thumbnail-vfl4t3-4R.jpg");
                    Logger.Error(ex, listBox1.Text + " - No thumbnail found, using default thumbnail. ");
                }
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

                    string trackFilename = textBox3.Text + @"\" + listBox1.Text + @"\" + (string)o2["_songFilename"];
                    FileInfo f = new FileInfo(trackFilename);

                    //Grab track's duration
                    //Third times the charm, MediaToolkit grabs the track duration properly from uncommon extensions
                    var inputFile = new MediaFile { Filename = trackFilename };

                    using (var engine = new Engine())
                    {
                        engine.GetMetadata(inputFile);
                    }

                    Console.WriteLine(inputFile.Metadata.Duration);
                    var dur = inputFile.Metadata.Duration;
                    label3.Text = inputFile.Metadata.Duration.ToString(@"m\:ss");

                    textBox1.Text = (string)o2["_songName"] + "  " + (string)o2["_songAuthorName"];

                    textBox2.Text = track_json;
                    label4.Text = (string)o2["_songName"] + " - " + (string)o2["_levelAuthorName"];
                    pictureBox2.Load(textBox3.Text + @"\" + listBox1.Text + @"\" + (string)o2["_coverImageFilename"]);
                }
            }
            catch (FileNotFoundException ex)
            {
                Logger.Error(ex);
            }

            catch (DirectoryNotFoundException ex)
            {
                Logger.Error(ex, listBox1.Text + " - Not the BS directory");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //TODO Making this dynamic causes issues
                //Apparently related to the default index of the combobox
                string[] subdirs = Directory.GetDirectories(textBox3.Text)
               .Select(Path.GetFileName)
               .ToArray();

                listBox1.Items.Clear();
                clear_info();

                //TODO switch (comboBox1.SelectedIndex) - doesn't work

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            //Replaced the horrible FolderBrowser with CommonOpenFile
            CommonOpenFileDialog openBSFolder = new CommonOpenFileDialog();
            openBSFolder.InitialDirectory = textBox3.Text;
            openBSFolder.IsFolderPicker = true;
            if (openBSFolder.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBox3.Text = openBSFolder.FileName;
            }

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Open track folder
            System.Diagnostics.Process.Start("explorer.exe", textBox3.Text + @"\" + listBox1.Text);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Search Youtube

            //Use cmdline instead of NYoutubeDL
            //NYoutubeDL is confusing
            System.Diagnostics.Process dlVideo = new System.Diagnostics.Process();
            dlVideo.StartInfo.FileName = @"F:\Games\Beat Saber 1.8.0\Youtube-dl\youtube-dl.exe";
            dlVideo.StartInfo.Arguments = "ytsearch:\"" + textBox1.Text + "\" -o \"J:/\" --skip-download --write-info-json ";
            //dlVideo.StartInfo.RedirectStandardOutput = true;
            //dlVideo.StartInfo.UseShellExecute = false;
            dlVideo.Start();
            //string stdout = dlVideo.StandardOutput.ReadToEnd();
            dlVideo.WaitForExit();
            //MessageBox.Show(stdout);

            using (StreamReader file = File.OpenText(@"J:\.info.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                //IList<string> keys = o2.Properties().Select(p => p.Name).ToList();

                var video_json = o2.ToString();
                //var fdate = JObject.Parse(track_json)["title"];

                textBox2.Text = video_json;
                label1.Text = (string)o2["title"];

                TimeSpan t = TimeSpan.FromSeconds((int)o2["duration"]);
                string video_duration = t.ToString(@"m\:ss");
                label2.Text = video_duration;

                var thumbnail_url = (string)o2["thumbnail"];
                thumbnail_url = thumbnail_url.Replace("_webp", "").Replace("webp", "jpg");
                thumbnail_url = thumbnail_url.Substring(0, thumbnail_url.LastIndexOf("jpg") + 3);
                pictureBox1.Load(thumbnail_url);

            }

            //Download
            //dlVideo.StartInfo.Arguments = "ytsearch:\"sensation vocaloid\" -f mp4[height<=720]+bestaudio[ext=m4a] -o \"J:/%(title)s.%(ext)s\" --no-playlist --write-info-json ";

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO Change cleanup routine later
            File.Delete(@"J:\.info.json");
        }
    }


}



