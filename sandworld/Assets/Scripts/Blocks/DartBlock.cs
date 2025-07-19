using UnityEngine;

public class DartBlock : ItemBase
{
    public IItem item => new DartItem();

    public HorizontalDirection Direction => HorizontalDirection.North;
}
