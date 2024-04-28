using System;
using System.Collections;
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
            onCallback?.Invoke(webRequest);
        }

        public IEnumerator WebRequestTexture(string url, Action<UnityWebRequest> onCallback)
        {
            using UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
            yield return webRequest.SendWebRequest();
            onCallback?.Invoke(webRequest);
        }
    }
}