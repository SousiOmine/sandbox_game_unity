using UnityEngine;

public class WaterBehavior : BlockBehaviorBase
{
    void Awake()
    {
        Block = new Water();
    }
}
