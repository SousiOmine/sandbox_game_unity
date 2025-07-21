using UnityEngine;

public class OverworldGenerator: IWorldGenerator
{
    public int Seed { get; set; }
    
    public OverworldGenerator(int seed)
    {
        Seed = seed;
    }
    public Chunk GenerateChunk(int chunkX, int chunkZ)
    {
        Chunk chunk = new Chunk(chunkX, chunkZ);
        float scale = 0.05f; // スケール係数を追加
        for (int x = 0; x < 16; x++)
        {
            for (int z = 0; z < 16; z++)
            {
                // スケールを乗算し、シードを座標ごとに分散
                float xSample = (x + chunkX * 16) * scale + Seed * 100;
                float zSample = (z + chunkZ * 16) * scale + Seed * 100;
                float noise = Mathf.PerlinNoise(xSample, zSample);

                float y_surface = 10 * noise;
                
                Debug.Log(y_surface);
                
                for (int y = 0; y < y_surface; y++)
                {
                    chunk.SetBlock(x, y, z, new DartBlock());
                }
            }
        }
        
        return chunk;
    }
}
