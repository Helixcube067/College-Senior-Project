using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quests", menuName = "Quests/Quest")]
public class Quests : ScriptableObject
{
    public QuestData quest = new QuestData();
}
