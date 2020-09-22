using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
using TMPro;

public class TreasureChest : Chest
{
    public int coinAmount;
    public Item[] item;

    protected int itemChoice;

    Scene _scene;

    protected override void Awake()
    {
        base.Awake();
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
                    this.status = Chest.ChestState.CLOSED;
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

    public override void DisplayDialog() {
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

    public override void GetTreasure() {

        Inventory.inventory.AddCoins(coinAmount);
        if (item.Length > 0) {
            Inventory.inventory.AddItem(item[itemChoice]);
        }
        
    }


}
