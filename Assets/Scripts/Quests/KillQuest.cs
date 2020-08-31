using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new KillQuest", menuName = "Quests/Kill Quest")]
[Serializable]
public class KillQuest : Quest
{
    public int killsRequired;
    public int killsCompleted;
    public string killTargetTag;
}
