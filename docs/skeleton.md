# Skeleton (ProtoCraft)

## main.tscn
- Main (Node)
  - Player (CharacterBody3D)
  - World (Node3D)
  - UI (CanvasLayer)
    - HUD (Control)
    - PauseMenu (Control)
    - MainMenu (Control)

## player.tscn
- Player (CharacterBody3D)
  - CollisionShape3D
  - MeshInstance3D
  - Camera3D

## World.tscn
- World (Node3D)
  - (generated chunks at runtime)
