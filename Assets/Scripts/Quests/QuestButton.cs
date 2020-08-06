using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    public Button buttonComponent;
    public Text eventName;
    public Quest currentQuest;

    public void Setup(Quest quest, GameObject scrollList)
    {
        currentQuest = quest;
        buttonComponent.transform.SetParent(scrollList.transform, false);
        eventName.text = "<b>" + currentQuest.questTitle + "</b>\n" + currentQuest.questDesc;
        buttonComponent.interactable = false;
    }
}
