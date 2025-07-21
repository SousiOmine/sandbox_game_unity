using UnityEngine;

public interface IPlayer
{
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }

    public int Health { get; set; }
}
