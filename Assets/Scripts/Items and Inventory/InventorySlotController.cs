using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public int amount;
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
        Image textBack = transform.Find("TextBack").GetComponent<Image>();
        TextMeshProUGUI amountText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        Dictionary<Item, int> inventory = Inventory.inventory.GetItems();
       
       if (item)
       {
            displayImage.sprite = item.itemIcon;
            displayImage.color = Color.white;
            textBack.enabled = true;
            amountText.enabled = true;
            amountText.text = inventory[item].ToString();
       }
       else
       {
            displayImage.sprite = null;
            displayImage.color = Color.clear;
            textBack.enabled = false;
            amountText.enabled = false;
       }
   }

   public void Use() 
   {
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
