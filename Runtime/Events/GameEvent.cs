using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BirdTools
{
    [CreateAssetMenu(fileName = "ev_title", menuName = "BirdTools/Events/voidEvent")]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// By Raising this event, the list of listeners will notify 
        /// </summary>
        private readonly List<GameEventListener> _listeners = new List<GameEventListener>();

        public void Raise()
        {
            // We iterate through this list from its top without out of range exception
            // in the case that response of the listener was a call to remove it from the list.
            for (int i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventRaised();
        }

        public void UnsubscribeListener(GameEventListener listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
        public void SubscribeListener(GameEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }
    }

#if UNITY_EDITOR
    
    [CustomEditor(typeof(GameEvent), editorForChildClasses: true)]
    public class GameEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            
            base.OnInspectorGUI();

            GUI.enabled = true;
            
            GameEvent e = target as GameEvent;
            
            if(GUILayout.Button("Raise Event"))
                e.Raise();
        }
    }
    
#endif
}
