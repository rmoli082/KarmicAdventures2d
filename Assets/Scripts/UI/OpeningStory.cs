using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningStory : MonoBehaviour
{
    public TMP_InputField inputField;
    public string levelToLoad;
    public GameObject storyPanel;
    public GameObject namePanel;

    public GameObject statsBar;
    public GameObject skillsBar;

    public void CloseStoryPanel()
    {
        storyPanel.SetActive(false);
        namePanel.SetActive(true);
    }
    public void SaveCharacterSheet()
    {
        Stats stats = statsBar.GetComponent<StatsBar>().GetBaseStats();
        Dictionary<string, int> skills = skillsBar.GetComponent<SkillsBar>().GetSkills();
        CharacterSheet.charSheet.BuildCharacterSheet(inputField.text, stats, skills);
        GameManager.gm.EnterSubArea(levelToLoad);
        
    }
}
