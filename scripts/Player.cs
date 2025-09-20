using Godot;
using System;

public partial class Player : CharacterBody3D
{
	[Export] public float Speed = 5.0f;
	[Export] public float SprintMultiplier = 1.5f;
	[Export] public float JumpVelocity = 4.5f;
	[Export] public float MouseSensitivity = 0.002f;
	[Export] public float Gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	private Node3D _cameraPivot;
	private Camera3D _camera;
	private float _pitch = 0f;

	public override void _Ready()
	{
		_camera = GetNode<Camera3D>("Camera3D");
		_cameraPivot = _camera.GetParent<Node3D>();
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion motion)
		{
			RotateY(-motion.Relative.X * MouseSensitivity);
			_pitch = Mathf.Clamp(_pitch - motion.Relative.Y * MouseSensitivity, -Mathf.Pi/2, Mathf.Pi/2);
			_camera.Rotation = new Vector3(_pitch, 0, 0);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Apply gravity
		if (!IsOnFloor())
			velocity.Y -= Gravity * (float)delta;

		// Handle jump
		if (Input.IsActionJustPressed("ui_jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Movement direction
		Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();

		float currentSpeed = Speed;
		if (Input.IsActionPressed("ui_sprint"))
			currentSpeed *= SprintMultiplier;

		if (direction != Vector3.Zero)
			velocity.Xz = direction.Xz * currentSpeed;
		else
			velocity.X = velocity.Z = 0;

		Velocity = velocity;
		MoveAndSlide();
	}
}
