using System;
using System.IO;
using System.Net;

namespace Shazam
{
    public interface IRequestBuilder
    {
        void AddEncryptedFile(string name, string fileName, byte[] fileData, int fileSize);

        void AddEncryptedParameter(string name, string value);

        void AddFile(string name, string fileName, byte[] fileData, int fileSize);

        void AddParameter(string name, string value);

        string MakeRequestUri(string scheme, string hostName, string path);

        void PopulateWebRequestHeaders(WebRequest webRequest);

        void WriteToRequestStream(Stream requestStream);
    }
}


