﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CharacterSheet))]
public class CharacterSheetEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CharacterSheet charSheet = (CharacterSheet)target;
        if(GUILayout.Button("Print base stats"))
        {
            foreach (KeyValuePair<string, int> stat in charSheet.baseStats.GetAllStats())
            {
                Debug.Log($"{stat.Key}   {stat.Value}");
            }
            foreach (KeyValuePair<string, int> skill in charSheet.selectedSkills)
            {
                Debug.Log($"{skill.Key}   {skill.Value}");
            }
        }
        
    }
}
