using Godot;
using System;

public partial class MachineState : Resource
{
    [Export] public string MachineId { get; set; } = "";
    [Export] public Vector3 Position { get; set; } = Vector3.Zero;
    [Export] public Godot.Collections.Dictionary Input { get; set; } = new Godot.Collections.Dictionary();
    [Export] public Godot.Collections.Dictionary Output { get; set; } = new Godot.Collections.Dictionary();
    [Export] public float Progress { get; set; } = 0f;

    public Godot.Collections.Dictionary ToDict()
    {
        return new Godot.Collections.Dictionary
        {
            {"machine_id", MachineId},
            {"position", Position},
            {"input", Input},
            {"output", Output},
            {"progress", Progress}
        };
    }

    public void FromDict(Godot.Collections.Dictionary data)
    {
        if (data.ContainsKey("machine_id")) MachineId = (string)data["machine_id"];
        if (data.ContainsKey("position")) Position = (Vector3)data["position"];
        if (data.ContainsKey("input")) Input = (Godot.Collections.Dictionary)data["input"];
        if (data.ContainsKey("output")) Output = (Godot.Collections.Dictionary)data["output"];
        if (data.ContainsKey("progress")) Progress = (float)data["progress"];
    }
}
