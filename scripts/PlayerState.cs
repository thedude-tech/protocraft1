using Godot;
using System;

public partial class PlayerState : Resource
{
    [Export] public int Health { get; set; } = 100;
    [Export] public int Stamina { get; set; } = 100;
    [Export] public Vector3 Position { get; set; } = Vector3.Zero;
    [Export] public Godot.Collections.Dictionary<string, int> Inventory { get; set; } = new Godot.Collections.Dictionary<string, int>();
    [Export] public int Xp { get; set; } = 0;
    [Export] public Godot.Collections.Array<string> Skills { get; set; } = new Godot.Collections.Array<string>();

    public Godot.Collections.Dictionary ToDict()
    {
        return new Godot.Collections.Dictionary
        {
            {"health", Health},
            {"stamina", Stamina},
            {"position", Position},
            {"inventory", Inventory},
            {"xp", Xp},
            {"skills", Skills}
        };
    }

    public void FromDict(Godot.Collections.Dictionary data)
    {
        if (data.ContainsKey("health")) Health = (int)data["health"];
        if (data.ContainsKey("stamina")) Stamina = (int)data["stamina"];
        if (data.ContainsKey("position")) Position = (Vector3)data["position"];
        if (data.ContainsKey("inventory")) Inventory = (Godot.Collections.Dictionary<string, int>)data["inventory"];
        if (data.ContainsKey("xp")) Xp = (int)data["xp"];
        if (data.ContainsKey("skills")) Skills = (Godot.Collections.Array<string>)data["skills"];
    }
}
