# Skeleton (ProtoCraft)

⚠️ RULE: If the node structure changes, regenerate this file and commit a new version.  
This file is the **single source of truth** for scene hierarchy.

---

## main.tscn
- Main (Node)
  - Player (CharacterBody3D)
    - Camera3D (Camera3D) [current = true]
  - World (Node3D)
  - UI (CanvasLayer)
    - HUD (Control)
    - PauseMenu (Control)

## ui/hud.tscn
- HUD (Control)
  - Label (Label) [text = "HUD Placeholder"]

## ui/pause_menu.tscn
- PauseMenu (Control)
  - Label (Label) [text = "Pause Menu Placeholder"]
