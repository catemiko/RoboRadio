using System;
using System.Net;

namespace Shazam
{
    public struct RequestContext
    {
        public IRequestBuilder RequestBuilder
        {
            get;
            set;
        }

        public object State
        {
            get;
            set;
        }

        public WebRequest WebRequest
        {
            get;
            set;
        }
    }
}
