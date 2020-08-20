using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject savedTile;

   public void Save()
   {
        GameEvents.OnSaveInitiated();
        savedTile.SetActive(true);
        StartCoroutine(PopUpPause());
        SaveLoad.Save<string>(SceneManager.GetActiveScene().name, "SceneToLoad");
    }

   public void Load()
   {
        Time.timeScale = 1f;
        GameManager.gm.data.pause.SetActive(false);
        GameEvents.OnLoadInitiated();
        GameManager.gm.EnterSubArea(SaveLoad.Load<string>("SceneToLoad"));
   }

    public void New()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Controls()
    {
        GameManager.gm.data.controlsFrame.SetActive(true);
    }

    IEnumerator PopUpPause()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        savedTile.SetActive(false);
    }
}
