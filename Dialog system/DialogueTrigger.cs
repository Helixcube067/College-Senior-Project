using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactables
{
    /* This class is used to trigger dialogue and it finds the dialogue manager and then calls start dialogue
     * 
     * 
     */
    public Dialogue dialogue;
    public GameObject questButton;
    public QuestHandler questHandler;
    public GameObject player;

    void Update()
    {

    }

    //this mouseDown event is solely for the checking on the quest system
    /* First it calls ReportedQuestComplete which just checks to see if any quest requires talking to this object
     * Then if it has a quest it grabs the QuestGiver class and then checks to see if that quest is in the mission list or not. If so then it disables the questButton. If not then it sets the questHandler class to the quest this object has and enables the questButton.
     * Calls TriggerDialogue at the end regardless
     */
    private void OnMouseDown()
    {
        float dist = Vector3.Distance(player.transform.position, this.transform.position);
        //Debug.Log("This is distance: " + dist);
        questHandler.ReportedQuestComplete(this.gameObject);
        if (this.gameObject.GetComponent<QuestGiver>() != null) {
            bool searcher = false;
            QuestGiver updater = this.gameObject.GetComponent<QuestGiver>();
            for (int i = 0; i < PlayerStats.missionList.Count; i++)
            {
                if (PlayerStats.missionList[i].GetName().Equals(updater.quest.quest.name))
                {
                    searcher = true;
                }
            }
            if (searcher)
                questButton.SetActive(false);
            else {
                questHandler.SetQuest(updater.quest);
                questButton.SetActive(true);
            }
                
        }
        if (dist < 4.0f)
            TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
