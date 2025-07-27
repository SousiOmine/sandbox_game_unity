using UnityEngine;

public class Water: IBlock
{
    public string Id => "water";
    public IItem Item { get; }

    public HorizontalDirection Direction => HorizontalDirection.North;
}
