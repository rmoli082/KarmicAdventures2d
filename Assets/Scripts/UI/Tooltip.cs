﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void GenerateTooltip(Item item)
    {
        string tooltipText = $"<b>{item.itemName}</b>\n{item.itemDescription}";
        gameObject.GetComponentInChildren<Text>().text = tooltipText;
        gameObject.SetActive(true);
    }

    public void GenerateTooltip(Avatar avatar)
    {
        string tooltiptext = $"<b>{avatar.avatarName}</b>\n{avatar.avatarDescription}\n\nAttack Up:{avatar.attackUp}\nDefense Up:{avatar.defenseUp}\nMagic Up:{avatar.magicUp}";
        gameObject.GetComponentInChildren<Text>().text = tooltiptext;
        gameObject.SetActive(true);
    }
}
