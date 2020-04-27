using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    public bool isActive;
    public string name;
    [TextArea(2,5)]
    public string description;
    public int expReward;
    public int goldReward;
    public QuestObjective goal;

    [SerializeField]
    private string questName;
    [SerializeField]
    private string questDescription;
    [SerializeField]
    private int questExpReward;
    [SerializeField]
    private int questGoldReward;
    [SerializeField]
    private bool activeDetector;
    [SerializeField]
    private QuestObjective objective;

    public QuestData() {
        /*this.questName = name;
        this.activeDetector = isActive;
        this.questDescription = description;
        this.questExpReward = expReward;
        this.questGoldReward = goldReward;
        this.objective = goal;*/
        name = questName;
        isActive = activeDetector;
        description = questDescription;
        expReward = questExpReward;
        goldReward = questGoldReward;
        goal = objective;
    }

    public QuestData(string newName, string newDescript, int newExpReward, int newGoldReward, bool activeWatch, QuestObjective newObjective) {
        this.questName = newName;
        this.questDescription = newDescript;
        this.activeDetector = activeWatch;
        this.questExpReward = newExpReward;
        this.questGoldReward = newGoldReward;
        this.objective = newObjective;
    }

    public bool GetStatus() {
        return activeDetector;
    }

    public string GetName() {
        return questName;
    }

    public string GetDescription() {
        return description;
    }

    public int GetExpReward() {
        return questExpReward;
    }

    public int GetGoldReward() {
        return questGoldReward;
    }

    public QuestObjective GetQuestObjective() {
        return objective;
    }

    public void FinishedQuest()
    {
        Debug.Log("Start exp: " + PlayerStats.exp);
        Debug.Log("Start gold: " + PlayerStats.gold);
        objective.ObjectAchieved();
        if (objective.CompletedQuest()) {
            PlayerStats.exp += questExpReward;
            PlayerStats.gold += questGoldReward;
        }
            
        this.activeDetector = false;
        Debug.Log("Post quest exp: " + PlayerStats.exp);
        Debug.Log("Post gold: " + PlayerStats.gold);
        Debug.Log(questName + " was completed!");
    }
}
