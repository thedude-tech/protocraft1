using Godot;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		GD.Print("MainMenu Ready");

		// Find by name anywhere in the scene (works with/without VBoxContainer)
		var newGameBtn = FindChild("NewGameButton", true, false) as Button 
						 ?? FindChild("NewGame", true, false) as Button;
		var loadGameBtn = FindChild("LoadGameButton", true, false) as Button 
						  ?? FindChild("LoadGame", true, false) as Button;
		var quitBtn = FindChild("QuitButton", true, false) as Button 
					  ?? FindChild("Quit", true, false) as Button;

		GD.Print($"Btns -> New:{(newGameBtn!=null)} Load:{(loadGameBtn!=null)} Quit:{(quitBtn!=null)}");

		if (newGameBtn != null) newGameBtn.Pressed += OnNewGamePressed;
		if (loadGameBtn != null) loadGameBtn.Pressed += OnLoadGamePressed;
		if (quitBtn != null) quitBtn.Pressed += OnQuitPressed;
	}

	private void OnNewGamePressed()
	{
		GD.Print("New Game pressed");
		GetTree().ChangeSceneToFile("res://main.tscn");
	}

	private void OnLoadGamePressed()
	{
		GD.Print("Load Game pressed (stub)");
		// Later: call SaveManager.LoadGame() before switching
		GetTree().ChangeSceneToFile("res://main.tscn");
	}

	private void OnQuitPressed()
	{
		GD.Print("Quit pressed");
		GetTree().Quit();
	}
}
