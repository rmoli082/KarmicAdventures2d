using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Awaken Quest", menuName = "Quests/AwakenQuest") ]
[Serializable]
public class AwakenQuest : Quest
{
    public int numberToAwaken;
    public int numberAwakened;
}
