using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalDoorTrigger : MonoBehaviour
{
    public enum TriggerConditions { Item, Quest, NPCStatus}

    public TriggerConditions trigger;
    public string loadLevel;

    public Item item;
    public Quest quest;
    public NonPlayerCharacter npc;
    public NonPlayerCharacter.AwakeningStatus status;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(Trigger())
                GameManager.gm.EnterSubArea(loadLevel);
        }
    }

    bool Trigger()
    {
        switch (trigger)
        {
            case TriggerConditions.Item:
                Dictionary<Item, int> inventory = Inventory.inventory.GetItems();
                if (inventory.ContainsKey(item))
                {
                    return true;
                }
                break;
            case TriggerConditions.Quest:
                List<Quest> quests = QuestManager.questManager.GetQuestsByStatus(Quest.QuestProgress.CURRENT);
                if (quests.Contains(quest))
                {
                    return true;
                }
                break;
            case TriggerConditions.NPCStatus:
                if (npc.awakeningStatus == status)
                {
                    return true;
                }
                break;
        }
        return false;
    }
}
