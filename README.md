# AR Industrial Training Simulator




## Project Overview

The application presents a structured AR training flow for industrial equipment handling and inspection. Users begin in a welcome screen, enter the AR session, detect a real-world surface, place a virtual equipment model, and complete a guided checklist as each task is validated. The experience is organized to be clear, focused, and suitable for presentation in a technical portfolio.

## Features

- Welcome screen with project branding and a Start Training action.
- Real-world surface detection using AR Foundation.
- Tap-based placement of industrial equipment in the AR scene.
- Tap-to-inspect interaction for placed equipment.
- Guided training steps presented through an on-screen checklist.
- Visual progress feedback with completed-step checkmarks.
- Completion state with a final success message.

## Technologies Used

- Unity
- AR Foundation
- C#
- ARCore
- Unity UI and OnGUI overlays

## Use Case / Objective

The objective of this project is to demonstrate how augmented reality can be applied to industrial training workflows with a clear validation loop. The application is suitable for scenarios such as equipment familiarization, procedural walkthroughs, and introductory AR-based task guidance. It also serves as a compact portfolio example of AR interaction design, runtime state tracking, and user feedback handling.

## Setup Instructions

1. Install Unity with AR Foundation and ARCore support enabled.
2. Open the project in Unity and load the `ARTraining` scene from `Assets/Scenes`.
3. Confirm that the scene contains the required AR Foundation components:
   - `AR Session`
   - `AR Session Origin` or `XR Origin` configured for AR
   - `AR Camera`
   - `ARRaycastManager`
4. Assign an industrial equipment prefab to `PlaceOnTap.EquipmentPrefab`.
5. Add the training scripts to a bootstrap GameObject in the scene:
   - `TrainingManager`
   - `ChecklistUI`
   - `PlaceOnTap`
   - `TapToInspect`
6. Build and deploy the project to an ARCore-supported Android device.
7. Start the application, tap **Start Training**, place the equipment on a detected surface, and inspect it to complete the workflow.

## Future Improvements

- Replace the current OnGUI overlays with a fully styled Canvas-based UI.
- Add multiple equipment models and task variations for extended training scenarios.
- Introduce task timers and score tracking for performance evaluation.
- Expand validation logic to support multi-step equipment procedures.
- Add visual indicators for surface readiness and placement accuracy.
- Include tutorial prompts for first-time users.

## Screenshots

A visual gallery of in-app mockups is available in the repository `docs/` folder and is served by GitHub Pages when enabled:

- Gallery: [docs/index.md](docs/index.md)

If you prefer the images inline, they are also available at `docs/screenshots/`.
