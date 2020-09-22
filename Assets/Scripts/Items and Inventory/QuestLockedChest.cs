using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLockedChest : TreasureChest
{
    public Quest quest;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        dialogBox.SetActive(false);
        if (item.Length != 0)
        {
            itemChoice = Random.Range(0, item.Length);
        }
    }

    public override void DisplayDialog()
    {
        List <Quest> questList = QuestManager.questManager.GetQuestsByStatus(Quest.QuestProgress.CURRENT);
        if (questList.Contains(quest))
        {
            base.DisplayDialog();
        }
        else
        {
            dialogText.text = "This is locked by magic. You must possess the right mindset to open it.";
            dialogBox.SetActive(true);
        }
        
    }

    public override void GetTreasure()
    {
        List<Quest> questList = QuestManager.questManager.GetQuestsByStatus(Quest.QuestProgress.CURRENT);
        if (questList.Contains(quest))
        {
            base.GetTreasure();
        }
        else
        {
            dialogBox.SetActive(false);
        }

    }
}
