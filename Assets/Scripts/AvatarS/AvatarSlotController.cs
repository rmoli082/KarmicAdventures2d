using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AvatarSlotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public Avatar avatar;
    public Tooltip tooltip;

    void Awake()
    {
        tooltip = GameManager.gm.data.tooltip.GetComponent<Tooltip>();
    }

   void Start()
   {
       UpdateInfo();
   }

   public void EquipAvatar()
    {
        AvatarSlotController currentAvatar = GameManager.gm.data.currentAvatar;
        currentAvatar.avatar = this.avatar;
        currentAvatar.UpdateInfo();


        CharacterSheet.charSheet.AdditiveModifier("attack", 1, this.avatar.attackUp, 0);
        CharacterSheet.charSheet.AdditiveModifier("defense", 1, this.avatar.defenseUp, 0);
        CharacterSheet.charSheet.AdditiveModifier("magic", 1, this.avatar.magicUp, 0);
        CharacterSheet.charSheet.CalculateStats();
        CharacterSheet.charSheet.ChangeAvatar(this.avatar);

        Player.player.SetAvatar(this.avatar.avatarID);
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.avatar != null)
        {
            tooltip.GenerateTooltip(this.avatar);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
