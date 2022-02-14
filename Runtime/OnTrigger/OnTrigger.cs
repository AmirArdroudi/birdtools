using MyBox;
using UnityEngine;
using UnityEngine.Events;

namespace BirdTools
{
    [RequireComponent(typeof(Collider))]
    public class OnTrigger : MonoBehaviour
    {
        [Tag]
        public string colliderTag;
        [Space]
        public UnityEvent onEnter;
        public UnityEvent onStay;
        public UnityEvent onExit;

        private void OnValidate()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(colliderTag)) return;
            onEnter.Invoke();
        }
    
        private void OnTriggerStay(Collider other)
        {
            if(!other.gameObject.CompareTag(colliderTag)) return;
            onStay.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if(!other.gameObject.CompareTag(colliderTag)) return;
            onExit.Invoke();

        }
    }
}