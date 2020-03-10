using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestObjective
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;
    public bool completed;
    [System.NonSerialized]
    public GameObject reporter;
    public string reporterName;

    public QuestObjective(string talkTo) {
        completed = false;
        this.reporter = GameObject.Find(talkTo);
        reporterName = talkTo;
        goalType = GoalType.ReportTo;
    }

    public QuestObjective(int newRequiredAmount, GoalType newGoalType) {
        this.currentAmount = 0;
        this.requiredAmount = newRequiredAmount;
        if (requiredAmount == 0)
            requiredAmount = 1;
        this.goalType = newGoalType;
    }

    public void ObjectAchieved() {
        if(goalType == GoalType.Kill)
            currentAmount++;
        if (goalType == GoalType.ReportTo)
            completed = true;
        if (goalType == GoalType.Gathering)
            currentAmount++;
    }
    public bool IsReached() {
        return (currentAmount >= requiredAmount);
    }

    public bool CompletedQuest() {
        return completed;
    }


}

public enum GoalType {
    Kill, Gathering, ReportTo
}
