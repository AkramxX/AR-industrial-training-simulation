using UnityEngine;
using System.Text;

namespace ARIndustrialTraining
{
    public class ChecklistUI : MonoBehaviour
    {
        Rect _panelRect;

        GUIStyle _titleStyle;
        GUIStyle _textStyle;
        GUIStyle _checkStyle;

        TrainingManager _manager;

        void Start()
        {
            var width = Screen.width * 0.34f;
            var height = Screen.height * 0.36f;
            _panelRect = new Rect(Screen.width - width - 10, 10, width, height);

            _titleStyle = new GUIStyle(GUI.skin.label) { fontSize = 16, fontStyle = FontStyle.Bold };
            _textStyle = new GUIStyle(GUI.skin.label) { fontSize = 14 };
            _checkStyle = new GUIStyle(GUI.skin.label) { fontSize = 18 };

            _manager = TrainingManager.Instance;
            if (_manager == null)
            {
                var go = new GameObject("TrainingManager");
                _manager = go.AddComponent<TrainingManager>();
            }
            _manager.OnStateChanged += OnStateChanged;
        }

        void OnDestroy()
        {
            if (_manager != null) _manager.OnStateChanged -= OnStateChanged;
        }

        void OnStateChanged() { /* trigger repaint via OnGUI next frame */ }

        void OnGUI()
        {
            GUI.Box(_panelRect, "");
            GUILayout.BeginArea(_panelRect);
            GUILayout.Space(6);
            GUILayout.Label("Training Checklist", _titleStyle);
            GUILayout.Space(6);

            DrawItem(_manager != null && _manager.SurfaceDetected, "Detect surface");
            DrawItem(_manager != null && _manager.EquipmentPlaced, "Place equipment");
            DrawItem(_manager != null && _manager.EquipmentInspected, "Inspect equipment");

            GUILayout.FlexibleSpace();

            var progress = _manager != null ? _manager.ProgressCount() : 0;
            GUILayout.Label($"Progress: {progress}/{_manager?.TotalSteps ?? 3}", _textStyle);

            if (_manager != null && _manager.IsCompleted())
            {
                GUILayout.Space(6);
                var successStyle = new GUIStyle(GUI.skin.label) { fontSize = 16, normal = { textColor = Color.green }, alignment = TextAnchor.MiddleCenter };
                GUILayout.Label("Training Session Completed Successfully", successStyle, GUILayout.Height(36));
            }

            GUILayout.EndArea();
        }

        void DrawItem(bool done, string text)
        {
            GUILayout.BeginHorizontal();
            if (done)
            {
                var prevColor = GUI.color;
                GUI.color = Color.green;
                GUILayout.Label("✓", _checkStyle, GUILayout.Width(24));
                GUI.color = prevColor;
            }
            else
            {
                GUILayout.Label("○", _checkStyle, GUILayout.Width(24));
            }
            GUILayout.Label(text, _textStyle);
            GUILayout.EndHorizontal();
            GUILayout.Space(4);
        }
    }
}
