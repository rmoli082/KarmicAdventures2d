using System.Collections;
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
        Player _player = Player.player;
        Debug.Log(this.avatar.avatarName);
        currentAvatar.avatar = this.avatar;
        currentAvatar.UpdateInfo();
        _player.currentAvatar = currentAvatar.avatar;
        switch (currentAvatar.avatar.avatarID)
        {
            case 0:
            _player.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            _player.activeStats["Attack"] = _player.activeStats["Attack"] + 2;
            Debug.Log(_player.activeStats["Attack"]);
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
