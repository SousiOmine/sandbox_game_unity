using UnityEngine;

public class Chunk
{

    public const int X_width = 16;
    public const int Y_width = 16;
    public const int depth = 64;
    
    public int X { get; private set; }
    public int Z { get; private set; }

    public IBlock[,,] blocks = new IBlock[X_width, Y_width, depth];
    
    public bool IsGenerated { get; private set; } = false;
    
    public Chunk(int chunkX, int chunkZ)
    {
        X = chunkX;
        Z = chunkZ;
        
        for (int x = 0; x < X_width; x++)
        {
            for (int y = 0; y < Y_width; y++)
            {
                for (int z = 0; z < depth; z++)
                {
                    blocks[x, y, z] = new AirBlock();
                }
            }
        }
    }

    public void SetBlock(int x, int y, int z, IBlock block)
    {
        blocks[x, y, z] = block;
    }

    public IBlock GetBlock(int x, int y, int z)
    {
        return blocks[x, y, z];
    }
}
