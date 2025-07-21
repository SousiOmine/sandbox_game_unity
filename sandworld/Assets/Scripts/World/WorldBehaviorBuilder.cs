using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class WorldBehaviorBuilder : MonoBehaviour
{
    

    [SerializeField] ChunkBehavior ChunkBehaviorPrefab;
    
    Collection<Chunk> chunks = new();
    
    Collection<ChunkBehavior> chunkBehaviors = new();
    
    private void Awake()
    {
        // foreach (Chunk chunk in chunks)
        // {
        //     ChunkBehavior chunkBehavior = Instantiate(ChunkBehaviorPrefab, transform);
        //     chunkBehavior.TargetChunk = chunk;
        // }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLoadChunk(Chunk chunk)
    {
        chunks.Add(chunk);
        ChunkBehavior chunkBehavior = Instantiate(ChunkBehaviorPrefab, transform);
        chunkBehavior.TargetChunk = chunk;
        chunkBehaviors.Add(chunkBehavior);
        chunkBehavior.Materialize();
    }
    
    public void AddLoadChunk(IEnumerable<Chunk> chunks)
    {
        foreach (Chunk chunk in chunks)
        {
            AddLoadChunk(chunk);
        }
    }
}
