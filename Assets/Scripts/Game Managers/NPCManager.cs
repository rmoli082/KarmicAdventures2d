using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager npcManager;

    Dictionary<int, NPCCharacter> npcList;

    private void Awake()
    {
        if (npcManager == null)
        {
            npcManager = this.GetComponent<NPCManager>();
        }
        else if  (npcManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        npcList = new Dictionary<int, NPCCharacter>();
    }

    public void UpdateNPCList(int id, Awaken.AwakeningStatus status, Quest currentQuest, bool haveSpoken, bool hasQuest)
    {
        npcList[id] = new NPCCharacter(status, currentQuest, haveSpoken, hasQuest);
    }

    public NPCCharacter GetNPC(int id)
    {
        if (npcList.ContainsKey(id))
        {
            Debug.Log("NPC Found");
            return npcList[id];
        }   
        else
            return null;
    }

    public class NPCCharacter
    {
        public Awaken.AwakeningStatus status;
        public Quest currentQuest;
        public bool haveSpoken;
        public bool hasQuest;

        public NPCCharacter(Awaken.AwakeningStatus status, Quest currentQuest, bool haveSpoken, bool hasQuest)
        {
            this.status = status;
            this.currentQuest = currentQuest;
            this.haveSpoken = haveSpoken;
            this.hasQuest = hasQuest;
        }
    }
}
