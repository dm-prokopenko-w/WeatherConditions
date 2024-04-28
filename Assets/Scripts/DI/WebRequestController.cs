using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using static UnityEngine.Networking.UnityWebRequest;

namespace NetworkSystem
{
    public class WebRequestController
    {
        public IEnumerator WebRequestGet(string uri, Action<UnityWebRequest> onCallback)
        {
            UnityWebRequest webRequest = Get(uri);
            yield return webRequest.SendWebRequest();
/*
            if (webRequest.result == Result.ConnectionError ||
                webRequest.result == Result.DataProcessingError ||
                webRequest.result == Result.ProtocolError)
            {
                handler = webRequest.downloadHandler;
            }
            else
            {
                handler =  webRequest.downloadHandler;
            }
            */
            onCallback?.Invoke(webRequest);
        }

        public IEnumerator WebRequestTexture(string url, Action<UnityWebRequest> onCallback)
        {
            using UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
            yield return webRequest.SendWebRequest();
            onCallback?.Invoke(webRequest);
        }

        public IEnumerator WebRequestPost(string url, string data, string contentType, Action<bool> onPost)
        {
            UnityWebRequest www = Post(url, data, contentType);
            yield return www.SendWebRequest();
            onPost?.Invoke(www.result == Result.Success);
        }

        public IEnumerator WebRequestPut(string url, string json, Action<bool> onPut)
        {
            UnityWebRequest www = Put(url, json);
            yield return www.SendWebRequest();
            onPut?.Invoke(www.result == Result.Success);
        }
    }
}