using Godot;
using System;

public partial class Machine : Node3D
{
    public MachineState State { get; private set; } = new MachineState();

    public override void _Ready()
    {
        ApplyState(State.ToDict());
    }

    public Godot.Collections.Dictionary GetState()
    {
        State.Position = GlobalTransform.origin;
        return State.ToDict();
    }

    public void ApplyState(Godot.Collections.Dictionary data)
    {
        State.FromDict(data);
        GlobalTransform = new Transform3D(GlobalTransform.basis, State.Position);
    }
}
