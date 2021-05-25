using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace BirdTools
{
    public class GameEventListener : MonoBehaviour
    {
#if UNITY_EDITOR
        public string developerDescription = "RaiseBy: ";
#endif
        public bool once = false;
        public GameEvent GameEvent;
        public UnityEvent Response;
        [Range(0, 10)] public float delay = 0;
        private bool isRaised = false;
        private void OnEnable()
        {
            GameEvent.SubscribeListener(this);
        }
        
        private void OnDisable()
        {
            GameEvent.UnsubscribeListener(this);
        }

        public void OnEventRaised()
        {
            StartCoroutine(OnEventRaiseCoroutine());
            
        }

        private IEnumerator OnEventRaiseCoroutine()
        {
            if (once && isRaised) yield break;

            yield return new WaitForSeconds(delay);
            Response.Invoke();
            isRaised = true;
        }

    }
}