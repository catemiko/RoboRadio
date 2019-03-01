using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Un4seen.Bass;
using System;

namespace RoboRadio.Windows
{
    using static RoboRadio.Program;
    using static Bass;

    public partial class SoundVisualization : Form
    {
        #region Varables

        private int lines = 64;
        private float[] FFT;
        private static List<byte> spectrumData;

        private Timer timerVis;
        private TrackBar[] trackBarArray = new TrackBar[64];


        private Pen pencil;
        private Pen whiteRect = new Pen(Color.White, 100);


        private static Bitmap myBitmap;
        private Bitmap whiteBitmap;

        private Graphics graphicVisPanel;

        #endregion

        public SoundVisualization()
        {
            InitializeComponent();   
            FFT = new float[32768];
            timerVis = new Timer();
            timerVis.Tick += Timer_Tick;
            timerVis.Interval = 1;
            spectrumData = new List<byte>();

            myBitmap = new Bitmap(VisPanel.Width, VisPanel.Height);
            whiteBitmap = new Bitmap(VisPanel.Width, VisPanel.Height);
            graphicVisPanel = Graphics.FromImage(myBitmap);
            pencil = new Pen(MainWindowVirtual.visColor, 9);         
            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            timerVis.Start();            
        }

        private void SoundVisualization_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindowVirtual.VisTray.Enabled = true;
            MainWindowVirtual.EnableVisualizationButton.Enabled = true;

            timerVis.Stop();
            myBitmap.Dispose();
        }
          
        private void Timer_Tick(object sender, EventArgs e)
        {
            int Data = BASS_ChannelGetData(MainWindowVirtual.audioStream, FFT, Convert.ToInt32(BASSData.BASS_DATA_FFT32768));
            if (Data < -1)
                return;

            int x, y;
            int b0 = 0;

            for (x = 0; x < lines; x++)
            {
                float peak = 0;
                int b1 = Convert.ToInt32(Math.Pow(2, x * 10.0 / (lines - 1)));
                if (b1 > 1023) b1 = 1023;
                if (b1 <= b0) b1 = b0 + 1;
                for (; b0 < b1; b0++)
                {
                    if (peak < FFT[1 + b0]) peak = FFT[1 + b0];
                }
                y = Convert.ToInt32((Math.Sqrt(peak) * 2 * 255 - 4));
                if (y > 255) y = 255;
                if (y < 0) y = 1;
                spectrumData.Add(Convert.ToByte(y));
            }

        graphicVisPanel.Clear(Color.Transparent);

            VisPanel.Image = myBitmap;

            for (int i = 0; i < trackBarArray.Length; i++)
            {
                switch (MainWindowVirtual.visMode)
                {
                    case "Default":
                        #region Formula
                        graphicVisPanel.DrawLine(new Pen(Color.FromArgb(Convert.ToInt32(MainWindowVirtual.visColor.R), Convert.ToInt32(MainWindowVirtual.visColor.G), Convert.ToInt32(MainWindowVirtual.visColor.B)), 9), new Point(i * 10 + 5, VisPanel.Height), new Point(i * 10 + 5, VisPanel.Height - spectrumData[i]));
                        #endregion
                        break;

                    case "Gradient":
                        #region Formula
                        graphicVisPanel.DrawLine(new Pen(Color.FromArgb(Convert.ToInt32(((MainWindowVirtual.visColor.R / 255f) * spectrumData[i])), Convert.ToInt32(((MainWindowVirtual.visColor.G / 255f) * spectrumData[i])), Convert.ToInt32(((MainWindowVirtual.visColor.B / 255f) * spectrumData[i]))), 9), new Point(i * 10 + 5 - 1, VisPanel.Height), new Point(i * 10 + 5 - 1, VisPanel.Height - spectrumData[i]));
                        #endregion
                        break;

                    case "Rainbow":
                        #region Formula
                        graphicVisPanel.DrawLine(new Pen(Color.FromArgb(Convert.ToInt32(MainWindowVirtual.random.Next(1, 255)), Convert.ToInt32(MainWindowVirtual.random.Next(1, 255)), Convert.ToInt32(MainWindowVirtual.random.Next(1, 255))), 9), new Point(i * 10 + 5, VisPanel.Height), new Point(i * 10 + 5, VisPanel.Height - spectrumData[i]));
                        #endregion
                        break;

                    case "RainbowGradient":
                        #region Formula
                        graphicVisPanel.DrawLine(new Pen(Color.FromArgb(Convert.ToInt32(((MainWindowVirtual.random.Next(1, 255) / 255f) * spectrumData[i])), Convert.ToInt32(((MainWindowVirtual.random.Next(1, 255) / 255f) * spectrumData[i])), Convert.ToInt32(((MainWindowVirtual.random.Next(1, 255) / 255f) * spectrumData[i]))), 9), new Point(i * 10 + 5, VisPanel.Height), new Point(i * 10 + 5, VisPanel.Height - spectrumData[i]));
                        #endregion
                        break;

                    default:
                        #region Formula
                        graphicVisPanel.DrawLine(new Pen(Color.FromArgb(Convert.ToInt32(MainWindowVirtual.visColor.R), Convert.ToInt32(MainWindowVirtual.visColor.G), Convert.ToInt32(MainWindowVirtual.visColor.B)), 9), new Point(i * 10 + 5, VisPanel.Height), new Point(i * 10 + 5, VisPanel.Height - spectrumData[i]));
                        #endregion
                        break;

                }

                
            }

            VisPanel.Invalidate();
            spectrumData.Clear();
        }
        
    }

}
