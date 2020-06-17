using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "new KillQuest", menuName = "Quests/Kill Quest")]
public class KillQuest : Quests
{
    public int numberToKill;
    private int killResults;
    public string enemyToKill;
    
}
