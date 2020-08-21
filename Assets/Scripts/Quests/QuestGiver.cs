using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest questToGive;
    public NonPlayerCharacter npc;
    public GameObject questDialog;
    public TextMeshProUGUI questText;
    public Quest.QuestType questType;
    public float timerDisplay = 5f;
    private float currentTimer;

    void Awake()
    {
        if (NPCManager.npcManager.GetNPC(npc.status.ID) == null)
            questToGive.questProgress = Quest.QuestProgress.AVAILABLE;
    }

    
    public void GiveQuest()
    {
        QuestManager.questManager.AcceptQuest(questToGive);
    }

    public void DisplayDialog()
    {
        if (!questDialog.activeSelf)
        {
            Quest.QuestProgress statusTest = questToGive.questProgress;
            
            Time.timeScale = 0f;

            switch (statusTest)
            {
                case Quest.QuestProgress.AVAILABLE:
                    questText.text = questToGive.questDesc;
                    GiveQuest();
                    break;
                case Quest.QuestProgress.CURRENT:
                case Quest.QuestProgress.ACCEPTED:
                    questText.text = questToGive.questDesc;
                    break;
                case Quest.QuestProgress.COMPLETED:
                    questText.text = questToGive.questCompleteText;
                    if (questType == Quest.QuestType.FIND_ITEM)
                    {
                        FindItem quest = (FindItem)questToGive;
                        quest.RemoveItem();
                    }
                    if (questType == Quest.QuestType.KILL)
                    {
                        KillQuest quest = (KillQuest)questToGive;
                    }
                    if (questType == Quest.QuestType.LOCATION)
                    {
                        LocateQuest quest = (LocateQuest)questToGive;
                    }
                    QuestManager.questManager.SetQuestStatus(questToGive.questID, Quest.QuestProgress.DONE);
                    break;
                case Quest.QuestProgress.DONE:
                    questText.text = questToGive.questDoneText;
                    questToGive.GiveRewards();
                    if (questToGive.nextQuest == -1)
                    {
                        this.gameObject.GetComponent<NonPlayerCharacter>().questToken.SetActive(false);
                        break;
                    }
                    questToGive = QuestManager.questManager.GetQuestById(questToGive.nextQuest);
                    Debug.Log(questToGive.questTitle);
                    QuestManager.questManager.SetQuestStatus(questToGive.questID, Quest.QuestProgress.AVAILABLE);
                    QuestManager.questManager.AcceptQuest(questToGive);
                    NPCManager.npcManager.UpdateNPCList(npc.status.ID, npc.status.awakeningStatus, npc.currentQuest.questToGive, npc.talkNotifier.activeSelf, npc.questToken.activeSelf);
                    break;
                default:
                    break;
            }

            questDialog.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            questDialog.SetActive(false);
        }
    }
}
