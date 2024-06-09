using Godot;
using System;
using System.Numerics;

public partial class Scanner_HUD : Control
{

	private Vector2I Scanner_offset = new Vector2I(-16,0);

	[Export]
	public int Scanner_resolution_scale = 1;
	private TileMap Scanner_tilemap;
	private TileMap World_tilemap;

	private CharacterBody2D Player;


	/*
		camera scale in tiles 32 20.25
		camera scale in tiles int 32 20
	*/


	public override void _Ready()
	{

		Scanner_tilemap = GetNode<TileMap>("Scanner_map");
		World_tilemap = GetNode<TileMap>("/root/Game/Ground_tilemap");
		Player = GetNode<CharacterBody2D>("/root/Game/Player");

	}


	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("Scan")){
			Scan();
		}
	}

	public void Change_scanner_offset(){

		HSlider X_slider = GetNode<HSlider>("X_offset_slider");
		HSlider Y_slider = GetNode<HSlider>("Y_offset_slider");
		
		Scanner_offset = new Vector2I((int)X_slider.Value , (int)Y_slider.Value);

		GD.Print(Scanner_offset);

	}

	public void Scan(){

		Vector2I Player_position = (Vector2I)Player.Position / 36;

		for (int X = 0; X < 32; X++)
		{
			for (int Y = 0; Y < 21; Y++)
			{
				
				Vector2I Atlas_coordinates = World_tilemap.GetCellAtlasCoords(0,new Vector2I(X,Y) + Scanner_offset + Player_position );

				if(true){

					Scanner_tilemap.SetCell( 0 , new Vector2I(X,Y), 0 , Atlas_coordinates);

				}
			}
		}
	}
}
