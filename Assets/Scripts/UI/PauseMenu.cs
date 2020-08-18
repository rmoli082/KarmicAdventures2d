using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject savedTile;

   public void Save()
   {
        GameEvents.OnSaveInitiated();
        savedTile.SetActive(true);
        StartCoroutine(PopUpPause());
    }

   public void Load()
   {
        GameEvents.OnLoadInitiated();
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
