using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Net;

namespace BeatSaberTrackManagerSharpened
{
    public class Form1 : Form
    {
        public Button button1;
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
        private TextBox textBox4;
        private Button button4;
        private Label label5;
        private Label label6;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private Label label7;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
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
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 48);
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
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.BackColor = System.Drawing.Color.Teal;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(26, 726);
            this.textBox1.MinimumSize = new System.Drawing.Size(500, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(500, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Teal;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All tracks",
            "Tracks without video",
            "Tracks with video"});
            this.comboBox1.Location = new System.Drawing.Point(26, 33);
            this.comboBox1.MinimumSize = new System.Drawing.Size(261, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox1.Size = new System.Drawing.Size(261, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "All tracks";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.AcceptsReturn = true;
            this.textBox2.AcceptsTab = true;
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.Teal;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(970, 60);
            this.textBox2.MinimumSize = new System.Drawing.Size(212, 550);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(212, 550);
            this.textBox2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(650, 306);
            this.label1.MinimumSize = new System.Drawing.Size(237, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "AAA";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(650, 351);
            this.label2.MinimumSize = new System.Drawing.Size(237, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 35);
            this.label2.TabIndex = 6;
            this.label2.Text = "AAA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(653, 389);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(653, 146);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 140);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(650, 108);
            this.label3.MinimumSize = new System.Drawing.Size(237, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 35);
            this.label3.TabIndex = 9;
            this.label3.Text = "AAA";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(650, 60);
            this.label4.MinimumSize = new System.Drawing.Size(237, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 35);
            this.label4.TabIndex = 8;
            this.label4.Text = "AAA";
            // 
            // textBox3
            // 
            this.textBox3.AcceptsReturn = true;
            this.textBox3.AcceptsTab = true;
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.Teal;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(790, 726);
            this.textBox3.MinimumSize = new System.Drawing.Size(392, 20);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(392, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "F:\\Games\\Beat Saber 1.8.0\\Beat Saber_Data\\CustomLevels";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button2.Location = new System.Drawing.Point(1107, 767);
            this.button2.MinimumSize = new System.Drawing.Size(75, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Reset combo";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.aboutToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1226, 24);
            this.menuStrip1.TabIndex = 13;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem3.Text = "File";
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
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button3.Location = new System.Drawing.Point(26, 769);
            this.button3.MinimumSize = new System.Drawing.Size(107, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Search Youtube";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox4
            // 
            this.textBox4.AcceptsReturn = true;
            this.textBox4.AcceptsTab = true;
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.BackColor = System.Drawing.Color.Teal;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(537, 36);
            this.textBox4.MinimumSize = new System.Drawing.Size(97, 20);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(97, 20);
            this.textBox4.TabIndex = 15;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button4.Location = new System.Drawing.Point(141, 769);
            this.button4.MinimumSize = new System.Drawing.Size(75, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Download";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(650, 553);
            this.label5.MinimumSize = new System.Drawing.Size(237, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "AAA";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(650, 587);
            this.label6.MinimumSize = new System.Drawing.Size(237, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(237, 14);
            this.label6.TabIndex = 18;
            this.label6.Text = "AAA";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.Teal;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(26, 60);
            this.listView1.MinimumSize = new System.Drawing.Size(500, 553);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(608, 647);
            this.listView1.TabIndex = 21;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 25000;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(498, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 19);
            this.label7.TabIndex = 22;
            this.label7.Text = "Filter";
            // 
            // Form1
            // 
            this.AccessibleName = "Form1";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1226, 808);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox4);
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
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Beat Saber Track Manager Sharpened";
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
            // Listview creates an empty row in the beginning -> clear list first
            listView1.Items.Clear();

            string[] subDirs = Directory.GetDirectories(textBox3.Text)
                .Select(Path.GetFileName)
                .ToArray();

            foreach (string i in subDirs)
            {
                listView1.Items.Add(i);
            }
        }

        public void clear_info()
        {
            textBox1.Text = "";
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            button4.Enabled = false;
        }

        public void updateListbox(string[] subDirs, bool filter)
        // Filter results based on combobox value
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (filter)
                    {
                        foreach (string i in subDirs)
                        {
                            if (i.ToLower().Contains(textBox4.Text.ToLower()))
                            {
                                listView1.Items.Add(i);
                            }

                        }
                    }
                    else
                    {
                        foreach (string i in subDirs)
                        {
                            listView1.Items.Add(i);
                        }
                    }
                    break;
                case 1:
                    if (filter)
                    {
                        foreach (string i in subDirs)
                        {
                            if (i.ToLower().Contains(textBox4.Text.ToLower()))
                            {
                                listView1.Items.Add(i);
                            }

                        }
                    }
                    else
                    {
                        foreach (string i in subDirs)
                        {
                            if (File.Exists(textBox3.Text + @"\" + i + @"\video.json") == false)
                            {
                                if (i.ToLower().Contains(textBox4.Text.ToLower()))
                                {
                                    listView1.Items.Add(i);
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    if (filter)
                    {
                        foreach (string i in subDirs)
                        {
                            if (i.ToLower().Contains(textBox4.Text.ToLower()))
                            {
                                listView1.Items.Add(i);
                            }

                        }
                    }
                    else
                    {
                        foreach (string i in subDirs)
                        {
                            if (i.ToLower().Contains(textBox4.Text.ToLower()))
                            {
                                listView1.Items.Add(i);
                            }

                        }
                    }
                    break;
            }

        }

        private string ReplaceSymbols(string filename)
        {
            //Replace symbols that cannot be used in file names
            //Also replaces few symbols that youtubeDl replaces automatically 

            List<string> ngSymbols = new List<string>() { "*", "/", "\\", "<", ">", "|" };

            foreach (string i in ngSymbols)
            {
                filename = filename.Replace(i, "_");
            }

            filename = filename.Replace("?", "");
            filename = filename.Replace(":", " -");
            filename = filename.Replace("\"", "'");

            return filename;

        }

        public dynamic fetch_video_json(string track_path)
        {
            var video_json = "";
            JObject o2 = null;

            if (File.Exists(track_path + @"\video.json"))
            {
                try
                {
                    using (StreamReader file = File.OpenText(track_path + @"\video.json"))
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        o2 = (JObject) JToken.ReadFrom(reader);

                        video_json = o2.ToString();
                        Console.WriteLine(video_json);
                    }

                    if (o2["videos"] == null)
                    {
                        string newJson = "{activeVideo: '0', videos: [" + video_json + "]}";
                        o2 = JObject.Parse(newJson);
                        Console.WriteLine(o2.ToString());
                    }

                    int av = (int) o2["activeVideo"];

                    if (o2["videos"][av]["videopath"] != null)
                    {
                        o2["videos"][av]["videoPath"] = o2["videos"][av]["videopath"];
                        o2["videos"][av]["videopath"].Remove();
                    }
                    
                    //Replace unaccepted symbols in video file name
                    o2["videos"][av]["videoPath"] = ReplaceSymbols(o2["videos"][av]["videoPath"].ToString());

                    //Fix long video url
                    if (o2["videos"][av]["URL"].ToString().Contains("youtube"))
                    {
                        o2["videos"][av]["URL"] = o2["videos"][av]["URL"].ToString().Substring(23);
                    }

                    //Fix thumbnail url
                    if (o2["videos"][av]["thumbnailURL"].ToString().Contains("?"))
                    {
                        string thumbnailUrl = o2["videos"][av]["thumbnailURL"].ToString();
                        thumbnailUrl = thumbnailUrl.Substring(0,thumbnailUrl.IndexOf("?"));
                        o2["videos"][av]["thumbnailURL"] = thumbnailUrl;
                    }


                    video_json = o2.ToString();
                    Console.WriteLine(video_json);

                    File.WriteAllText(track_path + @"\video.json", video_json);

                    return video_json;
                }
                catch (Newtonsoft.Json.JsonReaderException ex)
                {
                    label1.Text = "video.json empty or not in proper format!";
                    Logger.Error(ex, listView1.SelectedItems[0].Text + " - video.json empty or not in proper format!");
                    return "false";
                }

            }
            else
            {
                return "false";
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // The app will crash if nothing is selected on the listview
            // This means it also crashes when selecting something from the list <_<
            if (listView1.SelectedItems.Count > 0)
            {
                clear_info();
                var video_json = fetch_video_json(textBox3.Text + @"\" + listView1.SelectedItems[0].Text);

                if (video_json != "false")
                {
                    try
                    {
                        JObject o2 = JObject.Parse(video_json);
                        
                        //Grab video data from video.json
                        label1.Text = (string)o2["videos"][0]["title"];
                        label2.Text = (string)o2["videos"][0]["duration"];
                        var thumbnail_url = (string)o2["videos"][0]["thumbnailURL"];
                        thumbnail_url = thumbnail_url.Replace("_webp", "").Replace("webp", "jpg");
                        pictureBox1.Load(thumbnail_url);

                        //Video size
                        var videofile = new FileInfo(textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\" + (string)o2["videos"][0]["videoPath"]);
                        long size = videofile.Length;

                        //Video height
                        ShellFile shellFile = ShellFile.FromFilePath(textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\" + (string)o2["videos"][0]["videoPath"]);
                        int videoWidth = (int)shellFile.Properties.System.Video.FrameHeight.Value;

                        label5.Text = "Video downloaded - " + size / 1000000 + " MB - " + videoWidth + "p";
                        label6.Text = "Offset: " + (string)o2["videos"][0]["offset"];

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
                        Logger.Error(ex, listView1.SelectedItems[0].Text + " - Thumbnail format not supported -> webp? ");
                    }

                    catch (DirectoryNotFoundException ex)
                    {
                        Logger.Error(ex, textBox3.Text + " - Not the BS directory ");
                    }

                    catch (System.Net.WebException ex)
                    {
                        pictureBox1.Load("https://s.ytimg.com/yts/img/no_thumbnail-vfl4t3-4R.jpg");
                        Logger.Error(ex, listView1.SelectedItems[0].Text + " - No thumbnail found, using default thumbnail. ");
                    }
                }

                try
                {
                    // Grab track information from info.dat
                    using (StreamReader file = File.OpenText(textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\info.dat"))
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject o2 = (JObject)JToken.ReadFrom(reader);

                        var track_json = o2.ToString();

                        string trackFilename = textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\" + (string)o2["_songFilename"];
                        FileInfo f = new FileInfo(trackFilename);

                        //Grab track's duration
                        //Third times the charm, MediaToolkit grabs the track duration properly (unlike some other <_<) from uncommon extensions
                        var inputFile = new MediaFile { Filename = trackFilename };

                        using (var engine = new Engine())
                        {
                            engine.GetMetadata(inputFile);
                        }

                        Console.WriteLine(inputFile.Metadata.Duration);
                        var dur = inputFile.Metadata.Duration;
                        label3.Text = inputFile.Metadata.Duration.ToString(@"m\:ss");

                        textBox1.Text = (string)o2["_songName"] + " " + (string)o2["_songAuthorName"];

                        textBox2.Text = track_json;
                        label4.Text = (string)o2["_songName"] + " - " + (string)o2["_levelAuthorName"];
                        pictureBox2.Load(textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\" + (string)o2["_coverImageFilename"]);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Logger.Error(ex);
                    label4.Text = "info.dat missing!";
                    textBox1.Text = listView1.SelectedItems[0].Text.Substring(listView1.SelectedItems[0].Text.IndexOf("(") + 1);
                }

                catch (DirectoryNotFoundException ex)
                {
                    Logger.Error(ex, listView1.SelectedItems[0].Text + " - Not the BS directory");
                }
                catch (Newtonsoft.Json.JsonReaderException ex)
                {
                    label4.Text = "info.dat empty or not in proper format!";
                    Logger.Error(ex, listView1.SelectedItems[0].Text + " - info.dat empty or not in proper format!");
                    textBox1.Text = listView1.SelectedItems[0].Text.Substring(listView1.SelectedItems[0].Text.IndexOf("(") + 1);
                }
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //FIXED Making this dynamic causes issues -> Set combobox default name as the 0 index
                string[] subDirs = Directory.GetDirectories(textBox3.Text)
                    .Select(Path.GetFileName)
                    .ToArray();

                listView1.Items.Clear();
                clear_info();

                //TODO switch (comboBox1.SelectedIndex) - doesn't work
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        foreach (string i in subDirs)
                        {
                            listView1.Items.Add(i);
                        }
                        break;

                    case 1:
                        foreach (string i in subDirs)
                        {
                            if (File.Exists(textBox3.Text + @"\" + i + @"\video.json") == false)
                            {

                                listView1.Items.Add(i);
                            }
                        }
                        break;

                    case 2:
                        foreach (string i in subDirs)
                        {
                            if (File.Exists(textBox3.Text + @"\" + i + @"\video.json"))
                            {

                                listView1.Items.Add(i);
                            }
                        }
                        break;
                }

            }
            catch (System.ArgumentException)
            {
                listView1.Items.Clear();
                comboBox1.Enabled = false;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                //TODO Doesn't work, if video is not downloaded
                string videoUrl = fetch_video_json(textBox3.Text + @"\" + listView1.SelectedItems[0].Text);
                JObject o = JObject.Parse(videoUrl);

                //TODO change 0 to av
                videoUrl = "www.youtube.com" + o["videos"][0]["URL"].ToString();
                System.Diagnostics.Process.Start(videoUrl);
            }

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
                clear_info();
                fill_listbox();  //TODO Not working properly, list stays full even with wrong folder selected
            }

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Open track folder
            System.Diagnostics.Process.Start("explorer.exe", textBox3.Text + @"\" + listView1.SelectedItems[0].Text);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Search Youtube

            string videoUrl;
            string BsMainFolder = Path.GetFullPath(Path.Combine(textBox3.Text, @"..\..\"));
            string trackFolder = textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\";
            Console.WriteLine(trackFolder);

            //ytsearch is very finicky at the moment, so grab video url with WebClient instead
            using (WebClient client = new WebClient()) 
            {
                string htmlCode = client.DownloadString("https://www.youtube.com/results?search_query=" + textBox1.Text.Replace(" ","+"));
                Console.WriteLine(htmlCode);
                var index = htmlCode.IndexOf("watch?");
                Console.WriteLine(index);
                var videoId = htmlCode.Substring(index + 8,11);
                videoUrl = "https://www.youtube.com/watch?v=" + videoId;
                Console.WriteLine(videoUrl);
            }

            //Use cmdline instead of NYoutubeDL
            //NYoutubeDL is confusing
            System.Diagnostics.Process dlVideo = new System.Diagnostics.Process();
            dlVideo.StartInfo.FileName = BsMainFolder + @"\Youtube-dl\youtube-dl.exe";
            
            //youtubeDl output template is weird
            dlVideo.StartInfo.Arguments =
                //"ytsearch:\"" + textBox1.Text + "\" -o \""+ trackFolder + "video\" --skip-download --write-info-json";
                videoUrl + " -o \""+ trackFolder + "video\" --skip-download --write-info-json --cookies F:/cookies.txt";
            //dlVideo.StartInfo.RedirectStandardOutput = true;
            //dlVideo.StartInfo.UseShellExecute = false;
            dlVideo.Start();
            //string stdout = dlVideo.StandardOutput.ReadToEnd();
            dlVideo.WaitForExit();
            //MessageBox.Show(stdout);

            using (StreamReader file = File.OpenText(trackFolder + @"video.info.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject) JToken.ReadFrom(reader);

                var video_json = o2.ToString();

                textBox2.Text = video_json;
                label1.Text = (string) o2["title"];

                TimeSpan t = TimeSpan.FromSeconds((int) o2["duration"]);
                string video_duration = t.ToString(@"m\:ss");
                label2.Text = video_duration;

                var thumbnail_url = (string) o2["thumbnail"];

                //C# doesn't support webp, use jpg instead
                thumbnail_url = thumbnail_url.Replace("_webp", "").Replace("webp", "jpg");
                thumbnail_url = thumbnail_url.Substring(0, thumbnail_url.LastIndexOf("jpg") + 3);
                pictureBox1.Load(thumbnail_url);
                button4.Enabled = true;

            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string[] subDirs = Directory.GetDirectories(textBox3.Text)
                .Select(Path.GetFileName)
                .ToArray();

            if (textBox4.Text.Length >= 3)
            {
                listView1.Items.Clear();
                clear_info();

                foreach (string i in subDirs)
                {
                    if (i.ToLower().Contains(textBox4.Text.ToLower()))
                    {
                        listView1.Items.Add(i);
                    }

                }

            }

            if (textBox4.Text.Length < 2)
            {
                listView1.Items.Clear();
                //clear_info();
                updateListbox(subDirs, false);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

            string trackFolder = textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\";

            //Download
            using (StreamReader file = File.OpenText(trackFolder + @"video.info.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject) JToken.ReadFrom(reader);

                var video_url = (string) o2["webpage_url"];

                string BsMainFolder = Path.GetFullPath(Path.Combine(textBox3.Text, @"..\..\"));

                System.Diagnostics.Process dlVideo = new System.Diagnostics.Process();
                dlVideo.StartInfo.FileName = BsMainFolder + @"\Youtube-dl\youtube-dl.exe";
                
                // TODO add exception handling when video quality is less than 480p
                dlVideo.StartInfo.Arguments = video_url +
                                              " -f mp4[height>=480][height<1080]+bestaudio[ext=m4a] -o \""+ trackFolder + "%(title)s.%(ext)s\" --no-playlist --cookies F:/cookies.txt";
                dlVideo.Start();
                dlVideo.WaitForExit();
                
                var info = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(o2.ToString());

                var video_duration = TimeSpan.FromSeconds(info["duration"]);

                // TODO See 1a3f video.json generation
                //Generate video json
                Dictionary<string, dynamic> nestedDataSet = new Dictionary<string, dynamic>
                {
                    {"title", info["title"]},
                    {"author", info["uploader"]},
                    {"description", info["description"].Substring(0, 106) + " ..."},
                    {"duration", video_duration.ToString(@"m\:ss")},
                    {"URL", info["webpage_url"].Substring(23)},
                    {"thumbnailURL", info["thumbnail"]},
                    {"loop", "false"},
                    {"offset", 0},
                    {"videoPath", ReplaceSymbols(info["title"] + ".mp4")}

                };
               
                List<dynamic> videos = new List<dynamic>();
                videos.Add(nestedDataSet);

                Dictionary<string, dynamic> dataSet = new Dictionary<string, dynamic>
                {
                    {"activeVideo", 0}, // DONE this is added as a string for some reason -> False alarm I guess
                    {"videos", videos},
                    {"Count", 1} // DONE See if this is actually added to the json -> Seems good
                };

                string videoJson = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
                File.WriteAllText(trackFolder + @"video.json", videoJson.Replace("\"[", "[").Replace("]\"", "]"));
                Console.WriteLine(videoJson);


            }
            // TODO Better file deletion routines -> File won't get deleted if you switch track before downloading
            File.Delete(trackFolder + @"video.info.json");
        }

    }


}



