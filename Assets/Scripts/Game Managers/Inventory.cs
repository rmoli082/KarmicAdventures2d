using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;

public class Inventory : MonoBehaviour
{

    public static Inventory inventory;
    private int wallet = 0;
    public List<Items> itemList;
    public List<Avatar> avatarList;

    void Awake()
    {
        if(inventory == null){
            inventory = this;
        } 
        else if(inventory != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        UpdatePanelSlots();
    }

    public void AddCoins(int amount) 
    {
        wallet += amount;
        UpdatePanelSlots();
    }

    public void AddItem(Items item) 
    {
        if (itemList.Count < 24)
        {
            itemList.Add(item);
        }
        UpdatePanelSlots();
    }

    public void RemoveItem(Items item)
    {
        itemList.Remove(item);
        UpdatePanelSlots();
    }

    public List<Items> GetItems() {
        return itemList;
    }

    public string GetCoins() {
        return wallet.ToString();
    }

    public void UpdatePanelSlots()
    {
        int index = 0;
        foreach (Transform child in GameManager.gm.data.inventoryCanvas.transform)
        {
            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (index < itemList.Count)
            {
                slot.item = itemList[index];
            }
            else
            {
                slot.item = null;
            }

            slot.UpdateInfo();

            index++;
        }

        GameManager.gm.data.goldPieces.GetComponent<Text>().text = GetCoins();
    }

    public void UpdateAvatarSlots()
    {
        int index = 0;
        foreach (Transform child in GameManager.gm.data.avatarPanel.transform)
        {
            AvatarSlotController slot = child.GetComponent<AvatarSlotController>();

            if (index < avatarList.Count)
            {
                slot.avatar = avatarList[index];
            }
            else
            {
                slot.avatar = null;
            }

            slot.UpdateInfo();

            index++;
        }
    }

 
}
