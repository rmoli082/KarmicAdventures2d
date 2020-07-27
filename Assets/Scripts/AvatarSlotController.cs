﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSlotController : MonoBehaviour
{
   public Avatar avatar;

   void Start()
   {
       UpdateInfo();
   }

   public void EquipAvatar()
    {
        AvatarSlotController currentAvatar = GameManager.gm.data.currentAvatar;
        Debug.Log(this.avatar.avatarName);
        currentAvatar.avatar = this.avatar;
        currentAvatar.UpdateInfo();
        PlayerPrefsManager.SetAvatar(currentAvatar.avatar.avatarID);
        Debug.Log(PlayerPrefsManager.GetAvatar());
        Player.player.baseStats.AddModifier(0, new Stats(new Dictionary<string, int>(){
                {"attack", currentAvatar.avatar.attackUp},
                {"defense", currentAvatar.avatar.defenseUp},
                {"magic", currentAvatar.avatar.magicUp}
            }));
        Player.player.ReloadStats();
        switch (currentAvatar.avatar.avatarID)
        {
            case 0:
                Player.player.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                Player.player.gameObject.GetComponent<RubyController>().projectilePrefab = (GameObject) Resources.Load("Projectiles/SunProjectile");
                break;
            case 1:
                Player.player.gameObject.GetComponent<SpriteRenderer>().color = new Color(128f,128f,128f,0.5f);
                break;
            default:
                break;
        }
    }

   public void UpdateInfo()
   {
       Image displayImage = transform.Find("Image").GetComponent<Image>();
       
       if (avatar)
       {
           displayImage.sprite = avatar.avatarIcon;
           displayImage.color = Color.white;
       }
       else
       {
           displayImage.sprite = null;
           displayImage.color = Color.clear;
       }
   }
}
