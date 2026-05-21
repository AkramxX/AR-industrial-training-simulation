using UnityEngine;
using UnityEngine.SceneManagement;

namespace ARIndustrialTraining
{
    public static class TrainingState
    {
        public static bool Started = false;
    }

    public class WelcomeManager : MonoBehaviour
    {
        private bool _showWelcome = true;

        void Awake()
        {
            _showWelcome = !TrainingState.Started;
        }

        void OnGUI()
        {
            if (!_showWelcome) return;

            var width = Screen.width * 0.6f;
            var height = Screen.height * 0.5f;
            var rect = new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height);

            GUI.Box(rect, "");

            var titleStyle = new GUIStyle(GUI.skin.label) {fontSize = 28, alignment = TextAnchor.UpperCenter};
            var buttonStyle = new GUIStyle(GUI.skin.button) {fontSize = 20};

            GUILayout.BeginArea(rect);
            GUILayout.Space(10);
            GUILayout.Label("AR Industrial Training Simulator", titleStyle);
            GUILayout.Space(20);
            GUILayout.Label("A lightweight augmented reality training demo for portfolio use.");
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Start Training", buttonStyle, GUILayout.Height(48)))
            {
                _showWelcome = false;
                TrainingState.Started = true;
                SceneManager.LoadScene("ARTraining");
            }
            GUILayout.Space(10);
            GUILayout.EndArea();
        }
    }
}
