using System;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public int Seed = 0;
    public World TargetWorld;
    
    [SerializeField] PlayerBehavior PlayerBehaviorPrefab;
    [SerializeField] WorldBehaviorBuilder WorldBehaviorBuilderPrefab;
    
    IWorldGenerator _worldGenerator;

    private void Awake()
    {
        _worldGenerator = new OverworldGenerator(Seed);

        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TargetWorld = new World();
        
        TargetWorld.Player = PlayerBehaviorPrefab;
        
        TargetWorld.PrepareWorld(_worldGenerator, 1);
        
        
        WorldBehaviorBuilder worldBehaviorBuilder = Instantiate(WorldBehaviorBuilderPrefab, transform.position, Quaternion.identity);
        worldBehaviorBuilder.AddLoadChunk(TargetWorld.Chunks);
        Debug.Log("WorldBehaviorBuilderPrefab");
        
        Instantiate(PlayerBehaviorPrefab, new Vector3(0, 4, 0), Quaternion.identity);
        Debug.Log("PlayerBehaviorPrefab");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
