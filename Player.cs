using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	[Export]
	public float JumpVelocity = -600.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		velocity += GetGravity() * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept"))
		{
			velocity.Y = JumpVelocity;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		float CapedVelocity = Velocity.Y;
		if (Velocity.Y > Math.Abs(JumpVelocity))
		{
			CapedVelocity = Math.Abs(JumpVelocity);
		}

		float RotationAngle = -(CapedVelocity / JumpVelocity) * 80;
		SetRotationDegrees(RotationAngle);
	}
}
