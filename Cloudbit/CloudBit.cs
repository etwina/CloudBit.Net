using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace LittleBits
{
    public class CloudBit
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string accessToken;

        public string AccessToken
        {
            get { return accessToken; }
            set { accessToken = value; }
        }

        public CloudBit(string id,string accesstoken)
        {
            this.id = id;
            this.accessToken = accesstoken;
        }
        public bool SetOutput(int level,int duration = -1)
        {
            string url ="http://api-http.littlebitscloud.cc";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/v2/devices/" + this.Id + "/output");
            request.Method = "POST";
            string postData = "{  \"percent\": " + level + ",  \"duration_ms\": " + duration + "}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            
            request.Headers.Add("X-Target-URI", url);
            request.Host = "api-http.littlebitscloud.cc";
            request.Accept = "application/vnd.littlebits.v2+json";
            request.Headers.Add("Authorization", "Bearer " + AccessToken);
            Stream dataStream;
            try
            {
                dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

            }
            catch (Exception ex)
            {

                throw new Exception("Error while connecting to LittleBits Server [" + url + "]", ex);
            }
            WebResponse response;
            try
            {
                response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting response from LittleBits Server [" + url + "]", ex);
            }

            return true;
        }
    }

}
