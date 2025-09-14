using Godot;
using System;

public partial class World : Node3D
{
    public WorldState State { get; private set; } = new WorldState();

    public Godot.Collections.Dictionary GetState()
    {
        State.Machines.Clear();
        foreach (var node in GetTree().GetNodesInGroup("machines"))
        {
            if (node is Machine m)
                State.Machines.Add(m.GetState());
        }
        return State.ToDict();
    }

    public void ApplyState(Godot.Collections.Dictionary data)
    {
        State.FromDict(data);
        // TODO: restore machines
    }
}
