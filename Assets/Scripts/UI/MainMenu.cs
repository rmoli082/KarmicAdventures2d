using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject aboutPanel;
    public string nextScene;

    public void NewGame()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void LoadGame()
    {

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
