using System;
using System.IO;
using System.Net;
using System.Text;

namespace Shazam
{
    public class OrbitPostRequestBuilder : IRequestBuilder
    {
        private MemoryStream requestDataStream = new MemoryStream();

        private string Boundary
        {
            get;
            set;
        }

        public IceKey Encryptor
        {
            get;
            private set;
        }

        public char[] Key
        {
            get;
            private set;
        }

        public OrbitPostRequestBuilder(IceKey encryptor, char[] key)
        {
            this.Encryptor = encryptor;
            this.Key = key;
            this.Boundary = "AJ8xP50454bf20Gp";
        }

        public void AddEncryptedFile(string name, string fileName, byte[] fileData, int fileSize)
        {
            this.Encryptor.set(this.Key);
            byte[] array = this.Encryptor.encBinary(fileData, fileSize);
            this.AddFile(name, fileName, array, array.Length);
        }

        public void AddEncryptedParameter(string name, string value)
        {
            this.Encryptor.set(this.Key);
            char[] value2 = this.Encryptor.encString(value);
            this.AddParameter(name, new string(value2));
        }

        public void AddFile(string name, string fileName, byte[] fileData, int fileSize)
        {
            string[] values = new string[]
            {
                "--{0}",
                Environment.NewLine,
                "Content-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"",
                Environment.NewLine,
                "Content-Type: {3}",
                Environment.NewLine,
                Environment.NewLine
            };
            string format = string.Concat(values);
            object[] args = new object[]
            {
                this.Boundary,
                name,
                fileName,
                "application/octet-stream"
            };
            string s = string.Format(format, args);
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            this.requestDataStream.Write(bytes, 0, bytes.Length);
            this.requestDataStream.Write(fileData, 0, fileSize);
            string newLine = Environment.NewLine;
            byte[] bytes2 = Encoding.UTF8.GetBytes(newLine);
            this.requestDataStream.Write(bytes2, 0, bytes2.Length);
        }

        public void AddParameter(string name, string value)
        {
            string[] values = new string[]
            {
                "--{0}",
                Environment.NewLine,
                "Content-Disposition: form-data; name=\"{1}\"",
                Environment.NewLine,
                Environment.NewLine,
                "{2}",
                Environment.NewLine
            };
            string format = string.Concat(values);
            object[] args = new object[]
            {
                this.Boundary,
                name,
                value
            };
            string s = string.Format(format, args);
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            this.requestDataStream.Write(bytes, 0, bytes.Length);
        }

        public string MakeRequestUri(string scheme, string hostName, string path)
        {
            return scheme + "://" + hostName + path;
        }

        public void PopulateWebRequestHeaders(WebRequest webRequest)
        {
            webRequest.Method = "POST";
            webRequest.ContentType = "multipart/form-data; boundary=" + this.Boundary;
        }

        public void WriteToRequestStream(Stream requestStream)
        {
            string s = "--" + this.Boundary + "--";
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            this.requestDataStream.Write(bytes, 0, bytes.Length);
            byte[] array = this.requestDataStream.ToArray();
            requestStream.Write(array, 0, array.Length);
        }
    }
}