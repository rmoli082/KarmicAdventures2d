using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NonPlayerCharacter : MonoBehaviour
{
    public enum AwakeningStatus { is_stone, is_awake }

    public int ID;
    public string npcName;
    public AwakeningStatus awakeningStatus = AwakeningStatus.is_stone;

    public GameObject dialogBox;
    public GameObject displayBoard;
    public TextMeshProUGUI dialogText;
    public GameObject talkNotifier;

    public bool isQuestGiver;
    public GameObject questToken;
    public Button buttonPrefab;

    public Sprite spriteToLoad;
    public Animator animatorToEnable;
    public AwakeningStone stoneToUse;
    public int posKarmaAwarded = 2;

    private void Awake()
    {
        if (NPCManager.npcManager.HasNPC(ID))
        {
            NPCManager.NPCCharacter thisNPC = NPCManager.npcManager.GetNPC(ID);
            questToken.SetActive(thisNPC.hasQuest);
            questToken.GetComponentInChildren<QuestGiver>().questToGive = thisNPC.currentQuest;
            if (thisNPC.currentQuest != null)
                questToken.GetComponentInChildren<QuestGiver>().questType = thisNPC.currentQuest.questType;
            talkNotifier.SetActive(thisNPC.haveSpoken);
            awakeningStatus = thisNPC.status;
            if (thisNPC.status == AwakeningStatus.is_awake)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteToLoad;
            }
        }
        
        
    }

    public void Awakening(int itemID)
    {
        if (stoneToUse.itemID == itemID)
        {
            SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
            sr.sprite = spriteToLoad;
            if (animatorToEnable != null)
            {
                animatorToEnable.enabled = true;
            }
            awakeningStatus = AwakeningStatus.is_awake;
            NPCManager.npcManager.UpdateNPCList(ID, awakeningStatus);
            GameEvents.OnAwakenEvent(this.gameObject.tag);
            GameManager.gm.SetInventoryActive(false);
            CharacterSheet.charSheet.ChangePosKarma(posKarmaAwarded);
            DisplayDialog();
        }
    }

    public void DisplayDialog()
    {
        DialogManager.dialogManager.GetNPCDialog(this, displayBoard, dialogText);
        GameManager.gm.data.overviewMap.SetActive(false);
        dialogBox.SetActive(true);
        Time.timeScale = 0f;
        if (talkNotifier.activeSelf)
            talkNotifier.SetActive(false);
        NPCManager.npcManager.UpdateNPCList(ID, talkNotifier.activeSelf, questToken.activeSelf);
    }

    public void CloseDialog()
    {
        Time.timeScale = 1f;

        foreach (Transform child in displayBoard.transform)
        {
            if (child.CompareTag("choiceButton"))
            {
                Destroy(child.gameObject);
            }
        }

        dialogBox.SetActive(false);
        if (isQuestGiver && !questToken.activeSelf)
        {
            questToken.SetActive(true);
            NPCManager.npcManager.UpdateNPCList(ID, talkNotifier.activeSelf, questToken.activeSelf);
        }

        GameManager.gm.data.overviewMap.SetActive(true);

    }

}