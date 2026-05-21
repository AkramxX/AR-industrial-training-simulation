using UnityEngine;

namespace ARIndustrialTraining
{
    public class TapToInspect : MonoBehaviour
    {
        Camera _cam;

        void Start()
        {
            _cam = Camera.main;
        }

        void Update()
        {
            if (Input.touchCount == 0) return;
            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Ended) return;

            var ray = _cam.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out var hit))
            {
                var inspectable = hit.collider.GetComponent<Inspectable>();
                if (inspectable != null)
                {
                    inspectable.Inspect();
                }
            }
        }
    }
}
