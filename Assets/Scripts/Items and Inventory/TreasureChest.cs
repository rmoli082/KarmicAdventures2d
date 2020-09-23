using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
using TMPro;

public class TreasureChest : MonoBehaviour
{
    public enum ChestState { OPENED, CLOSED, USED }
    public int chestID;
    public ChestState status = ChestState.CLOSED;

    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    public int coinAmount;
    public Item[] item;

    protected int itemChoice;

    Scene _scene;

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

    protected virtual void Start()
    {
        _scene = SceneManager.GetActiveScene();
        if (_scene.name == "EnemyA")
        {
            int treasureChance = Random.Range(0,3);
            if (treasureChance >= 1) 
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                int id = this.chestID;
                while (ChestManager.chestManager.chestList.ContainsKey(id))
                {
                    id = Random.Range(1, 193734);
                    this.chestID = id;
                    this.status = ChestState.CLOSED;
                }
            }
            coinAmount = Random.Range(5, 11);
        }
        dialogBox.SetActive(false);
        if (item.Length != 0) 
        {
            itemChoice = Random.Range(0, item.Length);
        }
    }

    public virtual void DisplayDialog() {
        StringBuilder message = new StringBuilder();
        message.Append("Chest opened.\n You receive:\n");
        if (coinAmount > 0)
        {
            message.Append(coinAmount);
            message.Append(" coins \n");
        }
        if (item.Length != 0)
        {
            message.Append(item[itemChoice].itemName);
        }
        message.Append("\nPress enter to continue...");
        dialogText.text = message.ToString();
        dialogBox.SetActive (true);
    }

    public virtual void GetTreasure() {

        Inventory.inventory.AddCoins(coinAmount);
        if (item.Length > 0) {
            Inventory.inventory.AddItem(item[itemChoice]);
        }
        
    }


}
