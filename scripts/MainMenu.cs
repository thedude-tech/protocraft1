using Godot;
using System;

public partial class MainMenu : Control
{
    public override void _Ready()
    {
        GetNode<Button>("VBoxContainer/NewGame").Pressed += OnNewGamePressed;
        GetNode<Button>("VBoxContainer/LoadGame").Pressed += OnLoadGamePressed;
        GetNode<Button>("VBoxContainer/Quit").Pressed += OnQuitPressed;
    }

    private void OnNewGamePressed()
    {
        GetTree().ChangeSceneToFile("res://main.tscn");
    }

    private void OnLoadGamePressed()
    {
        var main = (Node)ResourceLoader.Load<PackedScene>("res://main.tscn").Instantiate();
        GetTree().Root.AddChild(main);
        var saveManager = new SaveManager();
        main.AddChild(saveManager);
        var player = main.GetNode<Player>("Player");
        var world = main.GetNode<World>("World");
        saveManager.LoadGame(player, world);
        GetTree().CurrentScene.Free();
        GetTree().CurrentScene = main;
    }

    private void OnQuitPressed()
    {
        GetTree().Quit();
    }
}
