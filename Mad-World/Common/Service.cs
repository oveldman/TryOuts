using System;
using System.IO;
using System.Net;
using Common.Interfaces;

namespace Common
{
    public class Service : IService
    {
        public string SendGetRequest(string url)
        {
            string bodyFromResponse = string.Empty;

            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            WebResponse response = request.GetResponse();

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                bodyFromResponse = reader.ReadToEnd();
            }

            // Close the response.
            response.Close();

            return bodyFromResponse;
        }
    }
}
