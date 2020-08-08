using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningStory : MonoBehaviour
{
    public TMP_InputField inputField;
    public string nextScene;
    public GameObject storyPanel;
    public GameObject namePanel;

    public void CloseStoryPanel()
    {
        storyPanel.SetActive(false);
        namePanel.SetActive(true);
    }
    public void SaveName()
    {
        GameManager.gm.playerName = inputField.text;
        GameManager.gm.EnterSubArea(nextScene);
    }
}
