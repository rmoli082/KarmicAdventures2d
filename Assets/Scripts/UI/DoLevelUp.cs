using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoLevelUp : MonoBehaviour
{
    public void LevelUp()
    {
        GameManager.gm.data.levelUpButton.SetActive(false);
        GameManager.gm.data.levelUpPanel.SetActive(true);
    }

}
