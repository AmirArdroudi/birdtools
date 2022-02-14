using MyBox;
using UnityEngine;
using UnityEngine.Events;

namespace BirdTools
{
    [RequireComponent(typeof(Collider2D))]
    public class OnTrigger2D : MonoBehaviour
    {
        [Tag]
        public string colliderTag;
        [Space]
        public UnityEvent onEnter;
        public UnityEvent onStay;
        public UnityEvent onExit;

        private void OnValidate()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(colliderTag)) return;
            onEnter.Invoke();
        }
    
        private void OnTriggerStay2D(Collider2D other)
        {
            if(!other.gameObject.CompareTag(colliderTag)) return;
            onStay.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(!other.gameObject.CompareTag(colliderTag)) return;
            onExit.Invoke();

        }
    }
}