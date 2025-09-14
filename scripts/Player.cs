using Godot;
using System;

public partial class Player : CharacterBody3D
{
    public PlayerState State { get; private set; } = new PlayerState();

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
