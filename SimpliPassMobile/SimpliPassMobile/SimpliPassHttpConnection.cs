using System;
using System.Net.Http;

namespace SimpliPassMobile
{
    /// <summary>
    /// Singleton for HttpConnection
    /// </summary>
    public static class SimpliPassHttpConnection
    {
        private static HttpClient s_http_client;
        private static bool IsConnected = false;
        
        /// <summary>
        /// Attempts an http connection
        /// </summary>
        /// <returns> true if connection was successful, false otherwise </returns>
        public static bool Connect()
        {
            System.Diagnostics.Debug.WriteLine("Attempting http connection...");
            try
            {
                s_http_client = new HttpClient
                {
                    Timeout = TimeSpan.FromMilliseconds(10000)
                };
                var response = s_http_client.GetAsync(Constants.API_BASE_URL).Result; // dummy request to ensure a respose
                response.EnsureSuccessStatusCode();
                System.Diagnostics.Debug.WriteLine("Connection success");
                IsConnected = true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Connection failure");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                IsConnected = false;
            }
            return IsConnected;
        }

        public static void Disconnect()
        {
            s_http_client.Dispose();
            IsConnected = false;
        }
        /// <summary>
        /// Attemps to GET a resource from server
        /// </summary>
        /// <param name="path"> REST Path of required resource </param>
        /// <returns> response from the server </returns>
        public static string GetResource(string path)
        {
            var response = "";
            if (!IsConnected)
            {
                return response;
            }
            try
            {
                response = s_http_client.GetStringAsync(Constants.API_BASE_URL + path).Result;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error getting the resource");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
            return response;
        }

        /// <summary>
        /// Attempts to POST content
        /// </summary>
        /// <param name="path"> REST path for POST</param>
        /// <param name="content"> content to POST </param>
        /// <returns> true if POST was successful, false otherwise </returns>
        public static bool PostResource(string path, StringContent content)
        {
            bool success = false;
            if (!IsConnected)
            {
                return false;
            }
            try
            {
                s_http_client.PostAsync(Constants.API_BASE_URL + path, content);
                success = true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error updating the resource");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
            return success;
        }

        /// <summary>
        /// Attempts to PUT content
        /// </summary>
        /// <param name="path"> REST path for PUT</param>
        /// <param name="content"> content to PUT </param>
        /// <returns> true if PUT was successful, false otherwise </returns>
        public static bool PutResource(string path, StringContent content)
        {
            bool success = false;
            if (!IsConnected)
            {
                return false;
            }
            try
            {
                s_http_client.PutAsync(Constants.API_BASE_URL + path, content);
                success = true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error updating the resource");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
            return success;
        }
    }
}