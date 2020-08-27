using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Awaken : MonoBehaviour
{
    public enum AwakeningStatus { CHRYSALIS, AWAKE}

    public int ID;
    public Sprite spriteToLoad;
    public Animator animatorToEnable;
    public AwakeningStone stoneToUse;
    public AwakeningStatus awakeningStatus;
    public TextMeshProUGUI awakeTextBox;
    public string awakenText;
    public NonPlayerCharacter npc;

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
            NPCManager.npcManager.UpdateNPCList(ID, awakeningStatus, npc.currentQuest.questToGive, npc.talkNotifier.activeSelf, npc.questToken.activeSelf);
            GameEvents.OnAwakenEvent();
            GameManager.gm.SetInventoryActive(false);
            awakeTextBox.text = awakenText;
            this.gameObject.GetComponent<NonPlayerCharacter>().DisplayDialog();
            Time.timeScale = 0f;
        }
    }

}
