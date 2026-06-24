using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	[Export]
	public float JumpVelocity = -600.0f;

	[Export] 
	public Label Points;

	public override void _Ready()
	{
		Points.Text = $"{LevelInfos.Instance.Score}";
	}

	// public override void _EnterTree()
	// {
	// 	Points.Text = $"{LevelInfos.Instance.Score}";
	// }

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		velocity += GetGravity() * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("Jump"))
		{
			velocity.Y = JumpVelocity;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		float capedVelocity = Velocity.Y;
		if (Velocity.Y > Math.Abs(JumpVelocity))
		{
			capedVelocity = Math.Abs(JumpVelocity);
		}

		float rotationAngle = -(capedVelocity / JumpVelocity) * 80;
		SetRotationDegrees(rotationAngle);
	}

	public void OnAreaEntered(Area2D area)
	{
		if (area.GetCollisionLayerValue(6))
		{
			// Give point
			LevelInfos.Instance.Score += 1;
			Points.Text = $"{LevelInfos.Instance.Score}";
		}
		else
		{
			GetTree().Paused = true;
		}
	}
}
