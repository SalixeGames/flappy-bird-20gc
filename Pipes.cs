using Godot;
using System;

public partial class Pipes : Node2D
{
	[Export]
	float _speed = 5f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Translate(new Vector2((float)delta * _speed, 0));
	}
}
