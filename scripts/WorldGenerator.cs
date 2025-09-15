using Godot;
using System;

public partial class WorldGenerator : Node3D
{
	[Export] public int ChunkSize = 32;
	[Export] public float Scale = 1.0f;
	[Export] public int ViewDistance = 1; // 1 => 3x3 chunks
	[Export] public float HeightScale = 5f;
	[Export] public int Seed = 12345;

	private FastNoiseLite _noise;

	public override void _Ready()
	{
		_noise = new FastNoiseLite();
		_noise.Seed = Seed;
		_noise.Frequency = 0.05f;

		GenerateWorld();
		PlacePlayer();
	}

	private void GenerateWorld()
	{
		for (int x = -ViewDistance; x <= ViewDistance; x++)
		{
			for (int z = -ViewDistance; z <= ViewDistance; z++)
			{
				GenerateChunk(x, z);
			}
		}
	}

	private void GenerateChunk(int cx, int cz)
	{
		ArrayMesh mesh = new ArrayMesh();
		SurfaceTool st = new SurfaceTool();
		st.Begin(Mesh.PrimitiveType.Triangles);

		for (int x = 0; x < ChunkSize; x++)
		{
			for (int z = 0; z < ChunkSize; z++)
			{
				float wx = (cx * ChunkSize + x) * Scale;
				float wz = (cz * ChunkSize + z) * Scale;
				float wy = _noise.GetNoise2D(wx, wz) * HeightScale;

				// Simple quad vertices
				Vector3 v1 = new Vector3(wx, wy, wz);
				Vector3 v2 = new Vector3(wx + Scale, _noise.GetNoise2D(wx + Scale, wz) * HeightScale, wz);
				Vector3 v3 = new Vector3(wx, _noise.GetNoise2D(wx, wz + Scale) * HeightScale, wz + Scale);
				Vector3 v4 = new Vector3(wx + Scale, _noise.GetNoise2D(wx + Scale, wz + Scale) * HeightScale, wz + Scale);

				st.AddVertex(v1);
				st.AddVertex(v3);
				st.AddVertex(v2);

				st.AddVertex(v2);
				st.AddVertex(v3);
				st.AddVertex(v4);
			}
		}

		st.GenerateNormals();
		st.Commit(mesh);

		MeshInstance3D chunk = new MeshInstance3D();
		chunk.Mesh = mesh;
		AddChild(chunk);
	}

	private void PlacePlayer()
	{
		Node3D player = GetNodeOrNull<Node3D>("/root/Main/Player");
		if (player == null) return;

		float wx = 0;
		float wz = 0;
		float wy = _noise.GetNoise2D(wx, wz) * HeightScale;
		player.GlobalPosition = new Vector3(wx, wy + 2, wz);
	}
}
