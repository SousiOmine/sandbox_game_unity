using UnityEngine;

public class DartBlock : IBlock
{
    public string Id => "dart";
    public IItem Item => new DartItem();

    public HorizontalDirection Direction => HorizontalDirection.North;
}
