﻿using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new AwakeningStone", menuName = "Items/AwakeningStone")]
[Serializable]
public class AwakeningStone : Item
{
    public Avatar avatarForm;
    public override void Use()
    {
        if (CharacterSheet.charSheet.currentAvatar == avatarForm)
        {
            RaycastHit2D hit = Physics2D.Raycast(GameManager.gm.data.player.GetComponent<Rigidbody2D>().position + Vector2.up * 0.2f, 
                GameManager.gm.data.player.GetComponent<PlayerController>().lookDirection, 1.5f, 1 << LayerMask.NameToLayer("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter npc = hit.collider.GetComponent<NonPlayerCharacter>();
                if (npc != null && npc.awakeningStatus == NonPlayerCharacter.AwakeningStatus.is_stone)
                {
                    npc.Awakening(this.itemID);
                    Inventory.inventory.RemoveItem(this);
                }
            }
        }
    }
}
