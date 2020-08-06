using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest questToGive;
    public GameObject questDialog;
    public TextMeshProUGUI questText;
    public Quest.QuestType questType;

    float timerDisplay;

    void Awake()
    {
        questToGive.questProgress = Quest.QuestProgress.AVAILABLE;
        timerDisplay = -1;
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                questDialog.SetActive(false);
            }
        }
    }

    public void GiveQuest()
    {
        QuestManager.questManager.AcceptQuest(questToGive);
    }

    public void DisplayDialog()
    {
        Quest.QuestProgress statusTest = questToGive.questProgress;
        questDialog.SetActive(true);
        timerDisplay = 4.0f;

        switch (statusTest)
        {
            case Quest.QuestProgress.AVAILABLE:
                questText.text = questToGive.questDesc;
                GiveQuest();
                break;
            case Quest.QuestProgress.CURRENT:
            case Quest.QuestProgress.ACCEPTED:
                questText.text = questToGive.questHint;
                break;
            case Quest.QuestProgress.COMPLETED:
                questText.text = questToGive.questCompleteText;
                if (questType == Quest.QuestType.FIND_ITEM)
                {
                    FindItem quest = (FindItem) questToGive;
                    quest.RemoveItem();
                }
                if (questType == Quest.QuestType.KILL)
                {

                }
                if (questType == Quest.QuestType.LOCATION)
                {
                }
                QuestManager.questManager.SetQuestStatus(questToGive.questID, Quest.QuestProgress.DONE);
                QuestManager.questManager.AcceptQuest(QuestManager.questManager.GetQuestById(questToGive.nextQuest));
                this.gameObject.GetComponent<NonPlayerCharacter>().questToken.SetActive(false);
                break;
            case Quest.QuestProgress.DONE:
                questText.text = questToGive.questCompleteText;
                this.gameObject.GetComponent<NonPlayerCharacter>().questToken.SetActive(false);
                break;
            default:
                break;
        }
        foreach (Quest quest in QuestManager.questManager.GetMyQuests())
        {
            Debug.Log($"{quest.questTitle} {quest.questProgress}");
        }
    }
}
