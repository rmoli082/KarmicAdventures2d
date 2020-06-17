﻿using System.Collections;
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
           PlayerPrefsManager.ResetPlayerState(Player.player.baseStats.GetStats("hpmax"));
           ChestManager.chestManager.chestList.Clear();
           Debug.Log("Player health reset to " + Player.player.baseStats.GetStats("hpmax").ToString());
       }
   }
}
