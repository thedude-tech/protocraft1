using Godot;
using System;

public partial class Main : Node
{	
	private World _world;
	private Player _player;
	world.Initialize(player);
	private SaveManager _saveManager;

	public override void _Ready()
	{
		_player = GetNode<Player>("Player");
		_world = GetNode<World>("World");
		_saveManager = new SaveManager();
		AddChild(_saveManager);
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_save"))
			_saveManager.SaveGame(_player, _world);
		else if (@event.IsActionPressed("ui_load"))
			_saveManager.LoadGame(_player, _world);
	}
}
