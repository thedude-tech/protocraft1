using Godot;
using System;

public partial class MainMenu : Control
{
    public override void _Ready()
    {
        GetNode<Button>("VBoxContainer/NewGameButton").Pressed += OnNewGamePressed;
        GetNode<Button>("VBoxContainer/LoadGameButton").Pressed += OnLoadGamePressed;
        GetNode<Button>("VBoxContainer/QuitButton").Pressed += OnQuitPressed;
    }

    private void OnNewGamePressed()
    {
        GetTree().ChangeSceneToFile("res://main.tscn");
    }

    private void OnLoadGamePressed()
    {
        GD.Print("Attempting to load game...");
        var saveManager = GetNodeOrNull<Node>("/root/SaveManager");
        if (saveManager != null && saveManager.HasMethod("LoadGame"))
        {
            saveManager.Call("LoadGame");
        }
        else
        {
            GD.Print("SaveManager not found, starting new game.");
        }
        GetTree().ChangeSceneToFile("res://main.tscn");
    }

    private void OnQuitPressed()
    {
        GetTree().Quit();
    }
}
