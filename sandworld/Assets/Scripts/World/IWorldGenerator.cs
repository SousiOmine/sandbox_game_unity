using UnityEngine;

public interface IWorldGenerator
{
    public int Seed { get; set; }
    public Chunk GenerateChunk(int chunkX, int chunkZ);
}
