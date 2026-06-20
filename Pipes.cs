using Godot;
using System;

[GlobalClass]
public partial class Pipes : Node2D
{
	[Export]
	float _speed = 5f;

	private int _id = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_on_globals_ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Translate(new Vector2((float)delta * _speed, 0));
	}

	private void _on_globals_ready()
	{
		LevelInfos.Instance.PipesList.Add(this);
		_id = LevelInfos.Instance.PipesList.Count - 1;
		SetPosition(new Vector2(_id * 200, 0));
		GD.Print(_id.ToString());
	}
}
