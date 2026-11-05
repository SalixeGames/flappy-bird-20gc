using Godot;
using System;

public partial class ControlMenu : Control
{
	[Export]
	public Control DeathMenu;
	[Export]
	public Button RestartButton;
	[Export]
	public Label DeathText;
	[Export]
	public Label HighscoreText;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		RestartButton.Pressed += OnPressed;
		RestartButton.Pressed += LevelInfos.Instance.Restart;
		
		DeathMenu.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnPressed()
	{
		DeathMenu.Hide();
	}

	public void _on_player_death()
	{
		DeathText.Text = $"Tes points: {LevelInfos.Instance.Score}";
		HighscoreText.Text = $"Meilleure score: {LevelInfos.Instance.GetBestScore().ToString()}";
		DeathMenu.Show();
	}
}
