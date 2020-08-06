﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager questManager;

    public List<Quest> questList;
    private List<Quest> currentQuests = new List<Quest>();

    public GameObject questCompletedBox;
    public GameObject buttonPrefab;
    public GameObject questPrintbox;


    void Awake()
    {
        if (questManager == null)
        {
            questManager = this;
        }
        else if (questManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        questList = new List<Quest>(Resources.LoadAll<Quest>("Quests"));
    }

    void Start()
    {
        GameEvents.SaveInitiated += Save;
        GameEvents.LoadInitiated += Load;
        GameEvents.InventoryUpdated += CheckItemQuest;
        GameEvents.KillSuccessful += CheckKillQuest;
        GameEvents.LocationFound += CheckLocationQuest;
        GameEvents.AwakenEvent += CheckAwakenQuest;
    }

    public void AcceptQuest(Quest quest)
    {
        currentQuests.Add(quest);
        int index = currentQuests.IndexOf(quest);
        SetQuestStatus(quest.questID, Quest.QuestProgress.CURRENT);
    }

    public Quest GetQuestById(int questID)
    {
        foreach (Quest quest in questList)
        {
            if (quest.questID == questID)
            {
                return quest;
            }
        }
        return null;
    }

    public List<Quest> GetMasterQuestList()
    {
        return questList;
    }

    public List<Quest> GetMyQuests()
    {
        return currentQuests;
    }

    public List<Quest> GetQuestsByStatus(Quest.QuestProgress progress)
    {
        List<Quest> questList = new List<Quest>();
        foreach (Quest q in currentQuests)
        {
            if (q.questProgress == progress)
            {
                questList.Add(q);
            }
        }
        return questList;
    }

    public void SetQuestStatus(int questID, Quest.QuestProgress status)
    {
        foreach (Quest q in currentQuests)
        {
            if (questID == q.questID)
            {
                int index = currentQuests.IndexOf(q);
                currentQuests[index].questProgress = status;
            }
        }
    }

    public Quest.QuestProgress GetQuestStatus(int questID)
    {
        foreach (Quest q in currentQuests)
        {
            if (questID == q.questID)
            {
                return q.questProgress;
            }
        }

        return Quest.QuestProgress.NOT_AVAILABLE;
    }

    GameObject CreateButton(Quest quest)
    {
        GameObject b = Instantiate(buttonPrefab);
        b.GetComponent<QuestButton>().Setup(quest, questPrintbox);
        return b;
    }

    void Save()
    {
        List<QuestSave> saveList = new List<QuestSave>();
        foreach (Quest quest in currentQuests)
        {
            saveList.Add(new QuestSave(quest));
        }
        SaveLoad.Save<List<QuestSave>>(saveList, "Quests");
    }

    void Load()
    {
        if (SaveLoad.SaveExists("Quests"))
        {
            currentQuests.Clear();
            List<QuestSave> saveList = SaveLoad.Load<List<QuestSave>>("Quest");
            foreach (QuestSave q in saveList)
            {
                Quest quest = QuestManager.questManager.GetQuestById(q.questID);
                quest.questProgress = q.questStatus;
                currentQuests.Add(quest);
            }

        }
    }

    void CheckKillQuest(string tag)
    {
        foreach (Quest quest in QuestManager.questManager.currentQuests)
        {
            if (quest.questType == Quest.QuestType.KILL)
            {
                KillQuest killQuest = (KillQuest) quest;
                if (killQuest.killTarget.tag == tag && quest.questProgress == Quest.QuestProgress.CURRENT)
                {
                    killQuest.killsCompleted += 1;
                    if (killQuest.killsCompleted >= killQuest.killsRequired)
                    {
                        CompleteQuest(killQuest);
                    }
                }
            }
        }
    }

    void CheckAwakenQuest()
    {
        foreach (Quest quest in QuestManager.questManager.currentQuests)
        {
            if (quest.questType == Quest.QuestType.AWAKEN)
            {
                AwakenQuest awakenQuest = (AwakenQuest)quest;
                if (quest.questProgress == Quest.QuestProgress.CURRENT)
                {
                    awakenQuest.numberAwakened += 1;
                    if (awakenQuest.numberAwakened >= awakenQuest.numberToAwaken)
                    {
                        CompleteQuest(awakenQuest);
                    }
                }
            }
        }
    }

    void CheckItemQuest()
    {
        foreach (Quest quest in QuestManager.questManager.currentQuests) 
        {
            if (quest.questType == Quest.QuestType.FIND_ITEM)
            {
                FindItem itemQuest = (FindItem)quest;
                foreach (Items item in Inventory.inventory.itemList)
                {
                    if (item == itemQuest.itemRequired && itemQuest.questProgress == Quest.QuestProgress.CURRENT)
                    {
                        itemQuest.numberHeld += 1;
                        if (itemQuest.numberHeld == itemQuest.numberNeeded)
                        {
                            CompleteQuest(itemQuest);
                        }
                    }
                }
            }
        }
    }

    void CheckLocationQuest(string location)
    {
        foreach (Quest quest in QuestManager.questManager.currentQuests)
        {
            if (quest.questType == Quest.QuestType.LOCATION && quest.questProgress == Quest.QuestProgress.CURRENT)
            {
                LocateQuest locateQuest = (LocateQuest)quest;
                if (locateQuest.locationName == location)
                {
                    CompleteQuest(locateQuest);
                }
            }
        }

    }

    void CompleteQuest(Quest quest)
    {
        SetQuestStatus(quest.questID, Quest.QuestProgress.COMPLETED);
        GameManager.gm.data.questCompletedBox.SetActive(true);
        StartCoroutine(DeactivateBox(GameManager.gm.data.questCompletedBox));
    }

    IEnumerator DeactivateBox(GameObject box)
    {
        yield return new WaitForSecondsRealtime(2.0f);
        box.SetActive(false);
    }

}