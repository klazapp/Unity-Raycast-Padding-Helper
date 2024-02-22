# Raycast Padding Helper Utility for Unity

## Introduction
The `Raycast Padding Helper` utility, part of the `com.Klazapp.Utility` namespace, is designed to assist with accurate collision detection using raycasts. It helps to prevent objects from intersecting or "tunneling" through each other, especially at high speeds or when using fast-moving physics objects.

## Features
- It adds a small buffer or padding around the collider of the object. This padding helps to ensure that the raycasts are not cast from exactly the surface of the collider, which can lead to inaccuracies due to floating-point precision issues.
- It can adjust the direction of the raycasts based on the surface normal of the collider. This adjustment helps to ensure that the raycasts are cast in a direction that is perpendicular to the surface of the collider, which improves the accuracy of collision detection, especially for sloped surfaces.

## Dependencies
To use `Raycast Padding Helper`, certain dependencies are required. Ensure these are included in your Unity project.
- **Unity Version**: Minimum Unity 2020.3 LTS.
- Unity Mathematics DLL

## Compatibility
| Compatibility        | URP | BRP | HDRP |
|----------------------|-----|-----|------|
| Compatible           | ✔️  | ✔️  | ✔️   |

## Installation
1. Open the Unity Package Manager (`Window` > `Package Manager`).
2. Click `+`, select `Add package from git URL...`, and enter `https://github.com/klazapp/Unity-Raycast-Padding-Helper-Public.git`.
3. Unity will download and make the package available in your project.

## Usage
```csharp
Write Something here
```

## To-Do List (Future Features)
- 
## License
This utility is released under the [MIT License](LICENSE).
