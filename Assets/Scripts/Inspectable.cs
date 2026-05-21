using UnityEngine;

namespace ARIndustrialTraining
{
    public class Inspectable : MonoBehaviour
    {
        bool _inspected = false;

        // Called by TapToInspect when the user taps this object
        public void Inspect()
        {
            if (_inspected) return;
            _inspected = true;
            if (TrainingManager.Instance != null)
                TrainingManager.Instance.MarkEquipmentInspected();
        }
    }
}
