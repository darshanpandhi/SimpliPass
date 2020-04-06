using System;
using System.Net.Http;

namespace SimpliPassMobile
{
    /// <summary>
    /// Interface for HttpConnection
    /// </summary>
    public interface ISimpliPassHttpConnection
    {
        bool Connect();

        void Disconnect();

        string GetResource(string path);

        bool PostResource(string path, StringContent content);
        
        bool PutResource(string path, StringContent content);
    }
}