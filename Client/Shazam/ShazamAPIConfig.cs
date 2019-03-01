
using System.Globalization;

namespace Client.Shazam
{
    class ShazamAPIConfig
    {

        public int timeoutMilliseconds;

        public int timeoutMillisecondsForTagging;

        public string scheme;

        public string hostname;

        public int port;

        public string getconfig;

        public string configservice;

        public string language;

        public string model;

        public string appid;

        public string deviceUniqueId;

        public string installationId;

        public string imsi;

        public bool encrypt;

        public string keyinit;

        public char[] key = new char[8];

        public string token;

        public void initKey(string keyInit)
        {
            int length = keyInit.Length;
            char[] array = keyInit.ToCharArray();
            char[] array2 = new char[2];
            char[] array3 = array2;
            if (length == 16)
            {
                for (int i = 0; i < 8; i++)
                {
                    array3[0] = array[2 * i];
                    long num = long.Parse(new string(array3), NumberStyles.HexNumber) << 4;
                    this.key[i] |= (char)(ushort)num;
                    array3[0] = array[2 * i + 1];
                    num = long.Parse(new string(array3), NumberStyles.HexNumber);
                    this.key[i] |= (char)(ushort)num;
                }
            }
        }
    }
}
