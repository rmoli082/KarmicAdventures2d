using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillsBar : MonoBehaviour
{

    public enum SkillsList { Stealth, Stamina, Duelist, Arcanist, Weaponmaster}

    public TMP_Dropdown firstDropdown;
    public TMP_Dropdown secondDropdown;
    public TextMeshProUGUI firstSkillDescription;
    public TextMeshProUGUI secondSkillDescription;

    private string firstSkill;
    private string secondSkill;

    private static string STEALTH = "The Stealth skill is used to determine how close the player character can get to an enemy/NPC before triggering an effect or the enemy aggro range.";
    private static string STAMINA = "The Stamina skill is used to determine how fast a player’s MP and HP restores.";
    private static string DUELIST = "The Duelist skill allows a player to equip either 2 weapons or 2 magic spells. The second weapon or spell wielded causes damage at a reduced rate.";
    private static string ARCANIST = "The Arcanist skill increases the player character’s proficiency with magic spells.";
    private static string WEAPONMASTER = "The Weaponmaster skill increases the player character’s proficiency with a weapon.";
    List<string> options = new List<string>();

    void Start()
    {
        LoadOptions();
        firstDropdown.ClearOptions();
        firstDropdown.AddOptions(options);
        firstSkillDescription.gameObject.SetActive(false);
        secondSkillDescription.gameObject.SetActive(false);
    }

    public void FirstDropdown()
    {
        LoadOptions();
        foreach (SkillsList skill in System.Enum.GetValues(typeof(SkillsList)))
        {
            if (skill.ToString().Equals(firstDropdown.options[firstDropdown.value].text))
            {
                options.Remove(skill.ToString());
            }
        }
        secondDropdown.ClearOptions();
        secondDropdown.AddOptions(options);
        secondDropdown.gameObject.SetActive(true);

        switch (firstDropdown.value)
        {
            case 1:
                firstSkillDescription.text = STEALTH;
                break;
            case 2:
                firstSkillDescription.text = STAMINA;
                break;
            case 3:
                firstSkillDescription.text = DUELIST;
                break;
            case 4:
                firstSkillDescription.text = ARCANIST;
                break;
            case 5:
                firstSkillDescription.text = WEAPONMASTER;
                break;
        }

        firstSkillDescription.gameObject.SetActive(true);
        firstSkill = firstDropdown.options[firstDropdown.value].text;
    }

    public void SecondDropdown()
    {
        switch (secondDropdown.options[secondDropdown.value].text)
        {
             case "Stealth":
                secondSkillDescription.text = STEALTH;
                break;
            case "Stamina":
                secondSkillDescription.text = STAMINA;
                break;
            case "Duelist":
                secondSkillDescription.text = DUELIST;
                break;
            case "Arcanist":
                secondSkillDescription.text = ARCANIST;
                break;
            case "Weaponmaster":
                secondSkillDescription.text = WEAPONMASTER;
                break;
        }

        secondSkillDescription.gameObject.SetActive(true);
        secondSkill = secondDropdown.options[secondDropdown.value].text;
    }

    public Dictionary<string, int> GetSkills()
    {
        Dictionary<string, int> skills = new Dictionary<string, int>
        {
            [firstSkill] = 1,
            [secondSkill] = 1
        };

        return skills;
    }

    void LoadOptions()
    {
        options.Clear();
        options.Add("");
        foreach (SkillsList skill in System.Enum.GetValues(typeof(SkillsList)))
        {
            options.Add(skill.ToString());
        }
    }

}
