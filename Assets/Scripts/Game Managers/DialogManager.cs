using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager dialogManager;

    public TextAsset storyJson;

    public Button choiceButtonPrefab;

    private Story _inkStory;
    private GameObject displayBoard;
    private TextMeshProUGUI dialogText;
    private NonPlayerCharacter npc;

    void Awake()
    {
        _inkStory = new Story(storyJson.text);

        if (dialogManager == null)
        {
            dialogManager = GetComponent<DialogManager>();
        }
        else if (dialogManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void GetNPCDialog(NonPlayerCharacter npc, GameObject displayBoard, TextMeshProUGUI dialogText)
    {
        this.displayBoard = displayBoard;
        this.dialogText = dialogText;
        this.npc = npc;
        _inkStory.ChoosePathString($"{this.npc.npcName}.{this.npc.awakeningStatus}");
        RefreshView();
    }

    void OnClickChoiceButton(Choice choice)
    {
        _inkStory.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    void RefreshView()
    {
        foreach (Transform child in displayBoard.transform)
        {
            if (child.CompareTag("choiceButton"))
            {
                Destroy(child.gameObject);
            }
        }

        while (_inkStory.canContinue)
        {
            string text = _inkStory.Continue();
            dialogText.text = text;
        }

        if (_inkStory.currentChoices.Count > 0)
        {
            for (int i = 0; i < _inkStory.currentChoices.Count; ++i)
            {
                Choice choice = _inkStory.currentChoices[i];
                Button button = Instantiate(choiceButtonPrefab, displayBoard.transform) as Button;
                button.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
                button.onClick.AddListener(delegate
                {
                    OnClickChoiceButton(choice);
                });
            }
        }
        else
        {
            Button button = Instantiate(choiceButtonPrefab, displayBoard.transform) as Button;
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Click to dismiss";
            button.onClick.AddListener(delegate
            {
                npc.CloseDialog();
            });
        }
    }

}
