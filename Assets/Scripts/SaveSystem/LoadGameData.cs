using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadGameData : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame()
    {
        CharacterSheet.charSheet.playerName = this.GetComponent<TextMeshProUGUI>().text;
        GameEvents.OnLoadInitiated();
        GameManager.gm.EnterSubArea(SaveLoad.Load<string>("SceneToLoad"));
    }
}
