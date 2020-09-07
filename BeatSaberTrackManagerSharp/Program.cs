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

namespace BeatSaberTrackManagerSharpened
{
    public partial class Form1 : Form
    {
        //Set some variables
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private JObject videoInfo;

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
                var index = htmlCode.IndexOf("watch?");
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
                 videoInfo = (JObject) JToken.ReadFrom(reader);

                var video_json = videoInfo.ToString();

                textBox2.Text = video_json;
                label1.Text = (string) videoInfo["title"];

                TimeSpan t = TimeSpan.FromSeconds((int) videoInfo["duration"]);
                string video_duration = t.ToString(@"m\:ss");
                label2.Text = video_duration;

                var thumbnail_url = (string) videoInfo["thumbnail"];

                //C# doesn't support webp, use jpg instead
                thumbnail_url = thumbnail_url.Replace("_webp", "").Replace("webp", "jpg");
                thumbnail_url = thumbnail_url.Substring(0, thumbnail_url.LastIndexOf("jpg") + 3);
                pictureBox1.Load(thumbnail_url);
                button4.Enabled = true;

            }
            File.Delete(trackFolder + @"video.info.json");

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
            //Download
            string trackFolder = textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\";
            var video_url = (string) videoInfo["webpage_url"];

            string BsMainFolder = Path.GetFullPath(Path.Combine(textBox3.Text, @"..\..\"));

            System.Diagnostics.Process dlVideo = new System.Diagnostics.Process();
            dlVideo.StartInfo.FileName = BsMainFolder + @"\Youtube-dl\youtube-dl.exe";
            
            // TODO add exception handling when video quality is less than 480p
            dlVideo.StartInfo.Arguments = video_url +
                                          " -f mp4[height>=480][height<1080]+bestaudio[ext=m4a] -o \""+ trackFolder + "%(title)s.%(ext)s\" --no-playlist --cookies F:/cookies.txt";
            dlVideo.Start();
            dlVideo.WaitForExit();
            
            var info = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(videoInfo.ToString());

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

    }


}



