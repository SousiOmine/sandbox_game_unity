using System;
using UnityEngine;

public class DartBlockBehavior : BlockBehaviorBase
{
    private void Awake()
    {
        Block = new DartBlock();
    }
}
