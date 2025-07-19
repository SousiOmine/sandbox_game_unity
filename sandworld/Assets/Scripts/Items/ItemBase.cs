using JetBrains.Annotations;
using UnityEngine;

public class ItemBase : MonoBehaviour, IItem
{
    public string Name => string.Empty;
    
    [CanBeNull] public Sprite Icon => null;
}
