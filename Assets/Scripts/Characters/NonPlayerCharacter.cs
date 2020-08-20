using UnityEngine;

/// <summary>
/// This class handle Non player character. It store their lines of dialogues and the portrait to display.
/// The player controller will call the Advance function when the player press the interact button in front of the NPC
/// The advance function will return false as long as there is new dialogue line, but return true once finished.
/// (Used by Player Controller to block movement until the dialogue is finished)
/// </summary>
public class NonPlayerCharacter : MonoBehaviour
{
    public Awaken status;
    public QuestGiver currentQuest;
    public GameObject dialogBox;
    public GameObject talkNotifier;
    public bool isQuestGiver;
    public GameObject questToken;


    void Start()
    {
        NPCManager.NPCCharacter bobby = NPCManager.npcManager.GetNPC(status.ID);
        if (bobby != null)
        {
            status.awakeningStatus = bobby.status;
            currentQuest.questToGive = bobby.currentQuest;
            talkNotifier.SetActive(bobby.haveSpoken);
            questToken.SetActive(bobby.hasQuest);
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
        talkNotifier.SetActive(false);
        NPCManager.npcManager.UpdateNPCList(status.ID, status.awakeningStatus, currentQuest.questToGive, talkNotifier.activeSelf, questToken.activeSelf);
    }

    public void CloseDialog()
    {
        Time.timeScale = 1f;
        dialogBox.SetActive(false);
        questToken.SetActive(true);
    }
}
