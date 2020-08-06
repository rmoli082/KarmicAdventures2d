﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "new Avatar Stone", menuName = "Avatars/Avatar Stone")]
[Serializable]
public class AvatarStones : Items
{
    public Avatar avatarForm;
    public override void Use()
    {
        Inventory.inventory.avatarList.Add(avatarForm);
        Inventory.inventory.UpdateAvatarSlots();
        Inventory.inventory.RemoveItem(this);
    }
}
