using UnityEngine;

public class AirBlock : ItemBase
{
    public IItem item => new AirItem();

    public HorizontalDirection Direction => HorizontalDirection.North;
}
