using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests 
{
    public List<QuestEvent> questEvents = new List<QuestEvent>();

    public Quests() {}

    public QuestEvent AddQuestEvent(string name, string desc)
    {
        QuestEvent questEvent = new QuestEvent(name, desc);
        questEvents.Add(questEvent);
        return questEvent;
    }

    public void AddPath(string fromEvent, string toEvent) 
    {
        QuestEvent from = FindQuestEvent(fromEvent);
        QuestEvent to = FindQuestEvent(toEvent);

        if (from != null && to != null)
        {
            QuestPath p = new QuestPath(from, to);
            from.pathlist.Add(p);
        }
    }

    QuestEvent FindQuestEvent(string id)
    {
        foreach (QuestEvent n in questEvents)
        {
            if (n.GetID() == id)
            {
                return n;
            }
        }

        return null;
    }

    public void OrderEvents(string id, int orderNumber = 1)
    {
        // Orders events in a quest using a breadth-first algorithm

        QuestEvent thisEvent = FindQuestEvent(id);
        thisEvent.order = orderNumber;

        foreach(QuestPath qp in thisEvent.pathlist)
        {
            if (qp.endEvent.order == -1)
            {
                OrderEvents(qp.endEvent.GetID(), orderNumber +1);
            }
        }
    }

    public void PrintPath()
    {
        foreach (QuestEvent n in questEvents)
        {
            Debug.Log(n.questName + " " + n.order);
        }
    }
}
