using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
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

    IEnumerator PopUpPause()
    {
        Debug.Log("Enter coroutine");
        yield return new WaitForSecondsRealtime(2.0f);
        Debug.Log("Wait ended");
        savedTile.SetActive(false);
    }
}
