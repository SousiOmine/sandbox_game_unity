public class WorldGenerator: IWorldGenerator
{
    public int Seed { get; set; }
    public WorldGenerator(int seed)
    {
        Seed = seed;
    }



    public Chunk GenerateChunk(int chunkX, int chunkZ)
    {
        Chunk chunk = new Chunk(chunkX, chunkZ);
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 64; y++)
            {
                for (int z = 0; z < 16; z++)
                {
                    if (y < 10)
                    {
                        chunk.SetBlock(x, y, z, new DartBlock());
                    }
                }
            }
        }
        
        return chunk;
    }
    
}
