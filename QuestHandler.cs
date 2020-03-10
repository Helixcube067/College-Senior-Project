using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestHandler : MonoBehaviour
{
    /* This class handles the quest management.
     * Look at the comments above each function to see what they do
     * 
     */ 
    private Quests quest;
    public TextMeshProUGUI questName;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI expReward;
    public TextMeshProUGUI goldReward;
    public GameObject questWindow;

    /* This takes an object argument and then checks to see if it:
     * 1.) missionList position isnt null
     * 2.) if the quest is active and the goalType is also reportTo
     * 3.) the object to talk to is also the argument object
     * Calls finishedQuest if it is completed
     */ 
    public void ReportedQuestComplete(GameObject finisher)
    {
         for (int i = 0; i < PlayerStats.missionList.Count; i++)
        {
            if (PlayerStats.missionList[i] != null)
            {
                if (PlayerStats.missionList[i].GetQuestObjective().goalType == GoalType.ReportTo && PlayerStats.missionList[i].GetStatus() == true)
                {
                    //Debug.Log(finisher);
                    //Debug.Log(PlayerStats.missionList[i].GetQuestObjective().reporter == finisher.gameObject);
                    if (PlayerStats.missionList[i].GetQuestObjective().reporter.name.Equals(finisher.gameObject.name))
                    {
                        PlayerStats.missionList[i].FinishedQuest();
                    }
                }
            }
        }
    }

    //Opens the quest window with updated info
    public void OpenQuestWindow()
    {
        //QuestGiver uiUpdater = this.gameObject.GetComponent<QuestGiver>();
        questWindow.SetActive(true);
        questName.text = quest.quest.name;
        objectiveText.text = quest.quest.description;
        expReward.text = "Exp: " + quest.quest.expReward.ToString();
        goldReward.text = "Gold: " + quest.quest.goldReward.ToString();
    }

    public void SetQuest(Quests quest) {
        this.quest = quest;
    }

    public Quests GetQuest() {
        return quest;
    }
}
