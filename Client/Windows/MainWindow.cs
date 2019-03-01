using System.Runtime.InteropServices;
using SharedCoreLib.AudioProcessing;
using Un4seen.Bass.AddOn.Tags;
using System.ComponentModel;
using System.Windows.Forms;
using RoboRadio.Windows;
using System.Threading;
using System.Drawing;
using Un4seen.Bass;
using System.Text;
using DiscordRPC;
using System.IO;
using System;
using Shazam;
    
namespace RoboRadio
{   
    using static Bass;

    public partial class MainWindow : Form
    {

        #region Varables

        bool hided = true;
        bool pause = true;
        public int audioStream;
        private ShazamClient client;
        private int counter = 10;
        private IContainer components;
        TAG_INFO songInfo;

        private RECORDPROC recProc;
        private int bytesWritten = 0;
        private byte[] recBuffer;
        private int recHandle;
        private int currentStation;
        public Random random = new Random();
        private string trayString;
        private bool isInTray = false;
        public RichPresence discordSongInfo = new RichPresence();

        private IntPtr bassHandle = (IntPtr)4;
        private Thread BassThread;

        readonly object countLock = new object();
        private bool threadStarted = false;
        #endregion

        #region Setting Varables

        public Color visColor = Color.Tomato;
        public bool saveLastStation = true;
        public bool saveShazamState = true;
        public int lastStationNumber = -1;
        public bool isShazamEnabled = true;
        public string visMode = "Default";
        public bool WTFMode = false;
        public bool isTray = false;
        public bool isTrayStart = false;
        public bool showInfo = true;
        public bool isRichPresence = true;
        public bool isFilteringEnabled = true;

        private int _volume;
        public int volume
        {
            get => _volume;
            set
            {
                if (value < VolumeBar.Minimum || value > VolumeBar.Maximum)
                    return;

                _volume = value;
                BASS_ChannelSetAttribute(audioStream, BASSAttribute.BASS_ATTRIB_VOL, value / 100f);
                VolumeBox.Text = Convert.ToString(value);
                VolumeBar.Value = value;
            }
        }

        #endregion

        #region Main Actions

        public MainWindow()
        {
            InitializeComponent();           
            ProgramInit();            
        }

        private void ProgramInit()
        {
#if DEBUG
            Console.WriteLine("Init started!");
#endif

            #region Initialization
            BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, bassHandle);           
            BASS_RecordInit(-1);
            recProc = new RECORDPROC(MyRecording);         
            CheckMicrophone();                        
            KeyDown += new KeyEventHandler(AltMenuKey);
            client = new ShazamClient();
            client.OnRecongnitionStateChanged += new ShazamStateChangedCallback(ShazamStateChanged);

            NotifyIcon.Icon = Icon;

            DiscordIntegration.Init();

            UpdateTimer.Start();
            #endregion

#if DEBUG
            Console.WriteLine("Init ended!");
#endif
        }

        private void ProgramLoad()
        {
#if DEBUG
            Console.WriteLine("Load started!");
#endif

            #region Loading
            LoadSettings();

            if (showInfo)
                InfoOpen();

            for (int i = 0; i < StationsList.stationsListXML.Count; i++)
            {
                RadioStation.Items.Add(StationsList.stationsListXML[i].name);
            }

            LoadLastStation();
            SwitchShazam();

            isInTray = isTrayStart;
            #endregion

#if DEBUG
            Console.WriteLine("Load ended!");
#endif
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ProgramLoad();
        }


        private void BassThreadInit(object station)
        {
            while (true)
            {
                lock (countLock)
                {
                    if (!threadStarted)
                    {
                        threadStarted = true;
                        break;
                    }
                }
                return;
            }

#if DEBUG
            Console.WriteLine("BASS thread started!");
            Console.WriteLine("BASS state: " + BASS_ErrorGetCode());
#endif
            

            if (!pause)
                pause = true;

            BASS_StreamFree(audioStream);
            audioStream = BASS_StreamCreateURL((string)station, 2, BASSFlag.BASS_DEFAULT, null, bassHandle);
            BASS_ChannelPlay(audioStream, false);
            songInfo = new TAG_INFO((string)station);
            BASS_ChannelSetAttribute(audioStream, BASSAttribute.BASS_ATTRIB_VOL, volume / 100f);

            threadStarted = false;

#if DEBUG
            Console.WriteLine("BASS thread ended!");
#endif
        }

        private void FrameCounter_Tick(object sender, EventArgs e)
        {
            GetSongInfo();
        }

        private void RPCUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!isShazamEnabled)
            {
                discordSongInfo.Details = TitleBox.Text;
                discordSongInfo.State = ArtistBox.Text;
            }
            else
            {
                discordSongInfo.Details = "Shazam Mode";
                discordSongInfo.State = String.Empty;
            }

            discordSongInfo.Assets = new Assets()
            {
                LargeImageKey = "main_image",
                LargeImageText = "Current Station: " + StationsList.stationsListXML[currentStation].name
            };


            DiscordIntegration.clientRPC.SetPresence(discordSongInfo);
            DiscordIntegration.clientRPC.Invoke();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (isRichPresence)
                RPCUpdateTimer.Start();
            else
            {
                DiscordIntegration.clientRPC.ClearPresence();
                RPCUpdateTimer.Stop();
            }

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProgramExit();
        }

        #endregion

        #region Buttons

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (pause)
            {
                BASS_ChannelPause(audioStream);
                pause = false;
                return;
            }

            BASS_ChannelPlay(audioStream, false);
            pause = true;
        }

        private void AddStation_Click(object sender, EventArgs e)
        {
            AddStation.Enabled = false;
            DeleteStation.Enabled = false;
            RadioStationAdd AddStationWindow = new RadioStationAdd();
            AddStationWindow.Show();
        }

        private void DeleteStationMenuItem_Click(object sender, EventArgs e)
        {
            AddStation.Enabled = false;
            DeleteStation.Enabled = false;
            RadioStationDelete DelStation = new RadioStationDelete();
            DelStation.Show();
        }

        private void AltMenuKey(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 18 && hided)
            {
                Menu.Show();
                hided = false;
            }
            else if (e.KeyValue == 18)
            {
                Menu.Hide();
                hided = true;
            }
        }

        private void RandomStation_Click(object sender, EventArgs e)
        {
            ChangeRandomStation();
        }

        private void EnableShazam_Click(object sender, EventArgs e)
        {
            SwitchShazam();
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            OptionsMenu Options = new OptionsMenu();
            Enabled = false;
            Options.Show();
        }

        private void Volume_Scroll(object sender, EventArgs e)
        {
            volume = VolumeBar.Value;
        }

        private void RadioStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeStation();
        }

        private void EnableVisualizationButton_Click(object sender, EventArgs e)
        {
            VisTray.Enabled = false;
            EnableVisualizationButton.Enabled = false;
            SoundVisualization SoundVisualization = new SoundVisualization();
            SoundVisualization.Show();
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainWindow_Shown(sender, e);
        }

        private void ShazamTray_Click(object sender, EventArgs e)
        {
            ShazamStartInit();
        }

        private void ExitTray_Click(object sender, EventArgs e)
        {
            ProgramExit();
        }

        private void VisTray_Click(object sender, EventArgs e)
        {
            VisTray.Enabled = false;
            EnableVisualizationButton.Enabled = false;
            SoundVisualization SoundVisualization = new SoundVisualization();
            SoundVisualization.Show();
        }

        private void Info_Click(object sender, EventArgs e)
        {
            InfoOpen();
        }

        private void AddFilter_Click(object sender, EventArgs e)
        {
            AddFilter.Enabled = false;
            DeleteFilter.Enabled = false;
            FilterAdd AddFilterWindow = new FilterAdd();
            AddFilterWindow.Show();
        }

        private void DeleteFilter_Click(object sender, EventArgs e)
        {
            AddFilter.Enabled = false;
            DeleteFilter.Enabled = false;
            FilterDelete DelFilter = new FilterDelete();
            DelFilter.Show();
        }

        void RadioStation_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        

        #endregion

        #region Shazam  

        public void ShazamStateChanged(ShazamRecognitionState State, ShazamResponse response)
        {
            switch (State)
            {
                case ShazamRecognitionState.Sending:
                    return;
                case ShazamRecognitionState.Matching:
                    return;
                case ShazamRecognitionState.Done:
                    StartShazam.Enabled = true;
                    EnableShazam.Enabled = true;
                    ShazamProgress.Value = 0;
                    if (response.Tag == null)
                    {
                        MessageBox.Show("Song not found!", "Shazam");
                        return;
                    }
                    if (response.Tag.Track != null)
                    {
                        if (isTray)
                            MessageBox.Show(String.Format("Title: {0}\nArtist: {1}", response.Tag.Track.Title, response.Tag.Track.Artist));
                        else
                        {
                            TitleBox.Text = Convert.ToString(response.Tag.Track.Title);
                            ArtistBox.Text = Convert.ToString(response.Tag.Track.Artist);    
                            
                        }
                        return;
                    }
                    MessageBox.Show("Song Not Found!", "Shazam");
                    return;
                case ShazamRecognitionState.Failed:
                    StartShazam.Enabled = true;
                    EnableShazam.Enabled = true;
                    if (response.Exception.Message != null && response.Exception.Message != "")
                    {
                        MessageBox.Show("Song Not Found! \nError Message: " + response.Exception.Message, "Shazam");
                    }
                    return;
                default:
                    return;
            }
        }

        private void StartShazam_Click(object sender, EventArgs e)
        {
            ShazamStartInit();
        }

        private void ShazamTimer_Stop(object sender, EventArgs e)
        {
            BASS_ChannelStop(recHandle);
            this.ShazamTimer.Stop();
            this.ProcessPCMAudio(44100, 16, 1);
            Encoding.UTF8.GetString(this.recBuffer);
            this.client.DoRecognition(this.recBuffer, MicrophoneRecordingOutputFormatType.PCM);
            this.ShazamTimer.Stop();
            this.RecordTimer.Stop();
        }

        private void ProcessPCMAudio(int sampleRate, short numBitsPerSample, short numChannels)
        {
            int size = recBuffer.Length;
            WaveFile.WaveHeader header = new WaveFile.WaveHeader(size, sampleRate, numBitsPerSample, numChannels, false);
            MemoryStream memoryStream = WaveFile.WriteWaveFile(header, this.recBuffer);
            this.recBuffer = memoryStream.GetBuffer();

        }

        private void RecordTimer_Tick(object sender, EventArgs e)
        {
            this.counter--;
            ShazamProgress.Value += 100;
        }

        private bool MyRecording(int Handle, IntPtr Buffer, int Length, IntPtr User)
        {
            bool Continue = true;

            if (Length > 0 && Buffer != IntPtr.Zero)
            {
                Marshal.Copy(Buffer, recBuffer, bytesWritten, Length);
                bytesWritten += Length;
                if (counter == 0 || bytesWritten > recBuffer.Length)
                    return Continue;
            }

            return Continue;
        }

        #endregion

        #region Useful Methods

        private void GetSongInfo()
        {
            if (BassTags.BASS_TAG_GetFromURL(audioStream, songInfo))
            {
                if (isFilteringEnabled && FiltersList.filtersListXML.Count > 0)
                {                   
                    for (int i = 0; i < FiltersList.filtersListXML.Count; i++)
                    {
                        try
                        {                        

                            if (FiltersList.filtersListXML[i].isTwoFields)
                            {
                                TitleBox.Text = Functions.FilterTwoStrings(songInfo.title, FiltersList.filtersListXML[i].title);
                                ArtistBox.Text = Functions.FilterTwoStrings(songInfo.artist, FiltersList.filtersListXML[i].artist);
                            }
                            else
                            {
                                TitleBox.Text = Functions.FilterString(Convert.ToString(songInfo.title), FiltersList.filtersListXML[i].title, FiltersList.filtersListXML[i].artist).title;
                                ArtistBox.Text = Functions.FilterString(Convert.ToString(songInfo.title), FiltersList.filtersListXML[i].title, FiltersList.filtersListXML[i].artist).artist;
                            }

                            if (TitleBox.Text != Convert.ToString(songInfo.title))
                               return;
                        }

                        catch
                        {
                            TitleBox.Text = Convert.ToString(songInfo.title);
                            ArtistBox.Text = Convert.ToString(songInfo.artist);                 
                        }
                    }
                }

                else
                {
                    TitleBox.Text = Convert.ToString(songInfo.title);
                    ArtistBox.Text = Convert.ToString(songInfo.artist);
                }
               trayString = String.Format("Now Playing: {0} by {1}", TitleBox.Text, ArtistBox.Text);

                try
                {
                    if (isTray)
                        NotifyIcon.Text = trayString;
                }

                catch (ArgumentOutOfRangeException)
                {
                    return;
                }

            }
        }

        private void ChangeStation()
        {
            BassThread = new Thread(new ParameterizedThreadStart(BassThreadInit));

            BassThread.IsBackground = true;
            BassThread.Name = Convert.ToString(RadioStation.SelectedIndex);

            BassThread.Start(StationsList.stationsListXML[RadioStation.SelectedIndex].link);

            currentStation = RadioStation.SelectedIndex;

            if (saveLastStation)
                lastStationNumber = RadioStation.SelectedIndex;

        }

        private void ChangeRandomStation()
        {
            int Count = StationsList.stationsListXML.Count;
            int RandomStation = random.Next(1, Count);
            RadioStation.Text = StationsList.stationsListXML[RandomStation].name;
        }

        public void LoadLastStation()
        {
            if (!saveLastStation || lastStationNumber < 0 || lastStationNumber > StationsList.stationsListXML.Count)
                return;

            RadioStation.Text = StationsList.stationsListXML[lastStationNumber].name;
            pause = true;
        }

        public void LoadSettings()
        {

            StationsList.StationsLoad();
            FiltersList.FiltersLoad();
            OptionsController.OptionsRead();

            if (saveShazamState)
                SwitchShazam();

        }

        private void SwitchShazam()
        {

            if (CheckOS())
            {
                StartShazam.Enabled = false;
                isShazamEnabled = false;
                EnableShazam.Enabled = false;
                return;
            }

            if (isShazamEnabled)
            {
                FrameCounter.Start();
                StartShazam.Enabled = false;
                ShazamTray.Enabled = false;
                isShazamEnabled = false;
                EnableShazam.Checked = isShazamEnabled;
                return;
            }

            FrameCounter.Stop();
            StartShazam.Enabled = true;
            ShazamTray.Enabled = true;
            isShazamEnabled = true;
            TitleBox.Text = String.Empty;
            ArtistBox.Text = String.Empty;
            EnableShazam.Checked = isShazamEnabled;
            trayString = "Try To Shazam!";

            if (isTray)
                NotifyIcon.Text = trayString;
        }

        private bool CheckOS()
        {
            string CurrentOS = Convert.ToString(Environment.OSVersion);
            if (CurrentOS.Contains("5.1") || CurrentOS.Contains("5.2"))
                return true;
            else
                return false;
        }

        private void CheckMicrophone()
        {
            if (BASS_RecordGetDeviceCount() == 0)
            {
                MessageBox.Show("There are no recording devices on this computer!");
                StartShazam.Enabled = false;
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && isTray)          
                HideInTray();       
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (isInTray)
            {
                Opacity = 0;
                isInTray = false;
                HideInTray();
                return;
            }

            Show();
            Opacity = 100;
            WindowState = FormWindowState.Normal;           
            NotifyIcon.Visible = false;
        }   

        private void HideInTray()
        {
            Hide();
            NotifyIcon.Visible = true;
            NotifyIcon.ContextMenuStrip = TrayMenu;
        }

        private void ProgramExit()
        {
            OptionsController.OptionsSave();
            BASS_Free();
            DiscordIntegration.clientRPC.Dispose();           
            Environment.Exit(0);
        }

        private void ShazamStartInit()
        {
            bytesWritten = 0;
            recBuffer = new byte[882000];
            recHandle = BASS_RecordStart(44100, 1, BASSFlag.BASS_RECORD_PAUSE, recProc, IntPtr.Zero);
            BASS_ChannelPlay(recHandle, false);
            this.counter = 10;
            this.ShazamTimer.Start();
            this.RecordTimer.Start();
            this.StartShazam.Enabled = false;
            EnableShazam.Enabled = false;
            TitleBox.Text = String.Empty;
            ArtistBox.Text = String.Empty;
        }

        private void InfoOpen()
        {
            Info.Enabled = false;
            InfoWindow AuthorInfo = new InfoWindow();
            AuthorInfo.Show();
            AuthorInfo.Location = new Point(Location.X + 65, Location.Y + 30);
        }

        #endregion

    }
}
