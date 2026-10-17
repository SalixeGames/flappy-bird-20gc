using Godot;
using System;
using Godot.Collections;

public partial class LevelInfos : Node
{
	public static LevelInfos Instance { get; set; }
	
	public int Score { get; set; }
	public Array<Pipes> PipesList { get; set; }
	
	public Dictionary<String, String> LeaderBoard { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		LoadGame();
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

	public void LoadGame()
	{
		using var file = FileAccess.Open("./leaderboard", FileAccess.ModeFlags.Read);
		if (file != null)
		{
			Variant dataVariant = file.GetVar(true);
			LeaderBoard = dataVariant.As<Dictionary<string, string>>();
			file.Close();
		}
		else
		{
			LeaderBoard = new Dictionary<string, string>();
		}
		GD.Print(LeaderBoard);
	}

	public void SaveGame()
	{
		using var file = FileAccess.Open("./leaderboard", FileAccess.ModeFlags.Write);
		
		file.StoreVar(LeaderBoard);
		file.Close();
	}
}
