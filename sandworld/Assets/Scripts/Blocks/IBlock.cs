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
    public IItem item { get; }

    public HorizontalDirection Direction { get; }


}
