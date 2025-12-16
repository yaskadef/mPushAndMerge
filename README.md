## Packages used: 
- Extenject
- R3(ObservableCollections, ObservableCollections.R3, R3)
install: https://github.com/Cysharp/R3
- Newtonsoft.Json - install from NuGet

## Project structure
Project code execution starts with **GameEntryPoint**.
GameStateMachine controls the application states change.
Project has 3 scenes: Boot, MainMenu, Gameplay.
For MainMenu scene there is MainMenuEntryPoint.
For Gameplay scene there is GameplayEntryPoint.

Main UI of project is UIRootView.
MainMenuUI and GameplayUI are connected to UIRootView using SceneAttacherUI.
MainMenuUI and GameplayUI prefabs are located in the Assets/mPushAndMerge/Prefabs/UI/SceneUI/

## Implemented:

- State machine
- Scene management with parameters
- Data scripts
- Content settings
- Command processor
- Initialization of maps from settings
- User placement of buildings
- Saving and loading of game data
