using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    public void Attack()
    {
        attack = attackSlider.value;
        ShowStatPoints(attackSlider, attackDisplay);
    }

    public void Defense()
    {
       
        defense = defenseSlider.value;
        ShowStatPoints(defenseSlider, defenseDisplay);
    }

    public void Magic()
    {
        magic = magicSlider.value;
        ShowStatPoints(magicSlider, magicDisplay);
        
    }

    public void Special()
    {
        special = specialSlider.value;
        ShowStatPoints(specialSlider, specialDisplay);
    }

    void ShowStatPoints(Slider slider, TextMeshProUGUI textBox)
    {
        textBox.text = slider.value.ToString();
        currentStatPoints = attack + defense + magic + special;
        hpDisplay.text = defense.ToString();
        mpDisplay.text = (magic + 1).ToString();
        statPointsLeftDisplay.text = (totalStatPoints - currentStatPoints).ToString();
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
