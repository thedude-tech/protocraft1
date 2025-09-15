using Godot;
using System;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		var newGameBtn = GetNode<Button>("VBoxContainer/NewGameButton");
		var loadGameBtn = GetNode<Button>("VBoxContainer/LoadGameButton");
		var quitBtn = GetNode<Button>("VBoxContainer/QuitButton");

		newGameBtn.Pressed += OnNewGamePressed;
		loadGameBtn.Pressed += OnLoadGamePressed;
		quitBtn.Pressed += OnQuitPressed;
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
