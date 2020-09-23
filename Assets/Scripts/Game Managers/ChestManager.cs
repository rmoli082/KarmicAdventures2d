using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
   public static ChestManager chestManager;

   public Dictionary<int, TreasureChest.ChestState> chestList = new Dictionary<int, TreasureChest.ChestState>();

   void Awake() 
   {
       if (chestManager == null)
       {
           chestManager = this.GetComponent<ChestManager>();
           chestList.Clear();
       }
       else if (chestManager != this)
       {
           Destroy(gameObject);
       }
        DontDestroyOnLoad(gameObject);
   }

    private void Start()
    {
        GameEvents.SaveInitiated += Save;
        GameEvents.LoadInitiated += Load;
    }

    public void UpdateChest(int chestID, TreasureChest.ChestState status)
   {
       chestList[chestID] = status;
   }

    void Save()
    {
        SaveLoad.Save<Dictionary<int, TreasureChest.ChestState>>(chestList, "Chests");
    }

    void Load()
    {
        chestList.Clear();
        chestList = SaveLoad.Load<Dictionary<int, TreasureChest.ChestState>>("Chests");
    }

}
