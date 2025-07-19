using UnityEngine;

public class Chunk
{

    public const int width = 16;
    public const int height = 16;
    public const int depth = 64;

    public IBlock[,,] blocks = new IBlock[width, height, depth];

    public void SetBlock(int x, int y, int z, IBlock block)
    {
        blocks[x, y, z] = block;
    }

    public IBlock GetBlock(int x, int y, int z)
    {
        return blocks[x, y, z];
    }
}
