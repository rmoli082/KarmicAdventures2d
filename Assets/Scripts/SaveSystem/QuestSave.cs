using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestSave 
{
    public int questID;
    public string questName;
    public Quest.QuestProgress questStatus;

    public QuestSave() { }

    public QuestSave(Quest quest)
    {
        questID = quest.questID;
        questName = quest.questTitle;
        questStatus = quest.questProgress;
    }
}
