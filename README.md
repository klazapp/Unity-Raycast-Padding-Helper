# Raycast Padding Helper Utility for Unity

## Introduction

The Raycast Padding Helper, under the `com.klazapp.utility` namespace, is a Unity Editor tool designed to enhance the development experience by visually representing raycast padding around UI elements. This utility is particularly useful for developers working with UI components, allowing them to visually debug and adjust the raycast target areas directly within the Unity Editor. It does not modify runtime behavior or collision detection but provides a visual aid to ensure UI elements are interactable within the desired areas.

## Features

- **Visual Debugging of Raycast Padding:** Visualizes the additional padding around UI elements that are considered during raycast calculations, making it easier to adjust for desired interactivity.
- **Editor-Only Visualization:** Utilizes Unity Editor scripts to draw gizmos around UI elements, showing the effective area that can be interacted with, based on the specified raycast padding.
- **Customizable Visualization:** Supports both solid and dotted line visualizations for raycast padding boundaries, with adjustable color and shadow options for better visibility against various backgrounds.

## Dependencies

To use the Raycast Padding Helper, you'll need the following in your Unity project:

- **Unity Version:** Minimum Unity 2020.3 LTS or newer.
- **Unity Mathematics Package:** For vector and color calculations.
- **Unity Editor Scripting:** Since the utility involves custom gizmo drawing in the Unity Editor.

## Compatibility

The Raycast Padding Helper is editor-agnostic and is compatible across different rendering pipelines due to its operation within the Unity Editor environment.

| Compatibility | URP | BRP | HDRP |
|---------------|-----|-----|------|
| Compatible    | ✔️   | ✔️   | ✔️    |

## Installation

1. Ensure you have the Unity Mathematics package installed in your project.
2. Download the Raycast Padding Helper script from [GitHub repository](https://github.com/klazapp/Unity-Raycast-Padding-Helper-Public.git) or via the Unity Package Manager.
3. Add the script to a UI element in your scene to begin visualizing raycast padding in the Editor.

## Usage

Attach the `RaycastPaddingHelper` script to any UI element with an `Image` component. Once attached, the script will automatically draw gizmos around the element in the Unity Editor, reflecting the current raycast padding settings. These gizmos are only visible in the editor and do not affect the game's runtime behavior.

## To-Do List (Future Features)

- [ ] Support for non-rectangular UI components.
- [ ] Runtime visualization options for debugging purposes.

## License

This utility is released under the MIT License. Feel free to use, modify, and distribute it as part of your projects.
