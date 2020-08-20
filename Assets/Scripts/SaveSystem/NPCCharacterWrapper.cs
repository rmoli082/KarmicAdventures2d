using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class NPCCharacterWrapper
{
    public Awaken.AwakeningStatus status;
    public int currentQuest;
    public bool haveSpoken;
    public bool hasQuest;

    public NPCCharacterWrapper(NPCManager.NPCCharacter npcCharacter)
    {
        status = npcCharacter.status;
        currentQuest = npcCharacter.currentQuest.questID;
        haveSpoken = npcCharacter.haveSpoken;
        hasQuest = npcCharacter.hasQuest;
    }
}
