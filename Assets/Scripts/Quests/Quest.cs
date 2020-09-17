using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Quest : ScriptableObject
{
    public enum QuestProgress {NOT_AVAILABLE, AVAILABLE, ACCEPTED, CURRENT, COMPLETED, DONE}
    public enum QuestType { KILL, FIND_ITEM, LOCATION, AWAKEN }

    public int questID;
    public string questLine;
    public QuestType questType;
    public string questTitle;
    public string questDesc;
    public QuestProgress questProgress;
    public string questHint;
    public string questCompleteText;
    public string questDoneText;
    public int nextQuest;
    public string questObjective;

    public int xpReward;
    public int goldReward;
    public Item[] itemRewards;
    public int posKarmaAwarded = 0;
    public int negKarmaAwarded = 0;

    public void GiveRewards()
    {
        CharacterSheet.charSheet.ChangeXP(xpReward);
        CharacterSheet.charSheet.ChangeSpiritKarma(posKarmaAwarded);
        CharacterSheet.charSheet.ChangeDemonKarma(negKarmaAwarded);
        Inventory.inventory.AddCoins(goldReward);
        Inventory.inventory.AddItems(itemRewards);
    }

}
