using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Manager : MonoBehaviour
{
   public Quests saveVillageQuest = new Quests();
   public Quests destroyCrystalQuest = new Quests();
   public Quests enterCastleQuest = new Quests();
   public Quests defeatPrinceQuest = new Quests();

   public GameObject buttonPrefab;
   public GameObject questPrintbox;

   void Start()
   {
       QuestEvent findStone = saveVillageQuest.AddQuestEvent("Locate Stone of Awakening", 
       "You must search everywhere to find a Stone of Awakening so you can bring us back to life!");
       QuestEvent findSunStone = saveVillageQuest.AddQuestEvent("Locate a Sun Stone", 
       "Find a Sun Stone so you can activate your Sun Avatar form to melt away the rock!");
       QuestEvent awakenFamily = saveVillageQuest.AddQuestEvent("Awaken the family",
       "Use the Stone of Awakening while in Sun Avatar form to bring the stone family back to life.");
       QuestEvent awakenVillage = saveVillageQuest.AddQuestEvent("Awaken the Village",
       "Find more Sun Stones to perform the awakening ritual on the rest of the villagers!");

       saveVillageQuest.AddPath(findStone.GetID(), findSunStone.GetID());
       saveVillageQuest.AddPath(findSunStone.GetID(), awakenFamily.GetID());
       saveVillageQuest.AddPath(awakenFamily.GetID(), awakenVillage.GetID());

       saveVillageQuest.OrderEvents(findStone.GetID());

       QuestEvent locateCrystal = destroyCrystalQuest.AddQuestEvent("Locate a warp crystal", 
       "Find a warp crystal to use as a focus for the ritual.");
       QuestEvent locateCircle = destroyCrystalQuest.AddQuestEvent("Find a stone circle",
       "You'll need to find a stone circle and perform the transportation ritual in it.");
       QuestEvent collectWyrmTooth = destroyCrystalQuest.AddQuestEvent("Collect a White Wyrm Tooth",
       "To destroy the crystal, you'll need to kill a white wyrm and gather his tooth!");
       QuestEvent destroyCrystal = destroyCrystalQuest.AddQuestEvent("Destroy the Blight Crystal",
       "Use the wyrm tooth to destroy the Blight Crystal and return the village plants and animals to normal!");

       destroyCrystalQuest.AddPath(locateCrystal.GetID(), locateCircle.GetID());
       destroyCrystalQuest.AddPath(locateCircle.GetID(), collectWyrmTooth.GetID());
       destroyCrystalQuest.AddPath(collectWyrmTooth.GetID(), destroyCrystal.GetID());

       destroyCrystalQuest.OrderEvents(locateCrystal.GetID());

       QuestButton button = CreateButton(findStone).GetComponent<QuestButton>();

       saveVillageQuest.PrintPath();
       destroyCrystalQuest.PrintPath();
   }

   GameObject CreateButton(QuestEvent e)
   {
       GameObject b = Instantiate(buttonPrefab);
       b.GetComponent<QuestButton>().Setup(e, questPrintbox);
       if (e.order == 1)
       {
           b.GetComponent<QuestButton>().UpdateButton(QuestEvent.EventStatus.CURRENT);
           e.status = QuestEvent.EventStatus.CURRENT;
       }
       return b;
   }

    public void UpdateQuestsOnCompletion(QuestEvent quest)
    {
        foreach (QuestEvent qe in saveVillageQuest.questEvents)
        {
            if (qe.order == (quest.order + 1))
            {
                qe.UpdateQuestEventStatus(QuestEvent.EventStatus.CURRENT);
            }
        }
    }
}
