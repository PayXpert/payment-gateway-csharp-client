﻿using Newtonsoft.Json;
using PayXpertLibrary.Requests;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayXpertLibrary
{
    public abstract class TransactionBase
    {
        private URLRecord url;

        protected String getParams = null;

        protected String originatorId;
        protected String password;
        protected String baseURL;

        protected BaseRequestObject requestObject = null;

        protected TransactionBase(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String transactionId)
        {
            this.url = new URLRecord(Type, transactionId);

            this.originatorId = OriginatorId;
            this.password = Password;
            this.baseURL = BaseURL;
        }

        protected async Task<T> SendRequestToServer<T>()
        {
            var fullURL = Utils.Combine(baseURL, this.url.Url);

            if (getParams != null)
            {
                fullURL = fullURL + "?" + getParams;
            }

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(fullURL);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = this.url.Method;

            // Authorization

            String encodedAuthHeader = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(originatorId + ":" + password));
            httpWebRequest.Headers.Add("Authorization", "Basic " + encodedAuthHeader);

            if (requestObject != null)
            {
                String json = JsonConvert.SerializeObject(requestObject, Newtonsoft.Json.Formatting.None,
                           new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStreamAsync().Result))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
            }

            // var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            var asyncResponse = await httpWebRequest.GetResponseAsync();
            var httpResponse = (HttpWebResponse)asyncResponse;

            using (Stream stream = httpResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                String responseString = reader.ReadToEnd();

                if (Utils.DEBUG)
                {
                    // For debugging reasons
                    Console.WriteLine(responseString);
                }

                T responseObject = JsonConvert.DeserializeObject<T>(responseString);
                return responseObject;
            }
        }

        protected void SetInUrl(String name, String value)
        {
            this.url.SetInURL(name, value);
        }
    }
}
