using System;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimpliPassMobile.TestDoubles
{
    public class StubHttpConnection : ISimpliPassHttpConnection
    {
        public static bool IsConnected = false;
        public JArray StubObject = new JArray();
        private string DummyResponse = "";


        public void SetTestObject(JArray argStubObject)
        {
            StubObject = argStubObject;
        }

        public void SetDummyResponse(string argDummy)
        {
            DummyResponse = argDummy;
        }

        public bool Connect()
        {
            IsConnected = true;
            return true;
        }

        public void Disconnect()
        {
            IsConnected = false;
        }
        
        public string GetResource(string path)
        {
            return DummyResponse;
        }

        public bool PostResource(string path, StringContent content)
        {
            DummyResponse = "Test.POST"+path;
            return false;
        }

        public bool PutResource(string path, StringContent content)
        {
            DummyResponse = "Test.PUT"+path;
            return false;
        }
    }
}