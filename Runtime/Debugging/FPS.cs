using UnityEngine;

namespace BirdTools
{

    public class FPS : MonoBehaviour
    {
        private float deltaTime = 0.0f;
        public int fontSize = 2;
        public Color color = new Color(0.0f, 0.0f, 0.5f, 1.0f);

        [Header("Target framerate")]
        public bool hasTargetFramerate = false;
        public int framerate = 60;

        private void Awake()
        {
            if(hasTargetFramerate)
                Application.targetFrameRate = framerate;
        }

        void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        }

        void OnGUI()
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * fontSize / 100;
            style.normal.textColor = color;
            float mSec = deltaTime * 1000.0f;
            float fps = 1.0f / deltaTime;
            string text = string.Format("{0:0.0} ms ({1:0.} fps)", mSec, fps);
            GUI.Label(rect, text, style);
        }

    }
}