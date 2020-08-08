using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
   public static ChestManager chestManager;

   public Dictionary<int, Chest.ChestState> chestList = new Dictionary<int, Chest.ChestState>();

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
   }

    private void Start()
    {
        GameEvents.SaveInitiated += Save;
        GameEvents.LoadInitiated += Load;
    }

    public void UpdateChest(int chestID, Chest.ChestState status)
   {
       chestList[chestID] = status;
   }

    void Save()
    {
        SaveLoad.Save<Dictionary<int, Chest.ChestState>>(chestList, "Chests");
    }

    void Load()
    {
        chestList.Clear();
        chestList = SaveLoad.Load<Dictionary<int, Chest.ChestState>>("Chests");
    }

}
