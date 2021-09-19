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
        [Tooltip("Just raise event once")]
        public bool once = false;
        
        [Tooltip("Delay before raise the event")]
        [Range(0, 10)] public float delay = 0;
        
        [Tooltip("Raise this event on start")]
        public bool autoPlay = false;
        [Space]
        public GameEvent GameEvent;
        public UnityEvent Response;
        
        private bool isRaised = false;
        private void OnEnable()
        {
            GameEvent.SubscribeListener(this);
        }
        
        private void OnDisable()
        {
            GameEvent.UnsubscribeListener(this);
        }

        private void Start()
        {
            if(autoPlay) Response.Invoke();
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