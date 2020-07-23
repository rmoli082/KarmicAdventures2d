using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvent
{
   public enum EventStatus { WAITING, CURRENT, DONE};

   public string questName;
   public string description;
   public string id;
   public int order = -1;
   public EventStatus status;

   public List<QuestPath> pathlist = new List<QuestPath>();

   public QuestEvent(string name, string desc)
   {
       id = Guid.NewGuid().ToString();
       questName = name;
       description = desc;
       status = EventStatus.WAITING;
   }

   public void UpdateQuestEventStatus(EventStatus newStatus)
   {
       status = newStatus;
   }

   public string GetID()
   {
       return id;
   }
}
