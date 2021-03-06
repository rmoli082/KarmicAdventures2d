﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NPCManager : MonoBehaviour
{
    public static NPCManager npcManager;

    Dictionary<int, NPCCharacter> npcList;

    private void Awake()
    {
        if (npcManager == null)
        {
            npcManager = this.GetComponent<NPCManager>();
            npcList = new Dictionary<int, NPCCharacter>();
        }
        else if  (npcManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
    }

    void Start()
    {
        GameEvents.SaveInitiated += Save;
        GameEvents.LoadInitiated += Load;
    }

    public void UpdateNPCList(int id, NonPlayerCharacter.AwakeningStatus status)
    {
        NPCCharacter npc = GetNPC(id);
        npc.status = status;
        npcList[id] = npc;
    }

    public void UpdateNPCList(int id, Quest currentQuest, bool haveSpoken, bool hasQuest)
    {
        NPCCharacter npc = GetNPC(id);
        npc.currentQuest = currentQuest;
        npc.haveSpoken = haveSpoken;
        npc.hasQuest = hasQuest;
        npcList[id] = npc;
    }

    public void UpdateNPCList(int id, bool haveSpoken, bool hasQuest)
    {
        NPCCharacter npc = GetNPC(id);
        npc.haveSpoken = haveSpoken;
        npc.hasQuest = hasQuest;
        npcList[id] = npc;
    }

    public NPCCharacter GetNPC(int id)
    {
        if (npcList.ContainsKey(id))
        {
            return npcList[id];
        }   
        else
            return new NPCCharacter();
    }

    public bool HasNPC(int id)
    {
        if (npcList.ContainsKey(id))
        {
            return true;
        }

        return false;
    }

    void Save()
    {
        Dictionary<int, NPCCharacterWrapper> saveList = new Dictionary<int, NPCCharacterWrapper>();
        foreach (KeyValuePair<int, NPCCharacter> pair in npcList)
        {
            saveList[pair.Key] = new NPCCharacterWrapper(pair.Value);
        }
        SaveLoad.Save<Dictionary<int, NPCCharacterWrapper>>(saveList, "NPCList");
    }

    void Load()
    {
        if (SaveLoad.SaveExists("NPCList"))
        {
            npcList.Clear();
            Dictionary<int, NPCCharacterWrapper> saveList = new Dictionary<int, NPCCharacterWrapper>();
            saveList = SaveLoad.Load<Dictionary<int, NPCCharacterWrapper>>("NPCList");
            foreach (KeyValuePair<int, NPCCharacterWrapper> pair in saveList)
            {
                npcList[pair.Key] = new NPCCharacter(pair.Value.status, QuestManager.questManager.GetQuestById(pair.Value.currentQuest), pair.Value.haveSpoken, pair.Value.hasQuest);
            }
        }
    }

    [Serializable]
    public class NPCCharacter
    {
        public NonPlayerCharacter.AwakeningStatus status;
        public Quest currentQuest;
        public bool haveSpoken;
        public bool hasQuest;

        public NPCCharacter() 
        {
            this.status = NonPlayerCharacter.AwakeningStatus.is_stone;
            this.currentQuest = null;
            this.haveSpoken = false;
            this.hasQuest = false;
        }

        public NPCCharacter(NonPlayerCharacter.AwakeningStatus status, Quest currentQuest, bool haveSpoken, bool hasQuest)
        {
            this.status = status;
            this.currentQuest = currentQuest;
            this.haveSpoken = haveSpoken;
            this.hasQuest = hasQuest;
        }
    }
}
