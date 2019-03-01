using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Un4seen.Bass;

namespace Client.Windows
{
    using static MainWindow;
    using static Bass;

    internal class Analyzer
    {
        private int Lines = 64;
        public float[] FFT;
        public static List<byte> SpectrumData;
        private DispatcherTimer Timer;

        public Analyzer()
        {
            FFT = new float[32768];
            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromMilliseconds(25);
            Timer.IsEnabled = true;

            SpectrumData = new List<byte>();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int Data = BASS_ChannelGetData(AudioStream, FFT, Convert.ToInt32(BASSData.BASS_DATA_FFT32768));
            if (Data < -1)
                return;

            int x, y;
            int b0 = 0;

            for (x = 0; x < Lines; x++)
            {
                float peak = 0;
                int b1 = Convert.ToInt32(Math.Pow(2, x * 10.0 / (Lines - 1)));
                if (b1 > 1023) b1 = 1023;
                if (b1 <= b0) b1 = b0 + 1;
                for (; b0 < b1; b0++)
                {
                    if (peak < FFT[1 + b0]) peak = FFT[1 + b0];
                }
                y = Convert.ToInt32((Math.Sqrt(peak) * 3 * 255 - 4));
                if (y > 255) y = 255;
                if (y < 0) y = 0;

                

                SpectrumData.Add(Convert.ToByte(y));
            }


            //SoundVisualization.trackBar1.Value = SpectrumData[1];



            SpectrumData.Clear();
           
        }

    }


}
