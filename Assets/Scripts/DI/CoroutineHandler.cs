using System.Collections;
using UnityEngine;

namespace CoroutineSystem
{
    public class CoroutineHandler : MonoBehaviour
    {
        public void StartActiveCoroutine(IEnumerator c) => StartCoroutine(c);
        
        public void StopActiveCoroutine(Coroutine c) => StopCoroutine(c);
    }
}