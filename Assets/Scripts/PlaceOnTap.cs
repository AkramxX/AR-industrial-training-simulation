using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace ARIndustrialTraining
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnTap : MonoBehaviour
    {
        public GameObject EquipmentPrefab;

        ARRaycastManager _raycastManager;
        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
        }

        void Update()
        {
            if (Input.touchCount == 0) return;
            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Ended) return;

            if (_raycastManager.Raycast(touch.position, s_Hits, TrackableType.Planes))
            {
                var pose = s_Hits[0].pose;

                InstantiatePlacement(pose.position, pose.rotation);

                // mark surface detected when a successful training raycast occurs
                if (TrainingManager.Instance != null)
                    TrainingManager.Instance.MarkSurfaceDetected();
            }
        }

        void InstantiatePlacement(Vector3 position, Quaternion rotation)
        {
            if (EquipmentPrefab == null) return;
            var go = Instantiate(EquipmentPrefab, position, rotation);

            // ensure it has a collider and an Inspectable marker
            if (go.GetComponent<Collider>() == null)
            {
                var col = go.AddComponent<BoxCollider>();
                col.isTrigger = false;
            }

            if (go.GetComponent<Inspectable>() == null)
                go.AddComponent<Inspectable>();

            if (TrainingManager.Instance != null)
                TrainingManager.Instance.MarkEquipmentPlaced();
        }
    }
}
