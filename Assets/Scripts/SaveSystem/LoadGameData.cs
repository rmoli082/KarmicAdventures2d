using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadGameData : MonoBehaviour
{
    public void LoadGame()
    {
        string[] separators = { " \n Click to Load" };
        string[] tokens = this.GetComponent<TextMeshProUGUI>().text.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
        CharacterSheet.charSheet.playerName = tokens[0];
        GameEvents.OnLoadInitiated();
        GameManager.gm.EnterSubArea(SaveLoad.Load<string>("SceneToLoad"));
    }
}
