using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public NonPlayerCharacter npc;

    public Quest questToGive;
    public Quest.QuestType questType;

    void Awake()
    {
        if (NPCManager.npcManager.GetNPC(npc.ID) == null)
            questToGive.questProgress = Quest.QuestProgress.AVAILABLE;
    }

    public void GiveQuest()
    {
        QuestManager.questManager.AcceptQuest(questToGive);
    }

    public void DisplayDialog()
    {
        if (!npc.dialogBox.activeSelf)
        {
            Quest.QuestProgress statusTest = questToGive.questProgress;

            Time.timeScale = 0f;

            GameManager.gm.data.overviewMap.SetActive(false);

            switch (statusTest)
            {
                case Quest.QuestProgress.AVAILABLE:
                    npc.dialogText.text = questToGive.questDesc;
                    GiveQuest();
                    break;
                case Quest.QuestProgress.CURRENT:
                case Quest.QuestProgress.ACCEPTED:
                    npc.dialogText.text = questToGive.questDesc;
                    break;
                case Quest.QuestProgress.COMPLETED:
                    npc.dialogText.text = questToGive.questCompleteText;
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
                    if (questType == Quest.QuestType.AWAKEN)
                    {
                        AwakenQuest quest = (AwakenQuest)questToGive;
                    }
                    QuestManager.questManager.SetQuestStatus(questToGive.questID, Quest.QuestProgress.DONE);
                    break;
                case Quest.QuestProgress.DONE:
                    npc.dialogText.text = questToGive.questDoneText;
                    questToGive.GiveRewards();
                    if (questToGive.nextQuest == -1)
                    {
                        this.gameObject.GetComponent<NonPlayerCharacter>().questToken.SetActive(false);
                        npc.isQuestGiver = false;
                        break;
                    }
                    questToGive = QuestManager.questManager.GetQuestById(questToGive.nextQuest);
                    QuestManager.questManager.SetQuestStatus(questToGive.questID, Quest.QuestProgress.AVAILABLE);
                    QuestManager.questManager.AcceptQuest(questToGive);
                    questType = questToGive.questType;
                    break;
                default:
                    break;
            }

            Button button = Instantiate(npc.buttonPrefab, npc.displayBoard.transform) as Button;
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Click to dismiss";
            button.onClick.AddListener(delegate
            {
                npc.CloseDialog();
            });

            npc.dialogBox.SetActive(true); 
        }
        else
        {
            Time.timeScale = 1f;
            npc.dialogBox.SetActive(false);
            GameManager.gm.data.overviewMap.SetActive(true);
        }

        NPCManager.npcManager.UpdateNPCList(npc.ID, questToGive, npc.talkNotifier.activeSelf, npc.questToken.activeSelf);
    }
}
