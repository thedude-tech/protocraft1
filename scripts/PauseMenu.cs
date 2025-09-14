using Godot;
using System;

public partial class PauseMenu : Control
{
    public override void _Ready()
    {
        GetNode<Button>("VBoxContainer/Resume").Pressed += OnResumePressed;
        GetNode<Button>("VBoxContainer/Save").Pressed += OnSavePressed;
        GetNode<Button>("VBoxContainer/Quit").Pressed += OnQuitPressed;
        Hide();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_cancel"))
        {
            if (Visible)
                Hide();
            else
                Show();
        }
    }

    private void OnResumePressed()
    {
        Hide();
    }

    private void OnSavePressed()
    {
        var main = GetTree().CurrentScene;
        var player = main.GetNode<Player>("Player");
        var world = main.GetNode<World>("World");
        var saveManager = new SaveManager();
        main.AddChild(saveManager);
        saveManager.SaveGame(player, world);
    }

    private void OnQuitPressed()
    {
        GetTree().ChangeSceneToFile("res://ui/MainMenu.tscn");
    }
}
