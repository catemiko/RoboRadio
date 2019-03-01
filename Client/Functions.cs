using System;
using System.Windows.Forms;

namespace RoboRadio
{
    using System.Threading;

    class Functions
    {

        public static void StationStringCheck(TextBox String_1, TextBox String_2, Button Button)
        {
            if (String_1.Text != "" && String_2.Text != "")
            {
              Button.Enabled = true;         
            }
        }

        public static void FilterStringCheck(TextBox String_1, TextBox String_2, bool IsTwoFields, Button Button)
        {
            if (IsTwoFields)
            {
                if (String_1.Text != "" && String_2.Text == "")
                    Button.Enabled = true;

                if (String_1.Text == "" && String_2.Text != "")
                    Button.Enabled = true;
            }
            else
            {
                if (String_1.Text != "" && String_2.Text != "")
                    Button.Enabled = true;           
            }
        }

        public static Filter FilterString(string ToFilter, string Prefix = null, string Suffix = null)
        {
            string container;
            Filter result = new Filter();
                container = ToFilter.Remove(0, Prefix.Length);
                result.title = container.Split(new string[] { Suffix }, 2, StringSplitOptions.RemoveEmptyEntries)[0];
                result.artist = container.Split(new string[] { Suffix }, 2, StringSplitOptions.RemoveEmptyEntries)[1];

                if (Convert.ToString(result.title[0]) == " ")
                    result.title = result.title.Remove(0, 1);

                if (Convert.ToString(result.artist[0]) == " ")
                    result.artist = result.artist.Remove(0, 1);

                return result;
        }

        public static string FilterTwoStrings(string toFilter, string Words = null)
        {
            string result;

            try
            {
                result = toFilter.Replace(Words, String.Empty);

                if (result[result.Length - 1] == ' ')
                    result = result.Remove(result.Length - 1);

                return result;
            }

            catch
            {
                return toFilter;
            }
            
        }

        public static void MessageBoxShow(object text)
        {
            try
            {
                MessageBox.Show(Convert.ToString(text));
            }

            catch (FormatException)
            {
                return;
            }
        }



        public static void CheckStartExceptions()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
        }

       private static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Something went wrong! " + e.Exception);
            Environment.Exit(0);
        }

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Something went wrong! " + e.ExceptionObject);
            Environment.Exit(0);
        }
    }
}
