using Godot;
using System;

public partial class Ground : TileMap
{

	[Export]
	public int Map_x_lenght = 100;
	[Export]
	public int Map_y_lenght = 100;

	private NoiseTexture2D Noise_texture;
	private FastNoiseLite Noise_maker;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Noise_texture = new NoiseTexture2D();
		Noise_maker = new FastNoiseLite();

		Noise_maker.NoiseType = FastNoiseLite.NoiseTypeEnum.Perlin;

		Noise_texture.Noise = Noise_maker;

		for (int x = 0; x < Map_x_lenght; x++)
		{
			for (int y = 0; y < Map_y_lenght; y++)
			{

				float Positional_noise = Noise_texture.Noise.GetNoise2D(x,y);

				if(Positional_noise > -1.0f && Positional_noise < 0.0f){

					SetCell( 0 , new Vector2I(x,y), 0 , new Vector2I(0,0));

				}else if(Positional_noise > 0.5f){

					SetCell( 0 , new Vector2I(x,y), 0 , new Vector2I(0,1));

				}
			}
		}
	}
}
