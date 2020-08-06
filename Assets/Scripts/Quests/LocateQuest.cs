using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new LocateQuest", menuName = "Quests/Locate Quest")]
[Serializable]
public class LocateQuest : Quest
{
    public string locationName;
}
