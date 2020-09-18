using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using MediaToolkit;
using MediaToolkit.Model;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

//TODO turn ["videos"][0] to ["videos"][av]
//TODO See 1a3f video.json generation, also 853e
//DONE Dynamic BS path
//DONE Aubio won't accept the audio format -> Use the ffmpeg version

namespace BeatSaberTrackManagerSharpened
{
    public partial class Form1 : Form
    {
        //Set some variables
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private JObject videoInfo;
        public string trackFilename;
        public string videoFilename;

        [STAThread]
        private static void Main()
        {
            var a = new Form1();

            //Check config.ini for CustomLevels folder location
            if (File.Exists(Environment.CurrentDirectory + @"\config.ini"))
            {
                if (Directory.Exists(File.ReadAllText(Environment.CurrentDirectory + @"\config.ini")))
                {
                    a.textBox3.Text = File.ReadAllText(Environment.CurrentDirectory + @"\config.ini");
                }
                else
                {
                    a.textBox3.Text = @"C:\";
                }
            }
            else
            {
                a.textBox3.Text = @"C:\";
            }

            a.fill_listbox();

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(a);
        }

        public void fill_listbox()
        {
            // Listview creates an empty row in the beginning -> clear list first
            listView1.Items.Clear();

            if (textBox3.Text.Contains("CustomLevels"))
            {
                var subDirs = Directory.GetDirectories(textBox3.Text)
                    .Select(Path.GetFileName)
                    .ToArray();

                foreach (var i in subDirs) listView1.Items.Add(i);

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
            button5.Enabled = false;
        }

        public void updateListbox(string[] subDirs, bool filter)
            // Filter results based on combobox value
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (filter)
                    {
                        foreach (var i in subDirs)
                            if (i.ToLower().Contains(textBox4.Text.ToLower()))
                                listView1.Items.Add(i);
                    }
                    else
                    {
                        foreach (var i in subDirs) listView1.Items.Add(i);
                    }

                    break;
                case 1:
                    if (filter)
                    {
                        foreach (var i in subDirs)
                            if (i.ToLower().Contains(textBox4.Text.ToLower()))
                                listView1.Items.Add(i);
                    }
                    else
                    {
                        foreach (var i in subDirs)
                            if (File.Exists(textBox3.Text + @"\" + i + @"\video.json") == false)
                                if (i.ToLower().Contains(textBox4.Text.ToLower()))
                                    listView1.Items.Add(i);
                    }

                    break;
                case 2:
                    if (filter)
                    {
                        foreach (var i in subDirs)
                            if (i.ToLower().Contains(textBox4.Text.ToLower()))
                                listView1.Items.Add(i);
                    }
                    else
                    {
                        foreach (var i in subDirs)
                            if (i.ToLower().Contains(textBox4.Text.ToLower()))
                                listView1.Items.Add(i);
                    }

                    break;
            }
        }

        private string ReplaceSymbols(string filename)
        {
            //Replace symbols that cannot be used in file names
            //Also replaces few symbols that youtubeDl replaces automatically 

            var ngSymbols = new List<string> {"*", "/", "\\", "<", ">", "|"};

            foreach (var i in ngSymbols) filename = filename.Replace(i, "_");

            filename = filename.Replace("?", "");
            filename = filename.Replace(":", " -");
            filename = filename.Replace("\"", "'");

            return filename;
        }

        public dynamic fetch_video_json(string track_path)
        {
            string video_json;
            JObject videoInfo;

            if (File.Exists(track_path + @"\video.json"))
                try
                {
                    using (var file = File.OpenText(track_path + @"\video.json"))
                    using (var reader = new JsonTextReader(file))
                    {
                        videoInfo = (JObject) JToken.ReadFrom(reader);

                        video_json = videoInfo.ToString();
                        Console.WriteLine(video_json);
                    }

                    if (videoInfo["videos"] == null)
                    {
                        var newJson = "{activeVideo: '0', videos: [" + video_json + "]}";
                        videoInfo = JObject.Parse(newJson);
                        Console.WriteLine(videoInfo.ToString());
                    }

                    var av = (int) videoInfo["activeVideo"];

                    if (videoInfo["videos"][av]["videopath"] != null)
                    {
                        videoInfo["videos"][av]["videoPath"] = videoInfo["videos"][av]["videopath"];
                        videoInfo["videos"][av]["videopath"].Remove();
                    }

                    //Replace unaccepted symbols in video file name
                    videoInfo["videos"][av]["videoPath"] = ReplaceSymbols(videoInfo["videos"][av]["videoPath"].ToString());

                    //Fix long video url
                    if (videoInfo["videos"][av]["URL"].ToString().Contains("youtube"))
                        videoInfo["videos"][av]["URL"] = videoInfo["videos"][av]["URL"].ToString().Substring(23);

                    //Fix thumbnail url
                    if (videoInfo["videos"][av]["thumbnailURL"].ToString().Contains("?"))
                    {
                        var thumbnailUrl = videoInfo["videos"][av]["thumbnailURL"].ToString();
                        thumbnailUrl = thumbnailUrl.Substring(0, thumbnailUrl.IndexOf("?"));
                        videoInfo["videos"][av]["thumbnailURL"] = thumbnailUrl;
                    }

                    video_json = videoInfo.ToString();
                    Console.WriteLine(video_json);

                    File.WriteAllText(track_path + @"\video.json", video_json);

                    return video_json;
                }
                catch (JsonReaderException ex)
                {
                    label1.Text = "video.json empty or not in proper format!";
                    Logger.Error(ex, listView1.SelectedItems[0].Text + " - video.json empty or not in proper format!");
                    //Professionally returning false as a string :)
                    return "false";
                }

            return "false";
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
                    try
                    {
                        JObject videoInfo = JObject.Parse(video_json);

                        //Grab video data from video.json
                        label1.Text = (string) videoInfo["videos"][0]["title"];
                        label2.Text = (string) videoInfo["videos"][0]["duration"];
                        var thumbnail_url = (string) videoInfo["videos"][0]["thumbnailURL"];
                        thumbnail_url = thumbnail_url.Replace("_webp", "").Replace("webp", "jpg");
                        pictureBox1.Load(thumbnail_url);

                        //Video file name
                        videoFilename = textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\" + (string)videoInfo["videos"][0]["videoPath"];

                        //Video size
                        var videofile = new FileInfo(textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\" +
                                                     (string) videoInfo["videos"][0]["videoPath"]);
                        var size = videofile.Length;

                        //Video height
                        var shellFile = ShellFile.FromFilePath(textBox3.Text + @"\" + listView1.SelectedItems[0].Text +
                                                               @"\" + (string) videoInfo["videos"][0]["videoPath"]);
                        var videoWidth = (int) shellFile.Properties.System.Video.FrameHeight.Value;

                        label5.Text = "Video downloaded - " + size / 1000000 + " MB - " + videoWidth + "p";
                        label6.Text = "Offset: " + (string) videoInfo["videos"][0]["offset"];
                        button5.Enabled = true;
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
                        Logger.Error(ex,
                            listView1.SelectedItems[0].Text + " - Thumbnail format not supported -> webp? ");
                    }

                    catch (DirectoryNotFoundException ex)
                    {
                        Logger.Error(ex, textBox3.Text + " - Not the BS directory ");
                    }

                    catch (WebException ex)
                    {
                        pictureBox1.Load("https://s.ytimg.com/yts/img/no_thumbnail-vfl4t3-4R.jpg");
                        Logger.Error(ex,
                            listView1.SelectedItems[0].Text + " - No thumbnail found, using default thumbnail. ");
                    }

                try
                {
                    // Grab track information from info.dat
                    using (var file =
                        File.OpenText(textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\info.dat"))
                    using (var reader = new JsonTextReader(file))
                    {
                        var trackInfo = (JObject) JToken.ReadFrom(reader);

                        var track_json = trackInfo.ToString();

                        trackFilename = textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\" +
                                            (string) trackInfo["_songFilename"];
                        var f = new FileInfo(trackFilename);

                        //Grab track's duration
                        //Third times the charm, MediaToolkit grabs the track duration properly (unlike some other ones <_<) from uncommon extensions
                        var inputFile = new MediaFile {Filename = trackFilename};

                        using (var engine = new Engine())
                        {
                            engine.GetMetadata(inputFile);
                        }

                        Console.WriteLine(inputFile.Metadata.Duration);
                        var dur = inputFile.Metadata.Duration;
                        label3.Text = inputFile.Metadata.Duration.ToString(@"m\:ss");

                        textBox1.Text = (string) trackInfo["_songName"] + " " + (string) trackInfo["_songAuthorName"];

                        label4.Text = (string) trackInfo["_songName"] + " - " + (string) trackInfo["_levelAuthorName"];
                        pictureBox2.Load(textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\" +
                                         (string) trackInfo["_coverImageFilename"]);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Logger.Error(ex);
                    label4.Text = "info.dat missing!";
                    textBox1.Text = listView1.SelectedItems[0].Text
                        .Substring(listView1.SelectedItems[0].Text.IndexOf("(") + 1);
                    button5.Enabled = false;
                }

                catch (DirectoryNotFoundException ex)
                {
                    Logger.Error(ex, listView1.SelectedItems[0].Text + " - Not the BS directory");
                }
                catch (JsonReaderException ex)
                {
                    label4.Text = "info.dat empty or not in proper format!";
                    Logger.Error(ex, listView1.SelectedItems[0].Text + " - info.dat empty or not in proper format!");
                    textBox1.Text = listView1.SelectedItems[0].Text
                        .Substring(listView1.SelectedItems[0].Text.IndexOf("(") + 1);
                    button5.Enabled = false;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //FIXED Making this dynamic causes issues -> Set combobox default name as the 0 index
                var subDirs = Directory.GetDirectories(textBox3.Text)
                    .Select(Path.GetFileName)
                    .ToArray();

                listView1.Items.Clear();
                clear_info();

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        foreach (var i in subDirs) listView1.Items.Add(i);
                        break;

                    case 1:
                        foreach (var i in subDirs)
                            if (File.Exists(textBox3.Text + @"\" + i + @"\video.json") == false)
                                listView1.Items.Add(i);
                        break;

                    case 2:
                        foreach (var i in subDirs)
                            if (File.Exists(textBox3.Text + @"\" + i + @"\video.json"))
                                listView1.Items.Add(i);
                        break;
                }
            }
            catch (ArgumentException)
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
                var o = JObject.Parse(videoUrl);

                //TODO change 0 to av
                videoUrl = "www.youtube.com" + o["videos"][0]["URL"];
                Process.Start(videoUrl);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //Replace the horrible FolderBrowser with CommonOpenFile
            var openBSFolder = new CommonOpenFileDialog();
            openBSFolder.InitialDirectory = textBox3.Text;
            openBSFolder.IsFolderPicker = true;

            if (openBSFolder.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (openBSFolder.FileName.Contains("CustomLevels"))
                {
                    Console.WriteLine(Directory.GetCurrentDirectory());
                    textBox3.Text = openBSFolder.FileName;
                    clear_info();
                    fill_listbox();

                    File.WriteAllText(Environment.CurrentDirectory + @"\config.ini", textBox3.Text);
                }
                else
                {
                    Console.WriteLine("Not the CustomLevels Folder!");
                    clear_info();
                    listView1.Items.Clear();
                }


            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Open track folder
            Process.Start("explorer.exe", textBox3.Text + @"\" + listView1.SelectedItems[0].Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Search Youtube
            string videoUrl;
            var BsMainFolder = Path.GetFullPath(Path.Combine(textBox3.Text, @"..\..\"));
            var trackFolder = textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\";
            Console.WriteLine(trackFolder);

            //ytsearch is very finicky at the moment, so grab the video url with WebClient instead
            using (var client = new WebClient())
            {
                var htmlCode = client.DownloadString("https://www.youtube.com/results?search_query=" +
                                                     textBox1.Text.Replace(" ", "+"));
                var index = htmlCode.IndexOf("watch?");
                var videoId = htmlCode.Substring(index + 8, 11);
                videoUrl = "https://www.youtube.com/watch?v=" + videoId;
                Console.WriteLine(videoUrl);
            }

            //Use cmdline instead of NYoutubeDL
            //NYoutubeDL is confusing
            var dlVideo = new Process();
            dlVideo.StartInfo.FileName = BsMainFolder + @"\Youtube-dl\youtube-dl.exe";

            //youtubeDl output template is weird
            dlVideo.StartInfo.Arguments =
                //"ytsearch:\"" + textBox1.Text + "\" -o \""+ trackFolder + "video\" --skip-download --write-info-json";
                videoUrl + " -o \"" + trackFolder +
                "video\" --skip-download --write-info-json --cookies F:/cookies.txt";
            //dlVideo.StartInfo.RedirectStandardOutput = true;
            //dlVideo.StartInfo.UseShellExecute = false;
            dlVideo.Start();
            //string stdout = dlVideo.StandardOutput.ReadToEnd();
            dlVideo.WaitForExit();
            //MessageBox.Show(stdout);

            using (var file = File.OpenText(trackFolder + @"video.info.json"))
            using (var reader = new JsonTextReader(file))
            {
                videoInfo = (JObject) JToken.ReadFrom(reader);

                var video_json = videoInfo.ToString();

                label1.Text = (string) videoInfo["title"];

                var t = TimeSpan.FromSeconds((int) videoInfo["duration"]);
                var video_duration = t.ToString(@"m\:ss");
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
            var subDirs = Directory.GetDirectories(textBox3.Text)
                .Select(Path.GetFileName)
                .ToArray();

            if (textBox4.Text.Length >= 3)
            {
                listView1.Items.Clear();
                clear_info();

                foreach (var i in subDirs)
                    if (i.ToLower().Contains(textBox4.Text.ToLower()))
                        listView1.Items.Add(i);
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
            var trackFolder = textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\";
            var video_url = (string) videoInfo["webpage_url"];

            var BsMainFolder = Path.GetFullPath(Path.Combine(textBox3.Text, @"..\..\"));

            var dlVideo = new Process();
            dlVideo.StartInfo.FileName = BsMainFolder + @"\Youtube-dl\youtube-dl.exe";

            // TODO add exception handling when video quality is less than 480p
            dlVideo.StartInfo.Arguments = video_url +
                                          " -f mp4[height>=480][height<1080]+bestaudio[ext=m4a] -o \"" + trackFolder +
                                          "%(title)s.%(ext)s\" --no-playlist --cookies F:/cookies.txt";
            dlVideo.Start();
            dlVideo.WaitForExit();

            var info = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(videoInfo.ToString());

            var video_duration = TimeSpan.FromSeconds(info["duration"]);

            //Generate video json
            var nestedDataSet = new Dictionary<string, dynamic>
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

            var videos = new List<dynamic>();
            videos.Add(nestedDataSet);

            var dataSet = new Dictionary<string, dynamic>
            {
                {"activeVideo", 0}, // DONE this is added as a string for some reason -> False alarm I guess
                {"videos", videos},
                {"Count", 1} // DONE See if this is actually added to the json -> Seems good
            };

            var videoJson = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            File.WriteAllText(trackFolder + @"video.json", videoJson.Replace("\"[", "[").Replace("]\"", "]"));
            Console.WriteLine(videoJson);
        }
        private void button5_Click(object sender, System.EventArgs e)
        {
            //Auto offset

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"aubio\bin\");

            //https://markheath.net/post/naudio-play-extract
            using (var file = new NAudio.Vorbis.VorbisWaveReader(trackFilename))
            {
                var trimmed = new OffsetSampleProvider(file);
                //trimmed.SkipOver = TimeSpan.FromSeconds(15);
                trimmed.Take = TimeSpan.FromSeconds(10);

                //var player = new WaveOutEvent();
                //player.Init(trimmed);
                //player.Play();
                WaveFileWriter.CreateWaveFile16(path + "track.wav", trimmed);
            }

            try
            {
                using (var reader = new MediaFoundationReader(videoFilename))
                {
                    var trimmed = new OffsetSampleProvider(reader.ToSampleProvider());
                    trimmed.Take = TimeSpan.FromSeconds(10);

                    WaveFileWriter.CreateWaveFile16(path + "video.wav", trimmed);

                }

                //First process

                var aubioTrack = new Process();
                aubioTrack.StartInfo.FileName = path + "aubioonset.exe";

                aubioTrack.StartInfo.Arguments = "-T ms " + path + "track.wav";
                aubioTrack.StartInfo.RedirectStandardOutput = true;
                aubioTrack.StartInfo.UseShellExecute = false;

                List<string> trackOnsetValues = new List<string>();

                aubioTrack.Start();

                while (!aubioTrack.StandardOutput.EndOfStream)
                {
                    trackOnsetValues.Add(aubioTrack.StandardOutput.ReadLine());
                }

                Console.WriteLine(trackOnsetValues[0]);
                aubioTrack.WaitForExit();

                //Second process

                var aubioVideo = new Process();
                aubioVideo.StartInfo.FileName = path + "aubioonset.exe";

                aubioVideo.StartInfo.Arguments = "-T ms " + path + "video.wav";
                aubioVideo.StartInfo.RedirectStandardOutput = true;
                aubioVideo.StartInfo.UseShellExecute = false;

                List<string> videoOnsetValues = new List<string>();

                aubioVideo.Start();

                while (!aubioVideo.StandardOutput.EndOfStream)
                {
                    videoOnsetValues.Add(aubioVideo.StandardOutput.ReadLine());
                }

                Console.WriteLine(videoOnsetValues[0]);
                aubioVideo.WaitForExit();

                var trackOnset = int.Parse(trackOnsetValues[0].Substring(0, trackOnsetValues[0].IndexOf(".")));
                var videoOnset = int.Parse(videoOnsetValues[0].Substring(0, videoOnsetValues[0].IndexOf(".")));

                var offset = videoOnset - trackOnset;
                Console.WriteLine(offset);

                string videoJson;

                //Update video.json
                using (var file = File.OpenText(textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\video.json"))
                using (var reader = new JsonTextReader(file))
                {
                    videoInfo = (JObject)JToken.ReadFrom(reader);

                    var av = (int)videoInfo["activeVideo"];
                    videoInfo["videos"][av]["offset"] = offset;

                    videoJson = videoInfo.ToString();

                }

                File.WriteAllText(textBox3.Text + @"\" + listView1.SelectedItems[0].Text + @"\video.json", videoJson);
                label6.Text = "Offset: " + offset;

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                Console.WriteLine("Video has no audio track!");
                label6.Text = "Video has no audio track";
                Logger.Error(ex + listView1.SelectedItems[0].Text + " - Video has no audio track");
            }

            File.Delete(path + "track.wav");
            File.Delete(path + "video.wav");

        }
    }
}