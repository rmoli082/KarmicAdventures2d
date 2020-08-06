using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new AwakeningStone", menuName = "Items/AwakeningStone")]
[Serializable]
public class AwakeningStone : Items
{
    public override void Use()
    {
        GameEvents.OnAwakenEvent();
    }
}
