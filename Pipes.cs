using Godot;
using System;

[GlobalClass]
public partial class Pipes : Node2D
{
	[Export]
	float _speed = 5f;

	[Export] 
	public float MaxSpacing = 100f;

	[Export] 
	public float DistanceFromBorder = 50f;

	private int _id = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		LevelInfos.Instance.PipesList.Add(this);
		_id = LevelInfos.Instance.PipesList.Count - 1;
		SetPosition(new Vector2(_id * 200, _get_new_height()));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Translate(new Vector2((float)delta * _speed, 0));
	}

	private float _get_new_height()
	{
		int prevId = 0;
		if (_id == 0)
		{
			prevId = LevelInfos.Instance.PipesList.Count - 1;
		}
		else
		{
			prevId = _id - 1;
		}
		
		Pipes prevPipe = LevelInfos.Instance.PipesList[prevId];

		float distance = GD.Randf() * MaxSpacing;

		int distanceDirection = GD.Randi() % 2 == 0 ? -1 : 1;

		float finalPositionY = (distanceDirection * distance) + prevPipe.Position.Y;
		
		GD.Print(_id + " -> Avant: " + (finalPositionY).ToString());
		
		if ((finalPositionY + (DisplayServer.WindowGetSize().Y / 2) - 73.5) + DistanceFromBorder < 0)
		{
			distanceDirection = 1;
			finalPositionY = (distanceDirection * distance) + prevPipe.Position.Y;
		}
		else if (finalPositionY + (DisplayServer.WindowGetSize().Y - ((DisplayServer.WindowGetSize().Y / 2) - 73.5)) - DistanceFromBorder > DisplayServer.WindowGetSize().Y)
		{
			distanceDirection = -1;
			finalPositionY = (distanceDirection * distance) + prevPipe.Position.Y;
		}
		
		GD.Print(_id + " -> Apres: " + (finalPositionY).ToString());

		return finalPositionY;
	}
}
