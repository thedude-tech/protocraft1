using Godot;
using System;

public partial class WorldState : Resource
{
    [Export] public int Seed { get; set; } = 12345;
    [Export] public float TimeOfDay { get; set; } = 0f;
    [Export] public Godot.Collections.Array Machines { get; set; } = new Godot.Collections.Array();

    public Godot.Collections.Dictionary ToDict()
    {
        return new Godot.Collections.Dictionary
        {
            {"seed", Seed},
            {"time_of_day", TimeOfDay},
            {"machines", Machines}
        };
    }

    public void FromDict(Godot.Collections.Dictionary data)
    {
        if (data.ContainsKey("seed")) Seed = (int)data["seed"];
        if (data.ContainsKey("time_of_day")) TimeOfDay = (float)data["time_of_day"];
        if (data.ContainsKey("machines")) Machines = (Godot.Collections.Array)data["machines"];
    }
}
