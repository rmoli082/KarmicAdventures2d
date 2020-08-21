using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillsPanel : MonoBehaviour
{
    public GameObject buttonPrefab;

    private void Awake()
    {
        foreach (SkillsBar.SkillsList skill in System.Enum.GetValues(typeof(SkillsBar.SkillsList)))
        {
            Debug.Log("testing" + skill.ToString());
            foreach (KeyValuePair<string, int> pair in CharacterSheet.charSheet.selectedSkills)
            {
                Debug.Log(pair.Key);
            }
            GameObject b = Instantiate(buttonPrefab);
            b.SetActive(false);
            b.transform.SetParent(this.gameObject.transform, false);
            b.GetComponentInChildren<LevelUpPanel>().Setup(skill.ToString());
            if (CharacterSheet.charSheet.selectedSkills.ContainsKey(skill.ToString()))
            {
                b.SetActive(true);
            }
        }
    }
}
