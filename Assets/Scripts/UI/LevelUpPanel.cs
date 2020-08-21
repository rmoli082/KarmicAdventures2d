using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpPanel : MonoBehaviour
{
    public string stat;
    public string skill;

    public void SelectStat()
    {
        GameManager.gm.data.levelUpPanel.GetComponent<LevelUpPanel>().stat = this.gameObject.GetComponent<TextMeshProUGUI>().text;
    }

    public void SelectSkill()
    {
        GameManager.gm.data.levelUpPanel.GetComponent<LevelUpPanel>().skill = this.gameObject.GetComponent<TextMeshProUGUI>().text;
    }

    public void Setup(string text)
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Accept()
    {
        if (CharacterSheet.charSheet.baseStats.stats.ContainsKey(stat))
        {
            CharacterSheet.charSheet.baseStats.UpdateStats(stat, CharacterSheet.charSheet.baseStats.GetStats(stat) + 1);
        }
        if (CharacterSheet.charSheet.selectedSkills.ContainsKey(skill))
        {
            CharacterSheet.charSheet.selectedSkills[skill] += 1;
        }
        gameObject.SetActive(false);
    }
}
