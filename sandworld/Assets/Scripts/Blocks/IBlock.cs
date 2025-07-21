using UnityEngine;

public enum HorizontalDirection
{ 
    North,
    East,
    South,
    West
}
public interface IBlock
{
    public string Id { get; }
    public IItem Item { get; }

    public HorizontalDirection Direction { get; }


}
