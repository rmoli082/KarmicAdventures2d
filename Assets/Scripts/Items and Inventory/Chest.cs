using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest: MonoBehaviour
{
    public enum ChestState{OPENED, CLOSED, USED}
    public int chestID;
    public ChestState status = ChestState.CLOSED;

    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    protected virtual void Awake()
    {
        if (ChestManager.chestManager.chestList.ContainsKey(chestID)) 
        {
            this.status = ChestManager.chestManager.chestList[chestID];
        }
        else
        {
            this.status = ChestState.CLOSED;
            ChestManager.chestManager.UpdateChest(chestID, status);
        }
    }

    public virtual void DisplayDialog() { }
    public virtual void GetTreasure() { }

}
