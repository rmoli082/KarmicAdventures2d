using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject aboutPanel;
    public GameObject loadPanel;

    public GameObject loadGameButton;

    public string nextScene;

    private void Awake()
    {
        string path = Application.persistentDataPath + "/saves/";

        if (Directory.GetDirectories(path).Length != 0)
        {
            loadGameButton.SetActive(true);
        }
    }


    public void NewGame()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void LoadGame()
    {
        loadPanel.SetActive(true);
    }

    public void Controls()
    {
        controlsPanel.SetActive(true);
    }

    public void About()
    {
        aboutPanel.SetActive(true);
    }
}
