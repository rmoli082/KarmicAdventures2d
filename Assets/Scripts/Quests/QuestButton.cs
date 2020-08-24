using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class QuestButton : MonoBehaviour
{
    public Button buttonComponent;
    public TextMeshProUGUI eventName;
    public Quest currentQuest;

    public void Setup(Quest quest, GameObject scrollList)
    {
        currentQuest = quest;
        buttonComponent.transform.SetParent(scrollList.transform, false);
        eventName.text = "<b>" + currentQuest.questTitle + "</b>\n" + currentQuest.questDesc;
        buttonComponent.interactable = true;
    }

    public void PopupQuestPane()
    {
        GameManager.gm.data.questDetailsPane.SetActive(true);

        GameManager.gm.data.questDetailsStory.text = $"{currentQuest.questLine} Quest";
        GameManager.gm.data.questDetailsTitle.text = currentQuest.questTitle;
        GameManager.gm.data.questDetailsDesc.text = currentQuest.questDesc;

        StringBuilder rewardsText = new StringBuilder();
        rewardsText.Append("You will receive ");
        if (currentQuest.goldReward > 0)
        {
            rewardsText.Append($"{currentQuest.goldReward} gold coins\n");
        }
        if (currentQuest.itemRewards.Length > 0)
        {
            foreach (Item item in currentQuest.itemRewards)
                rewardsText.Append($"{item.itemName}");
        }

        GameManager.gm.data.questRewards.text = rewardsText.ToString();
    }
}
