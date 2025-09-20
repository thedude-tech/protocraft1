# Skeleton (ProtoCraft)

Rules section :
- never remove the rules section. always carry that section when generating a new skeleton.md .
- when regenerating it, make sure every files have his skeleton stored here.
- Also print the files project skeleton in here.
- if possible always give me example/correction that match what i have in my files.
- If you have a way to figure by yourself if stuff are correct in my files, do it, don't ask me to.

---

## Main Menu (ui/MainMenu.tscn)
- MainMenu (Control) [script=MainMenu.gd]
  - VBoxContainer
    - NewGameButton (Button)
    - LoadGameButton (Button)
    - QuitButton (Button)

## Main Scene (main.tscn)
- Main (Node) [script=Main.cs]
  - World (instance of World.tscn)
  - Player (instance of Player.tscn)
  - HUD (instance of HUD.tscn)
  - PauseMenu (instance of PauseMenu.tscn)

## World (World.tscn)
- World (Node3D) [script=WorldGenerator.cs]
  - (generated chunks at runtime via WorldGenerator.cs)

## Player (Player.tscn)
- Player (CharacterBody3D) [script=Player.cs]
  - CollisionShape3D (Capsule)
  - MeshInstance3D (CapsuleMesh)
  - Camera3D (Camera3D) [current=true]

## HUD (ui/HUD.tscn)
- HUD (Control) [script=HUD.gd]
  - Label (Label) [text="HUD Placeholder"]

## Pause Menu (ui/PauseMenu.tscn)
- PauseMenu (Control) [script=PauseMenu.gd]
  - VBoxContainer
    - Resume (Button)
    - Save (Button)
    - Quit (Button)
