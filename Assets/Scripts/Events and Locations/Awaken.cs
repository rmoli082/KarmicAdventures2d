using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Awaken : MonoBehaviour
{
    public enum AwakeningStatus { CRYSALIS, AWAKE}

    public int ID;
    public Sprite spriteToLoad;
    public Animator animatorToEnable;
    public AwakeningStone stoneToUse;
    public AwakeningStatus awakeningStatus;
    public TextMeshProUGUI awakeTextBox;
    public string awakenText;

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
            AwakeningManager.awakeningManager.UpdateList(ID);
            GameEvents.OnAwakenEvent();
            Inventory.inventory.RemoveItem(stoneToUse);
            GameManager.gm.ShowHidePanels(false);
            awakeTextBox.text = awakenText;
            this.gameObject.GetComponent<NonPlayerCharacter>().DisplayDialog();
            Time.timeScale = 0f;
        }
    }

}
