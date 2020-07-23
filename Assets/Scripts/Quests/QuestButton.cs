using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    public Button buttonComponent;
    public RawImage icon;
    public Text eventName;
    public Sprite currentImage;
    public Sprite waitingImage;
    public Sprite doneImage;
    public QuestEvent thisEvent;

    QuestEvent.EventStatus status;

    public void Setup(QuestEvent questEvent, GameObject scrollList)
    {
        thisEvent = questEvent;
        buttonComponent.transform.SetParent(scrollList.transform, false);
        eventName.text = "<b>" + thisEvent.questName + "</b>\n" + thisEvent.description;
        status = thisEvent.status;
        icon.texture = waitingImage.texture;
        buttonComponent.interactable = false;
    }

    public void UpdateButton(QuestEvent.EventStatus s)
    {
        status = s;
        buttonComponent.interactable = false;
        switch (status)
        {
            case QuestEvent.EventStatus.DONE:
                icon.texture = doneImage.texture;
                break;
            case QuestEvent.EventStatus.WAITING:
                icon.texture = waitingImage.texture;
                break;
            case QuestEvent.EventStatus.CURRENT:
                icon.texture = currentImage.texture;
                buttonComponent.interactable = true;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
