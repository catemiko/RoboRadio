using System;
using Nini.Config;
using System.IO;

namespace RoboRadio
{
    using System.Drawing;
    using System.Windows.Forms;
    using static RoboRadio.Program;

    static class OptionsController
    {
        public delegate void Setter<T>(T val);
        public delegate T Loader<T>(IConfig Config);
        
        public const string SAVING = "Saving";
        public static void OptionsRead()
        {
            if (!File.Exists("Options.ini"))
            {               
                OptionsSave();
            }

            IConfigSource Source = new IniConfigSource("Options.ini");
            Load(Source, (Config) => Config.GetInt("SoundVolume"), (x) => MainWindowVirtual.volume = x);
            Load(Source, (Config) => Config.GetBoolean("ShowInfo"), (x) => MainWindowVirtual.showInfo = x);
            Load(Source, (Config) => Config.GetBoolean("SaveStationOnExit"), (x) => MainWindowVirtual.saveLastStation = x);
            Load(Source, (Config) => Config.GetBoolean("SaveShazamStateOnExit"), (x) => MainWindowVirtual.saveShazamState = x);
            Load(Source, (Config) => Config.GetInt("SavedStationNumber"), (x) => MainWindowVirtual.lastStationNumber = x);
            Load(Source, (Config) => Config.GetBoolean("ShazamState"), (x) => MainWindowVirtual.isShazamEnabled = x);
            Load(Source, (Config) => Config.GetBoolean("MinimizeTray"), (x) => MainWindowVirtual.isTray = x);
            Load(Source, (Config) => Config.GetBoolean("StartInTray"), (x) => MainWindowVirtual.isTrayStart = x);
            Load(Source, (Config) => Config.GetInt("VisColor"), (x) => MainWindowVirtual.visColor = Color.FromArgb(x));
            Load(Source, (Config) => Config.GetString("VisMode"), (x) => MainWindowVirtual.visMode = x);
            Load(Source, (Config) => Config.GetBoolean("RichPresence"), (x) => MainWindowVirtual.isRichPresence = x);
            Load(Source, (Config) => Config.GetBoolean("Filtering"), (x) => MainWindowVirtual.isFilteringEnabled = x);

        }


        public static void OptionsSave()
        {
            if (!File.Exists("Options.ini"))
            {
                using (File.Create("Options.ini"));
            }

            IniConfigSource OptionsFile = new IniConfigSource("Options.ini");
            OptionsFile.GetKeyNE(SAVING).Set("SoundVolume", Convert.ToString(MainWindowVirtual.VolumeBar.Value));
            OptionsFile.GetKeyNE(SAVING).Set("ShowInfo", Convert.ToString(MainWindowVirtual.showInfo));
            OptionsFile.GetKeyNE(SAVING).Set("SaveStationOnExit", Convert.ToString(MainWindowVirtual.saveLastStation));
            OptionsFile.GetKeyNE(SAVING).Set("SaveShazamStateOnExit", Convert.ToString(MainWindowVirtual.saveShazamState));
            OptionsFile.GetKeyNE(SAVING).Set("SavedStationNumber", Convert.ToString(MainWindowVirtual.lastStationNumber));
            OptionsFile.GetKeyNE(SAVING).Set("ShazamState", Convert.ToString(MainWindowVirtual.isShazamEnabled));
            OptionsFile.GetKeyNE(SAVING).Set("MinimizeTray", Convert.ToString(MainWindowVirtual.isTray));
            OptionsFile.GetKeyNE(SAVING).Set("StartInTray", Convert.ToString(MainWindowVirtual.isTrayStart));
            OptionsFile.GetKeyNE(SAVING).Set("VisColor", Convert.ToString(MainWindowVirtual.visColor.ToArgb()));
            OptionsFile.GetKeyNE(SAVING).Set("VisMode", Convert.ToString(MainWindowVirtual.visMode));
            OptionsFile.GetKeyNE(SAVING).Set("RichPresence", Convert.ToString(MainWindowVirtual.isRichPresence));
            OptionsFile.GetKeyNE(SAVING).Set("Filtering", Convert.ToString(MainWindowVirtual.isFilteringEnabled));
            OptionsFile.Save();          
        }

        public static IConfig GetKeyNE(this IConfigSource source, String name)
        {
            return source.Configs[name] ?? source.AddConfig(name);
        }

        public static void Load<T>(IConfigSource Source, Loader<T> Loader, Setter<T> Setter)
        {
            IConfig Config = Source.Configs[SAVING];
            if (Config != null)
            {
                try
                {
                    Setter.Invoke(Loader.Invoke(Config));
                }
                catch (ArgumentException)
                {
                    
                }
            }
        }
    }
}
