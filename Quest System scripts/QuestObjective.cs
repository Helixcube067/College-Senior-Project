using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestObjective
{
    /* This is a class that is used in the QuestData constructor call to construct a new quest
     * This handles how to finish a quest and has 2 constructors
     * the first constructor takes a string only and uses that string to find a gameobject with that name to talk to later to complete it. It also sets the goalType and reporterName
     * The other constructor is for kill and gathering quests and it takes an int and goalType. The int is for the requiredAmount and the goalType is to determine which type it is
     */
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
