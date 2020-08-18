using UnityEngine;

/// <summary>
/// This class handle Non player character. It store their lines of dialogues and the portrait to display.
/// The player controller will call the Advance function when the player press the interact button in front of the NPC
/// The advance function will return false as long as there is new dialogue line, but return true once finished.
/// (Used by Player Controller to block movement until the dialogue is finished)
/// </summary>
public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    public GameObject talkNotifier;
    public bool isQuestGiver;
    public GameObject questToken;

    float timerDisplay;

    void Start()
    {
        talkNotifier.SetActive(true);
        dialogBox.SetActive(false);
        questToken.SetActive(false);
        timerDisplay = -1.0f;
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.fixedUnscaledDeltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
                Time.timeScale = 1f;
                if (isQuestGiver)
                {
                    questToken.SetActive(true);
                }
            }
        }
    }
    
    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
        talkNotifier.SetActive(false);
    }
}
