using UnityEngine;

namespace ARIndustrialTraining
{
    public class InstructionPanel : MonoBehaviour
    {
        private Rect _panelRect;
        private GUIStyle _titleStyle;
        private GUIStyle _textStyle;

        void Start()
        {
            var width = Screen.width * 0.35f;
            var height = Screen.height * 0.28f;
            _panelRect = new Rect(10, 10, width, height);

            _titleStyle = new GUIStyle(GUI.skin.label) {fontSize = 18, fontStyle = FontStyle.Bold};
            _textStyle = new GUIStyle(GUI.skin.label) {fontSize = 14};
        }

        void OnGUI()
        {
            if (!TrainingState.Started) return;

            GUI.Box(_panelRect, "Training Steps");
            GUILayout.BeginArea(_panelRect);
            GUILayout.Space(8);
            GUILayout.Label("1. Detect a surface.", _textStyle);
            GUILayout.Label("2. Place the equipment.", _textStyle);
            GUILayout.Label("3. Inspect the equipment.", _textStyle);
            GUILayout.Label("Tip: Move your device slowly to find larger planes.", _textStyle);
            GUILayout.EndArea();
        }
    }
}
