using Godot;
using System;

public partial class Main : Node
{
	public override void _Ready()
	{
		var world = GetNode("World") as Node;
		var player = GetNode("Player") as Node;

		if (world != null && player != null && world.HasMethod("Initialize"))
		{
			world.Call("Initialize", player);
		}
		else
		{
			GD.PrintErr("World or Player missing, or Initialize() not found.");
		}
	}
}
