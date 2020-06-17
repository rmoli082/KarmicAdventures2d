using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quests : ScriptableObject
{

    public enum QuestState {Unknown, Accepted, Completed}
    public int questID;
    public QuestState status;
    public string questName;
    public string questDescription;
    
}
