using UnityEngine;

/// <summary>
/// This class handle Non player character. It store their lines of dialogues and the portrait to display.
/// The player controller will call the Advance function when the player press the interact button in front of the NPC
/// The advance function will return false as long as there is new dialogue line, but return true once finished.
/// (Used by Player Controller to block movement until the dialogue is finished)
/// </summary>
public class NonPlayerCharacter : MonoBehaviour
{
    public Awaken awaken;
    public QuestGiver currentQuest;
    public GameObject dialogBox;
    public GameObject talkNotifier;
    public bool isQuestGiver;
    public GameObject questToken;


    void Start()
    {
        NPCManager.NPCCharacter bobby = new NPCManager.NPCCharacter();
        bobby = NPCManager.npcManager.GetNPC(awaken.ID);
        if (bobby != null)
        {
            awaken.awakeningStatus = bobby.status;
            currentQuest.questToGive = bobby.currentQuest;
            questToken.GetComponentInChildren<QuestGiver>().questType = bobby.currentQuest.questType;
            talkNotifier.SetActive(bobby.haveSpoken);
            questToken.SetActive(bobby.hasQuest);
            if (bobby.status == Awaken.AwakeningStatus.AWAKE)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = awaken.spriteToLoad;
            }
        } 
        else
        {
            talkNotifier.SetActive(true);
            dialogBox.SetActive(false);
            questToken.SetActive(false);
        }
       
    }
    public void DisplayDialog()
    {
        dialogBox.SetActive(true);
        Time.timeScale = 0f;
        talkNotifier.SetActive(false);
        NPCManager.npcManager.UpdateNPCList(awaken.ID, awaken.awakeningStatus, currentQuest.questToGive, talkNotifier.activeSelf, questToken.activeSelf);
    }

    public void CloseDialog()
    {
        Time.timeScale = 1f;
        dialogBox.SetActive(false);
        if (isQuestGiver)
            questToken.SetActive(true);
    }
}
