using System.Collections.Generic;
using UnityEngine;

public class World
{
    public List<Chunk> Chunks { get; private set; } = new List<Chunk>();
    
    public IPlayer Player { get;  set; }


    public IEnumerable<Chunk> PrepareWorld(IWorldGenerator worldGenerator, int range)
    {
        List<Chunk> returnChunks = new List<Chunk>();
        Vector3 playerPosition = Player.Position;
        Vector3Int centorChunkPosition = new Vector3Int(Mathf.FloorToInt(playerPosition.x / 16), 0, Mathf.FloorToInt(playerPosition.z / 16));
        
        Chunk? centorChunk = Chunks.Find(chunk => chunk.X == centorChunkPosition.x && chunk.Z == centorChunkPosition.z);
        if (centorChunk is null)
        {
            centorChunk = worldGenerator.GenerateChunk(centorChunkPosition.x, centorChunkPosition.z);
            Chunks.Add(centorChunk);
        }
        
        returnChunks.Add(centorChunk);

        return returnChunks;
    }
}
