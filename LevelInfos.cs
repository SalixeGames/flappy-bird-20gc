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
		GD.Print("Level Info ready");
		ProcessMode = ProcessModeEnum.Always;
		GD.Randomize(); 
		Instance = this;
		_initial_config();
	}

	private void _initial_config()
	{
		PipesList = new Array<Pipes>();
		Score = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("Restart"))
		{
			GetTree().Paused = false;
			GetTree().ReloadCurrentScene();
			_initial_config();
		}
	}
}
