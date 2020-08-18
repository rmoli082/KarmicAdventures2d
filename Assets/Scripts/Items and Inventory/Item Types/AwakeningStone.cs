using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new AwakeningStone", menuName = "Items/AwakeningStone")]
[Serializable]
public class AwakeningStone : Items
{
    public Avatar avatarForm;
    public override void Use()
    {
        if (Player.player.currentAvatar == avatarForm)
        {
            RaycastHit2D hit = Physics2D.Raycast(GameManager.gm.data.player.GetComponent<Rigidbody2D>().position + Vector2.up * 0.2f, GameManager.gm.data.player.GetComponent<RubyController>().lookDirection, 1.5f, 1 << LayerMask.NameToLayer("NPC"));
            if (hit.collider != null)
            {
                Awaken awaken = hit.collider.GetComponent<Awaken>();
                if (awaken != null)
                {
                    awaken.Awakening(this.itemID);
                }
            }
        }
    }
}
