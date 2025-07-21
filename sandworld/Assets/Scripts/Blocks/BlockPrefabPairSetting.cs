using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BlockPrefabPair
{
    public string BlockID;
    public BlockBehaviorBase prefab;
}

[CreateAssetMenu(fileName = "BlockPrefabPairSetting", menuName = "Scriptable Objects/BlockPrefabPairSetting")]
public class BlockPrefabPairSetting : ScriptableObject
{
    public List<BlockPrefabPair> BlockList;

    // IDからプレハブを取得するメソッドを追加
    public BlockBehaviorBase GetPrefabById(string blockId)
    {
        if (BlockList == null) return null;
        
        foreach (var pair in BlockList)
        {
            if (pair.BlockID == blockId)
            {
                return pair.prefab;
            }
        }
        return null;
    }
}
