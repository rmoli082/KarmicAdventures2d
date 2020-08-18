using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public Items item;
    public Tooltip tooltip;

    void Awake()
    {
        tooltip = GameManager.gm.data.tooltip.GetComponent<Tooltip>();
    }

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.item != null)
        {
            tooltip.GenerateTooltip(this.item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }


}
