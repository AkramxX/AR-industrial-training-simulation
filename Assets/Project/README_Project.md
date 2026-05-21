AR Industrial Training Simulator

This project has been simplified for academic / portfolio use.

Kept scenes:

- Assets/Scenes/ARTraining.unity — training scene (surface detection, equipment placement, inspection)
- Assets/Scenes/PlaneDetection.unity — plane detection training scene reference

What I added:

- Assets/Scripts/WelcomeManager.cs — runtime welcome UI with Start Training button
- Assets/Scripts/InstructionPanel.cs — simple on-screen training steps
- Assets/Scripts/TrainingManager.cs — tracks training steps and progress
- Assets/Scripts/PlaceOnTap.cs — simple tap-to-place equipment behaviour using AR Raycast
- Assets/Scripts/Inspectable.cs — marker on placed objects to allow inspection
- Assets/Scripts/TapToInspect.cs — tap-to-inspect behaviour (raycast to placed object)
- Assets/Scripts/ChecklistUI.cs — on-screen checklist and final success message

Next steps (open in Unity):

- Attach `WelcomeManager` and `InstructionPanel` to an empty GameObject in the `ARTraining` training scene.
- Configure the AR Foundation prefabs (ARSession, ARSessionOrigin, AR Camera) if not present.
- Attach `TrainingManager`, `ChecklistUI`, `PlaceOnTap` and `TapToInspect` to a bootstrap GameObject in `ARTraining`.
- Set `PlaceOnTap.EquipmentPrefab` to the equipment prefab you want users to place.
- Ensure the placed equipment has an appropriate scale and visual; the scripts add a `BoxCollider` and `Inspectable` if missing.

Quick run steps inside Unity:

1. Open `ARTraining` scene.
2. Add an empty GameObject named `Bootstrap` and add components: `TrainingManager`, `ChecklistUI`, `PlaceOnTap`, `TapToInspect`.
3. Set `PlaceOnTap.EquipmentPrefab` to your equipment prefab.
4. Run on device and use the welcome UI's Start Training button.

Notes:

- I kept changes lightweight; full scene UI tuning should be done inside the Unity editor.
