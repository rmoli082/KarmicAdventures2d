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
    [SerializeField]
    private Dictionary<Item, int> itemList;
    [SerializeField]
    private List<Avatar> avatarList;

    void Awake()
    {
        if(inventory == null){
            inventory = this.GetComponent<Inventory>();
        } 
        else if(inventory != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        itemList = new Dictionary<Item, int>();
        avatarList = new List<Avatar>();
        UpdatePanelSlots();
    }

    void Start()
    {
        GameEvents.SaveInitiated += Save;
        GameEvents.LoadInitiated += Load;
    }

    public void AddCoins(int amount) 
    {
        wallet += amount;
        UpdatePanelSlots();
    }

    /*
    public void AddItem(Item item) 
    {
        if (itemList.Count < 24)
        {
            itemList.Add(item);
        }
        UpdatePanelSlots();
    }

    public void AddItems(List<Item> itemList)
    {
        foreach (Item item in itemList)
        {
            AddItem(item);
        }
    }

    public void AddItems(Item[] items)
    {
        foreach (Item item in items)
        {
            AddItem(item);
        }
    }
    */

    public void AddItem(Item item)
    {
        if (itemList.Count < 24)
        {
            if (itemList.ContainsKey(item))
            {
                itemList[item] += 1;
            }
            else
            {
                itemList[item] = 1;
            }
        }
        UpdatePanelSlots();
    }

    public void AddItems(Item[] items)
    {
        foreach (Item item in items)
        {
            AddItem(item);
        }
    }

    public void AddAvatarForm(Avatar avatar)
    {
        avatarList.Add(avatar);
    }

    public void RemoveItem(Item item)
    {
        itemList[item] -= 1;
        if (itemList[item] == 0)
        {
            itemList.Remove(item);
        }
        UpdatePanelSlots();
    }

    public Dictionary<Item, int> GetItems() {
        return itemList;
    }

    public List<Avatar> GetAvatars()
    {
        return avatarList;
    }

    public string GetCoins() {
        return wallet.ToString();
    }

    public void UpdatePanelSlots()
    {
        int index = 0;
        List<Item> panelList = new List<Item>();
        foreach (KeyValuePair<Item, int> keyPair in itemList)
        {
            panelList.Add(keyPair.Key);
        }

        foreach (Transform child in GameManager.gm.data.inventorySlots.transform)
        {
            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (index < itemList.Count)
            {
                slot.item = panelList[index];
            }
            else
            {
                slot.item = null;
            }

            slot.UpdateInfo();

            index++;
        }

        GameManager.gm.data.goldPieces.text = GetCoins();
        GameEvents.OnInventoryUpdated();
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

    void Save()
    {
        List<ItemSave> saveList = new List<ItemSave>();
        List<AvatarSave> avatarSaves = new List<AvatarSave>();

        foreach (KeyValuePair<Item, int> keypair in itemList)
        {
            for (int i = 0; i < keypair.Value; i++)
                saveList.Add(new ItemSave(keypair.Key));
        }

        foreach (Avatar avatar in avatarList)
        {
            avatarSaves.Add(new AvatarSave(avatar));
        }

        SaveLoad.Save<List<ItemSave>>(saveList, "Inventory");
        SaveLoad.Save<int>(wallet, "Wallet");
        SaveLoad.Save<List<AvatarSave>>(avatarSaves, "Avatars");
    }

    void Load()
    {
        if (SaveLoad.SaveExists("Inventory"))
        {
            itemList.Clear();
            List<ItemSave> saveList = SaveLoad.Load<List<ItemSave>>("Inventory");
            foreach (ItemSave item in saveList)
            {
                itemList[ItemDatabase.itemDb.GetItemByID(item.itemID)] += 1;
            }
            UpdatePanelSlots();
        }

        if (SaveLoad.SaveExists("Wallet"))
        {
            wallet = SaveLoad.Load<int>("Wallet");
            UpdatePanelSlots();
        }

        if (SaveLoad.SaveExists("Avatars"))
        {
            avatarList.Clear();
            List<AvatarSave> saveList = SaveLoad.Load<List<AvatarSave>>("Avatars");
            foreach (AvatarSave avatar in saveList)
            {
                avatarList.Add(AvatarDatabase.avatarDb.GetAvatarById(avatar.avatarID));
            }
            UpdateAvatarSlots();
        }
    }

}
