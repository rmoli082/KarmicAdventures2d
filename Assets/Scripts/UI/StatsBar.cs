using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
    public float attack;
    public float defense;
    public float magic;
    public float special;

    public Slider attackSlider;
    public Slider defenseSlider;
    public Slider magicSlider;
    public Slider specialSlider;

    public TextMeshProUGUI attackDisplay;
    public TextMeshProUGUI defenseDisplay;
    public TextMeshProUGUI magicDisplay;
    public TextMeshProUGUI specialDisplay;
    public TextMeshProUGUI hpDisplay;
    public TextMeshProUGUI mpDisplay;

    public float totalStatPoints;
    private float currentStatPoints;
    public TextMeshProUGUI statPointsLeftDisplay;

    private void Start()
    {
        attack = attackSlider.value;
        defense = defenseSlider.value;
        magic = magicSlider.value;
        special = specialSlider.value;
        ShowStatPoints(attackSlider, attackDisplay);
        ShowStatPoints(defenseSlider, defenseDisplay);
        ShowStatPoints(magicSlider, magicDisplay);
        ShowStatPoints(specialSlider, specialDisplay);
    }

    private void Update()
    {
        currentStatPoints = attack + defense + magic + special;
        statPointsLeftDisplay.text = (totalStatPoints - currentStatPoints).ToString();
    }

    public void Attack()
    {
        if (currentStatPoints < totalStatPoints)
            attack = attackSlider.value;
        else
            attackSlider.value = attack;
        ShowStatPoints(attackSlider, attackDisplay);
    }

    public void Defense()
    {
        if (currentStatPoints < totalStatPoints)
            defense = defenseSlider.value;
        else
            defenseSlider.value = defense;
        ShowStatPoints(defenseSlider, defenseDisplay);
    }

    public void Magic()
    {
        if (currentStatPoints < totalStatPoints)
            magic = magicSlider.value;
        else
            magicSlider.value = magic;
        ShowStatPoints(magicSlider, magicDisplay);
        
    }

    public void Special()
    {
        if (currentStatPoints < totalStatPoints)
            special = specialSlider.value;
        else
            specialSlider.value = special;
        ShowStatPoints(specialSlider, specialDisplay);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ShowStatPoints(Slider slider, TextMeshProUGUI textBox)
    {
        textBox.text = slider.value.ToString();
        hpDisplay.text = defense.ToString();
        mpDisplay.text = (magic + 1).ToString();
    }

    public Stats GetBaseStats()
    {
        Stats stats = new Stats();

        stats.UpdateStats("attack", (int)attackSlider.value);
        stats.UpdateStats("defense", (int)defenseSlider.value);
        stats.UpdateStats("magic", (int)magicSlider.value);
        stats.UpdateStats("special", (int)specialSlider.value);
        stats.UpdateStats("xp", 0);
        stats.UpdateStats("level", (Mathf.FloorToInt(50 + Mathf.Sqrt(625 + 100 + stats.GetStats("xp"))) / 100));
        stats.UpdateStats("hp", stats.GetStats("defense") + (2 * stats.GetStats("level")));
        stats.UpdateStats("mp", stats.GetStats("magic") + (2 * stats.GetStats("level")) + 1);

        Debug.Log($"testing {stats.GetStats("attack")}");

        return stats;
    }
}
