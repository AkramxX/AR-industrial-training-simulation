using System;
using UnityEngine;

namespace ARIndustrialTraining
{
    public class TrainingManager : MonoBehaviour
    {
        public static TrainingManager Instance { get; private set; }

        public bool SurfaceDetected { get; private set; }
        public bool EquipmentPlaced { get; private set; }
        public bool EquipmentInspected { get; private set; }

        public event Action OnStateChanged;

        void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void MarkSurfaceDetected()
        {
            if (SurfaceDetected) return;
            SurfaceDetected = true;
            OnStateChanged?.Invoke();
        }

        public void MarkEquipmentPlaced()
        {
            if (EquipmentPlaced) return;
            EquipmentPlaced = true;
            OnStateChanged?.Invoke();
            CheckAllCompleted();
        }

        public void MarkEquipmentInspected()
        {
            if (EquipmentInspected) return;
            EquipmentInspected = true;
            OnStateChanged?.Invoke();
            CheckAllCompleted();
        }

        void CheckAllCompleted()
        {
            if (SurfaceDetected && EquipmentPlaced && EquipmentInspected)
            {
                OnStateChanged?.Invoke();
            }
        }

        public int ProgressCount()
        {
            var c = 0;
            if (SurfaceDetected) c++;
            if (EquipmentPlaced) c++;
            if (EquipmentInspected) c++;
            return c;
        }

        public int TotalSteps => 3;
        public bool IsCompleted() => SurfaceDetected && EquipmentPlaced && EquipmentInspected;
    }
}
