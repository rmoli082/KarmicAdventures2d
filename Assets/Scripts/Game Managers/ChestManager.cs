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

   public void UpdateChest(int chestID, Chest.ChestState status)
   {
       chestList[chestID] = status;
   }
   
}
