using SharedCoreLib.Models.VO;
using SharedCoreLib.Services.ShazamAPI.Responses;
using System;

namespace Shazam
{
    public class ShazamResponse
    {
        public TagVO Tag
        {
            get;
            private set;
        }

        public Exception Exception
        {
            get;
            private set;
        }

        public ShazamResponse(ResultShazamResponse result)
        {
            if (result.newTag != null)
            {
                this.Tag = result.newTag;
            }
        }

        public ShazamResponse(Exception exception)
        {
            this.Exception = exception;
        }
    }
}
