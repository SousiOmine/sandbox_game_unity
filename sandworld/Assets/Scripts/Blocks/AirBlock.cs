using UnityEngine;

public class AirBlock : IBlock
{
    public string Id => "air";
    public IItem Item => new AirItem();

    public HorizontalDirection Direction => HorizontalDirection.North;
}
