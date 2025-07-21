using System;
using UnityEngine;

public class ChunkBehavior : MonoBehaviour
{
    public Chunk TargetChunk;
    [SerializeField] BlockPrefabPairSetting PairSetting;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Materialize()
    {
        int x_width = 16;
        int y_width = 16;
        int depth = 64;
        for (int x = 0; x < x_width; x++)
        {
            for (int y = 0; y < y_width; y++)
            {
                for (int z = 0; z < depth; z++)
                {
                    IBlock block = TargetChunk.GetBlock(x, y, z);
                    if (block is null) continue;
                    BlockBehaviorBase prefab = PairSetting.GetPrefabById(block.Id);
                    if (prefab is null) continue;
                    
                    Vector3 newBlockPosition = new Vector3(TargetChunk.X * 16 + x, y, TargetChunk.Z * 16 + z);
                    BlockBehaviorBase newBlock = Instantiate(prefab, newBlockPosition, Quaternion.identity, this.transform);
                }
            }
        }
    }

}
