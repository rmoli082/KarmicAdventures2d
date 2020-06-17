using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
   public override void OnInspectorGUI()
   {
       DrawDefaultInspector();

       GameManager myGm = (GameManager) target;
       if (GUILayout.Button("Reset Player State")) {
           PlayerPrefsManager.ResetPlayerState(myGm.startLives, myGm.startHealth);
           ChestManager.chestManager.chestList.Clear();
           Debug.Log("Player lives reset to " + myGm.startLives 
            + " and player health reset to " + myGm.startHealth);
       }
   }
}
