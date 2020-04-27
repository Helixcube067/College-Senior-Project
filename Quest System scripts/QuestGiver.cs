using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    /* only has one function (AcceptedQuest()) which first deactivates the questWindow and questButton. It then calls questHandler.GetQuest() to get the most recent quest information
     * Checks then to see the goal type is and if its ReportTo:
     * it makes a QuestObjective and uses the reportTo to set who you should talk to to complete it
     * Then it calls the QuestData constructor to make a new quest
     * A loop is then called to check if a quest with the same name is within the missionList already or not. 
     * If it is then it prints "You already have this" and then returns
     * 
     * Does the same for a non ReportTo quest type but calls a different QuestObjective constructor
     * 
     * NOTE: the check to see if it is within the missionist might be unneccessary due to the checking during DialogueTrigger
     */ 
    public GameObject reportTo;
    public GameObject questButton;
    public QuestHandler questHandler;
    public GameObject questWindow;
    public Quests quest;

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        questButton.SetActive(false);
        quest = questHandler.GetQuest();
        
        if (quest.quest.GetQuestObjective().goalType == GoalType.ReportTo)
        {
            quest.quest.GetQuestObjective().reporter = GameObject.Find(quest.quest.GetQuestObjective().reporterName);
            Debug.Log("Report to: " + quest.quest.GetQuestObjective().reporter.name);
            QuestObjective objective = new QuestObjective(quest.quest.GetQuestObjective().reporter.name);
            QuestData acceptedQuest = new QuestData(quest.quest.name, quest.quest.description, quest.quest.expReward, quest.quest.goldReward, true, objective);
            for (int i = 0; i < PlayerStats.missionList.Count; i++)
            {
                if (PlayerStats.missionList[i].GetName().Equals(acceptedQuest.GetName()))
                {
                    Debug.Log("You already have this quest");
                    Debug.Log(PlayerStats.missionList.Count);
                    return;
                }
            }
            PlayerStats.missionList.Add(acceptedQuest);
            return;
        }
        QuestObjective objective2 = new QuestObjective(quest.quest.GetQuestObjective().requiredAmount, quest.quest.GetQuestObjective().goalType);
        QuestData acceptedQuest2 = new QuestData(quest.quest.name, quest.quest.description, quest.quest.expReward, quest.quest.goldReward, true, objective2);
        for(int i = 0; i < PlayerStats.missionList.Count; i++)
        {
            if (PlayerStats.missionList[i].GetName().Equals(acceptedQuest2.name)) {
                Debug.Log("You already have this quest");
                Debug.Log(PlayerStats.missionList.Count);
                return;
            }
        }
        PlayerStats.missionList.Add(acceptedQuest2);
    }
}
