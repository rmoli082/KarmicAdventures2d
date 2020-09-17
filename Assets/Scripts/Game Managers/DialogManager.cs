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

    private Story _mainStory;
    private GameObject displayBoard;
    private TextMeshProUGUI dialogText;
    private NonPlayerCharacter npc;

    void Awake()
    {
        _mainStory = new Story(storyJson.text);

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

    void Start()
    {
        GameEvents.SaveInitiated += Save;
        GameEvents.LoadInitiated += Load;
    }

    public void GetNPCDialog(NonPlayerCharacter npc)
    {
        this.displayBoard = npc.displayBoard;
        this.dialogText = npc.dialogText;
        this.npc = npc;
        _mainStory.ChoosePathString($"{this.npc.npcName}.{this.npc.awakeningStatus}");
        RefreshView();
    }

    void OnClickChoiceButton(Choice choice)
    {
        _mainStory.ChooseChoiceIndex(choice.index);
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

        while (_mainStory.canContinue)
        {
            string text = _mainStory.Continue();
            dialogText.text = text;
        }

        if (_mainStory.currentChoices.Count > 0)
        {
            for (int i = 0; i < _mainStory.currentChoices.Count; ++i)
            {
                Choice choice = _mainStory.currentChoices[i];
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

    void Save()
    {
        SaveLoad.Save<string>(_mainStory.state.ToJson(), "StoryState");
    }

    void Load()
    {
        _mainStory.state.LoadJson(SaveLoad.Load<string>("StoryState"));
    }

}
