using SharedCoreLib.Models.VO;
using SharedCoreLib.Services.ShazamAPI;
using SharedCoreLib.Services.ShazamAPI.Responses;
using SharedCoreLib.Utils.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml.Linq;

namespace Shazam
{
    public class ShazamClient
    {
        public static string kDoRecognitionURL = "http://msft.shazamid.com/orbit/DoRecognition1";

        public static string kRequestResultsURL = "http://msft.shazamid.com/orbit/RequestResults1";

        private IceKey encryptKey = new IceKey(1);

        private ShazamRequest shazamRequest;

        public event ShazamStateChangedCallback OnRecongnitionStateChanged;

        public string deviceID
        {
            private get;
            set;
        }

        public int DoRecognition(byte[] audioBuffer, MicrophoneRecordingOutputFormatType formatType)
        {
            this.shazamRequest = default(ShazamRequest);
            ShazamAPIConfig shazamAPIConfig = new ShazamAPIConfig();
            shazamAPIConfig.initKey("20FB1BCBE2C4848F");
            this.shazamRequest.token = "B540AD35";
            this.shazamRequest.key = shazamAPIConfig.key;
            this.shazamRequest.audioBuffer = audioBuffer;
            this.shazamRequest.deviceid = "00000000-0000-0000-0000-000000000000";
            this.shazamRequest.service = "cn=US,cn=V12,cn=SmartClub,cn=ShazamiD,cn=services";
            this.shazamRequest.language = "en-US";
            this.shazamRequest.model = "Microsoft Windows";
            this.shazamRequest.appid = "ShazamId_SmartPhone_Tau__1.3.0";
            if (this.deviceID != null && this.deviceID != "")
            {
                this.shazamRequest.deviceid = this.deviceID;
            }
            switch (formatType)
            {
                case MicrophoneRecordingOutputFormatType.PCM:
                    this.shazamRequest.filename = "sample.wav";
                    break;
                case MicrophoneRecordingOutputFormatType.MP3:
                    this.shazamRequest.filename = "sample.mp3";
                    break;
                case MicrophoneRecordingOutputFormatType.SIG:
                    this.shazamRequest.filename = "sample.sig";
                    break;
            }
            ShazamRequest shazamRequest = this.shazamRequest;
            try
            {
                this.RaiseOnRecongnitionStateChanged(ShazamRecognitionState.Sending, null);
                byte[] audioBuffer2 = shazamRequest.audioBuffer;
                string value = audioBuffer2.Length.ToString();
                string value2 = DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
                OrbitPostRequestBuilder orbitPostRequestBuilder = new OrbitPostRequestBuilder(this.encryptKey, shazamRequest.key);
                orbitPostRequestBuilder.AddEncryptedParameter("cryptToken", shazamRequest.token);
                orbitPostRequestBuilder.AddEncryptedParameter("deviceId", shazamRequest.deviceid);
                orbitPostRequestBuilder.AddParameter("service", shazamRequest.service);
                orbitPostRequestBuilder.AddParameter("language", shazamRequest.language);
                orbitPostRequestBuilder.AddEncryptedParameter("deviceModel", shazamRequest.model);
                orbitPostRequestBuilder.AddEncryptedParameter("applicationIdentifier", shazamRequest.appid);
                orbitPostRequestBuilder.AddEncryptedParameter("tagDate", value2);
                orbitPostRequestBuilder.AddEncryptedParameter("sampleBytes", value);
                orbitPostRequestBuilder.AddEncryptedFile("sample", shazamRequest.filename, audioBuffer2, audioBuffer2.Length);
                WebRequest webRequest = WebRequest.Create(ShazamClient.kDoRecognitionURL);
                orbitPostRequestBuilder.PopulateWebRequestHeaders(webRequest);
                this.doTimeoutRequest(new RequestContext
                {
                    WebRequest = webRequest,
                    RequestBuilder = orbitPostRequestBuilder
                }, new AsyncCallback(this.RecognitionReadCallback), 30000);
            }
            catch (Exception e)
            {
                this.RecognitionFailed(e);
            }
            return 0;
        }

        private void DoGetResult(ulong requestId)
        {
            try
            {
                this.RaiseOnRecongnitionStateChanged(ShazamRecognitionState.Matching, null);
                this.shazamRequest.requestId = requestId;
                this.shazamRequest.art_width = 520;
                ShazamRequest shazamRequest = this.shazamRequest;
                string value = shazamRequest.requestId.ToString();
                OrbitPostRequestBuilder orbitPostRequestBuilder = new OrbitPostRequestBuilder(this.encryptKey, shazamRequest.key);
                orbitPostRequestBuilder.AddEncryptedParameter("cryptToken", shazamRequest.token);
                orbitPostRequestBuilder.AddEncryptedParameter("deviceId", shazamRequest.deviceid);
                orbitPostRequestBuilder.AddParameter("service", shazamRequest.service);
                orbitPostRequestBuilder.AddParameter("language", shazamRequest.language);
                orbitPostRequestBuilder.AddEncryptedParameter("deviceModel", shazamRequest.model);
                orbitPostRequestBuilder.AddEncryptedParameter("applicationIdentifier", shazamRequest.appid);
                orbitPostRequestBuilder.AddEncryptedParameter("coverartSize", shazamRequest.art_width.ToString());
                orbitPostRequestBuilder.AddEncryptedParameter("requestId", value);
                WebRequest webRequest = WebRequest.Create(ShazamClient.kRequestResultsURL);
                orbitPostRequestBuilder.PopulateWebRequestHeaders(webRequest);
                this.doTimeoutRequest(new RequestContext
                {
                    WebRequest = webRequest,
                    RequestBuilder = orbitPostRequestBuilder
                }, new AsyncCallback(this.ResultReadCallback), 30000);
            }
            catch (Exception e)
            {
                this.RecognitionFailed(e);
            }
        }

        private void RecognitionReadCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                RequestContext requestContext = (RequestContext)asynchronousResult.AsyncState;
                HttpWebRequest httpWebRequest = (HttpWebRequest)requestContext.WebRequest;
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.EndGetResponse(asynchronousResult);
                IRequestBuilder arg_2F_0 = requestContext.RequestBuilder;
                string responseString = "";
                if (httpWebResponse.GetResponseStream() != null)
                {
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        responseString = streamReader.ReadToEnd();
                    }
                }
                RecognitionShazamResponse recognitionShazamResponse = this.ParseResponseForDoRecognition(responseString);
                if (recognitionShazamResponse.errorMessage != "" && recognitionShazamResponse.errorMessage != null)
                {
                    throw new Exception(recognitionShazamResponse.errorMessage);
                }
                this.DoGetResult(recognitionShazamResponse.requestId);
            }
            catch (Exception e)
            {
                this.RecognitionFailed(e);
            }
        }

        private void ResultReadCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)((RequestContext)asynchronousResult.AsyncState).WebRequest;
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.EndGetResponse(asynchronousResult);
                string responseString = "";
                if (httpWebResponse.GetResponseStream() != null)
                {
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        responseString = streamReader.ReadToEnd();
                    }
                }
                ResultShazamResponse resultShazamResponse = this.ParseResponseForRequestResults(responseString);
                if (resultShazamResponse.errorMessage != "" && resultShazamResponse.errorMessage != null)
                {
                    throw new Exception(resultShazamResponse.errorMessage);
                }
                this.RaiseOnRecongnitionStateChanged(ShazamRecognitionState.Done, new ShazamResponse(resultShazamResponse));
            }
            catch (Exception e)
            {
                this.RecognitionFailed(e);
            }
        }

        private void RaiseOnRecongnitionStateChanged(ShazamRecognitionState State, ShazamResponse Response)
        {
            if (this.OnRecongnitionStateChanged != null)
            {
                this.RaiseEventOnUIThread(this.OnRecongnitionStateChanged, new object[]
                {
                    State,
                    Response
                });
            }
        }

        private void RecognitionFailed(Exception e)
        {
            if (this.OnRecongnitionStateChanged != null)
            {
                this.RaiseEventOnUIThread(this.OnRecongnitionStateChanged, new object[]
                {
                    ShazamRecognitionState.Failed,
                    new ShazamResponse(e)
                });
            }
        }

        private void RaiseEventOnUIThread(Delegate theEvent, object[] args)
        {
            try
            {
                Delegate[] invocationList = theEvent.GetInvocationList();
                for (int i = 0; i < invocationList.Length; i++)
                {
                    Delegate @delegate = invocationList[i];
                    ISynchronizeInvoke synchronizeInvoke = @delegate.Target as ISynchronizeInvoke;
                    if (synchronizeInvoke == null)
                    {
                        @delegate.DynamicInvoke(args);
                    }
                    else
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
                        synchronizeInvoke.BeginInvoke(@delegate, args);
                    }
                }
            }
            catch
            {
                this.OnRecongnitionStateChanged((ShazamRecognitionState)args[0], (ShazamResponse)args[1]);
            }
        }

        private ResultShazamResponse ParseResponseForRequestResults(string responseString)
        {
            ResultShazamResponse resultShazamResponse = new ResultShazamResponse();
            XDocument xDocument = XDocument.Parse(responseString);
            XNamespace xNamespace = "http://orbit.shazam.com/v1/response";
            XElement elementIgnoreNamespace = xDocument.Root.GetElementIgnoreNamespace(xNamespace, "requestResults1");
            XElement root = elementIgnoreNamespace;
            if (elementIgnoreNamespace == null)
            {
                XElement elementIgnoreNamespace2 = xDocument.Root.GetElementIgnoreNamespace(xNamespace, "error");
                XElement xElement = elementIgnoreNamespace2;
                if (elementIgnoreNamespace2 != null)
                {
                    resultShazamResponse.errorCode = int.Parse(xElement.Attribute("code").Value);
                    resultShazamResponse.errorMessage = Convert.ToString(xElement.Attribute("message").Value);
                    //Console.WriteLine(Convert.ToString(xElement.Attribute("message").Value));
                }
            }
            else
            {
                XElement elementIgnoreNamespace3 = root.GetElementIgnoreNamespace(xNamespace, "request");
                resultShazamResponse.newTag = new TagVO
                {
                    Id = elementIgnoreNamespace3.Attribute("requestId").Value
                };
                TrackVO trackVO = null;
                XElement elementIgnoreNamespace4 = root.GetElementIgnoreNamespace(xNamespace, "tracks");
                XElement elementIgnoreNamespace5 = elementIgnoreNamespace4.GetElementIgnoreNamespace(xNamespace, "track");
                if (elementIgnoreNamespace5 != null)
                {
                    trackVO = this.ParseXmlElementForTrackData(xNamespace, elementIgnoreNamespace5, false);
                    if (elementIgnoreNamespace5.Attribute("cache-max-age") != null)
                    {
                        Convert.ToInt32(elementIgnoreNamespace5.Attribute("cache-max-age").Value);
                    }
                }
                if (trackVO != null)
                {
                    resultShazamResponse.newTag.Track = trackVO;
                }
            }
            return resultShazamResponse;
        }

        private RecognitionShazamResponse ParseResponseForDoRecognition(string responseString)
        {
            RecognitionShazamResponse recognitionShazamResponse = new RecognitionShazamResponse();
            XDocument xDocument = XDocument.Parse(responseString);
            XNamespace namespaceName = "http://orbit.shazam.com/v1/response";
            XElement elementIgnoreNamespace = xDocument.Root.GetElementIgnoreNamespace(namespaceName, "doRecognition1");
            XElement root = elementIgnoreNamespace;
            if (elementIgnoreNamespace == null)
            {
                XElement elementIgnoreNamespace2 = xDocument.Root.GetElementIgnoreNamespace(namespaceName, "error");
                XElement xElement = elementIgnoreNamespace2;
                if (elementIgnoreNamespace2 != null)
                {
                    recognitionShazamResponse.errorCode = int.Parse(xElement.Attribute("code").Value);
                }
            }
            else
            {
                XElement elementIgnoreNamespace3 = root.GetElementIgnoreNamespace(namespaceName, "requestId");
                XElement xElement2 = elementIgnoreNamespace3;
                if (elementIgnoreNamespace3 != null)
                {
                    recognitionShazamResponse.requestId = ulong.Parse(xElement2.Attribute("id").Value);
                }
            }
            return recognitionShazamResponse;
        }

        private bool doTimeoutRequest(RequestContext requestContext, AsyncCallback callback, int millisecondsTimeout)
        {
            try
            {
                bool flag = false;
                Timer timer = null;
                TimerCallback callback2 = delegate (object state)
                {

                    lock (timer)
                    {

                        if (!flag)
                        {
                            flag = true;
                            requestContext.WebRequest.Abort();
                        }
                    }
                };
                AsyncCallback asyncCallback = delegate (IAsyncResult ar)
                {

                    lock (timer)
                    {

                        if (!flag)
                        {
                            flag = true;
                            timer.Change(-1, -1);
                        }
                    }
                    callback(ar);
                };
                if (!requestContext.WebRequest.Method.Equals("POST"))
                {
                    requestContext.WebRequest.BeginGetResponse(asyncCallback, requestContext);
                }
                else
                {
                    AsyncCallback callback3 = delegate (IAsyncResult ar)
                    {
                        requestContext = (RequestContext)ar.AsyncState;
                        using (Stream stream = requestContext.WebRequest.EndGetRequestStream(ar))
                        {
                            requestContext.RequestBuilder.WriteToRequestStream(stream);
                        }
                        requestContext.WebRequest.BeginGetResponse(asyncCallback, requestContext);
                    };
                    requestContext.WebRequest.BeginGetRequestStream(callback3, requestContext);
                }
                timer = new Timer(callback2, null, millisecondsTimeout, -1);
            }
            catch (Exception innerException)
            {
                throw new IOException(string.Empty, innerException);
            }
            return true;
        }

        private TrackVO ParseXmlElementForTrackData(XNamespace xNamespace, XElement trackElem, bool fromList = false)
        {
            TrackVO trackVO = new TrackVO();
            trackVO.Id = Convert.ToInt32(trackElem.Attribute("id").Value);
            trackVO.Title = trackElem.GetElementIgnoreNamespace(xNamespace, "ttitle").Value;
            XElement elementIgnoreNamespace = trackElem.GetElementIgnoreNamespace(xNamespace, "tartists");
            if (elementIgnoreNamespace != null)
            {
                XElement elementIgnoreNamespace2 = elementIgnoreNamespace.GetElementIgnoreNamespace(xNamespace, "tartist");
                if (elementIgnoreNamespace2 != null)
                {
                    trackVO.Artist = elementIgnoreNamespace2.Value;
                }
            }
            XElement elementIgnoreNamespace3 = trackElem.GetElementIgnoreNamespace(xNamespace, "tlabel");
            if (elementIgnoreNamespace3 != null)
            {
                trackVO.Label = elementIgnoreNamespace3.Value;
            }
            XElement elementIgnoreNamespace4 = trackElem.GetElementIgnoreNamespace(xNamespace, "tgenre");
            if (elementIgnoreNamespace4 != null)
            {
                XElement elementIgnoreNamespace5 = elementIgnoreNamespace4.GetElementIgnoreNamespace(xNamespace, "tparentGenre");
                if (elementIgnoreNamespace5 != null)
                {
                    trackVO.Genre = elementIgnoreNamespace5.Value;
                }
            }
            XElement elementIgnoreNamespace6 = trackElem.GetElementIgnoreNamespace(xNamespace, "tcoverart");
            if (elementIgnoreNamespace6 != null)
            {
                trackVO.ImageUri = elementIgnoreNamespace6.Value;
            }
            XElement elementIgnoreNamespace7 = trackElem.GetElementIgnoreNamespace(xNamespace, "addOns");
            if (elementIgnoreNamespace7 != null)
            {
                foreach (XElement current in elementIgnoreNamespace7.Elements(xNamespace + "addOn"))
                {
                    if (current.Attribute("providerName").Value == "Zune")
                    {
                        XElement elementIgnoreNamespace8 = current.GetElementIgnoreNamespace(xNamespace, "actions");
                        if (elementIgnoreNamespace8 != null)
                        {
                            XElement elementIgnoreNamespace9 = elementIgnoreNamespace8.GetElementIgnoreNamespace(xNamespace, "MarketplaceSearchTask");
                            if (elementIgnoreNamespace9 != null)
                            {
                                trackVO.ContentType = elementIgnoreNamespace9.Attribute("ContentType").Value;
                                trackVO.SearchTerms = elementIgnoreNamespace9.Attribute("SearchTerms").Value;
                            }
                        }
                        XElement elementIgnoreNamespace10 = current.GetElementIgnoreNamespace(xNamespace, "content");
                        if (elementIgnoreNamespace10 != null)
                        {
                            trackVO.PurchaseUrl = elementIgnoreNamespace10.Value;
                        }
                    }
                    else if (current.Attribute("providerName").Value != "Share")
                    {
                        XElement elementIgnoreNamespace11 = current.GetElementIgnoreNamespace(xNamespace, "actions");
                        if (elementIgnoreNamespace11 != null)
                        {
                            AddOnVO addOnVO = new AddOnVO();
                            addOnVO.ProviderName = current.Attribute("providerName").Value;
                            addOnVO.Caption = current.Attribute("typeName").Value;
                            int typeId = -1;
                            if (int.TryParse(current.Attribute("typeId").Value, out typeId))
                            {
                                addOnVO.TypeId = typeId;
                            }
                            int creditTypeId = -1;
                            if (current.Attribute("creditTypeId") != null && int.TryParse(current.Attribute("creditTypeId").Value, out creditTypeId))
                            {
                                addOnVO.CreditTypeId = creditTypeId;
                            }
                            addOnVO.Actions = new List<AddOnActionVO>();
                            foreach (XElement current2 in elementIgnoreNamespace11.Elements())
                            {
                                AddOnActionVO addOnActionVO = new AddOnActionVO();
                                addOnActionVO.Url = current2.Attribute("Uri").Value;
                                string localName = current2.Name.LocalName;
                                string a = localName;
                                if (localName != null)
                                {
                                    if (a == "LaunchUriTask")
                                    {
                                        addOnActionVO.Type = AddOnActionVO.ActionType.LaunchUri;
                                    }
                                    else if (a == "WebViewTask")
                                    {
                                        addOnActionVO.Type = AddOnActionVO.ActionType.WebView;
                                    }
                                }
                                addOnVO.Actions.Add(addOnActionVO);
                            }
                            string providerName = addOnVO.ProviderName;
                            string text = providerName;
                            string key;

                            if (providerName != null && (key = text) != null)
                            {
                                //Тест



                                Dictionary<string, int> Buttons = new Dictionary<string, int>(7)
                                    {
                                        {
                                            "Buy",
                                            0
                                        },
                                        {
                                            "YouTube",
                                            1
                                        },
                                        {
                                            "Biography",
                                            2
                                        },
                                        {
                                            "Discography",
                                            3
                                        },
                                        {
                                            "ProductReview",
                                            4
                                        },
                                        {
                                            "TrackReview",
                                            5
                                        },
                                        {
                                            "ShazamLyrics",
                                            6
                                        },
                                        {
                                            "Recommendations",
                                            7
                                        }
                                    };

                                int num;
                                //Тест 
                                if (Buttons.TryGetValue(key, out num))
                                {
                                    switch (num)
                                    {
                                        case 0:
                                            addOnVO.ImageUri = "ms-appx:///PresentationLib/Assets/buy.png";
                                            break;
                                        case 1:
                                            addOnVO.ImageUri = "ms-appx:///PresentationLib/Assets/youtube.png";
                                            break;
                                        case 2:
                                            addOnVO.ImageUri = "ms-appx:///PresentationLib/Assets/biog.png";
                                            break;
                                        case 3:
                                            addOnVO.ImageUri = "ms-appx:///PresentationLib/Assets/discog.png";
                                            break;
                                        case 4:
                                            addOnVO.ImageUri = "ms-appx:///PresentationLib/Assets/reviews.png";
                                            break;
                                        case 5:
                                            addOnVO.ImageUri = "ms-appx:///PresentationLib/Assets/trackreview.png";
                                            break;
                                        case 6:
                                            addOnVO.ImageUri = "ms-appx:///PresentationLib/Assets/lyrics.png";
                                            break;
                                        case 7:
                                            addOnVO.ImageUri = "ms-appx:///PresentationLib/Assets/recommendations.png";
                                            break;
                                    }
                                }
                            }
                            addOnVO.AssociateOwnerTrack(trackVO);
                            trackVO.AddOns = new List<AddOnVO>();
                            trackVO.AddOns.Add(addOnVO);
                        }
                    }
                    else
                    {
                        XElement elementIgnoreNamespace12 = current.GetElementIgnoreNamespace(xNamespace, "actions");
                        if (elementIgnoreNamespace12 != null)
                        {
                            XElement elementIgnoreNamespace13 = elementIgnoreNamespace12.GetElementIgnoreNamespace(xNamespace, "ShareLinkTask");
                            if (elementIgnoreNamespace13 != null)
                            {
                                trackVO.ShareLinkUri = elementIgnoreNamespace13.Attribute("LinkUri").Value;
                                trackVO.ShareLinkTitle = elementIgnoreNamespace13.Attribute("Title").Value;
                                trackVO.ShareLinkMessage = elementIgnoreNamespace13.Attribute("Message").Value;
                            }
                        }
                    }
                }
            }
            XElement elementIgnoreNamespace14 = trackElem.GetElementIgnoreNamespace(xNamespace, "tproduct");
            if (elementIgnoreNamespace14 != null)
            {
                trackVO.Product = elementIgnoreNamespace14.Value;
            }
            return trackVO;
        }
    }
}