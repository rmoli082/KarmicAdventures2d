using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
   public Items item;

   void Start()
   {
       UpdateInfo();
   }

   public void UpdateInfo()
   {
       Image displayImage = transform.Find("Image").GetComponent<Image>();
       
       if (item)
       {
           displayImage.sprite = item.itemIcon;
           displayImage.color = Color.white;
       }
       else
       {
           displayImage.sprite = null;
           displayImage.color = Color.clear;
       }
   }

   public void Use() 
   {
       RubyController player = GameManager.gm.data.player.GetComponent<RubyController>();
       if (item)
       {
           item.Use();
       }
   }
}
