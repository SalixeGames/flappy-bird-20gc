using Godot;
using System;
using Godot.Collections;

public partial class LevelInfos : Node
{
	public static LevelInfos Instance { get; set; }
	
	public int Score { get; set; }
	public Array<Pipes> PipesList { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		PipesList = new Array<Pipes>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
