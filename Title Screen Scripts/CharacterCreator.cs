using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterCreator : MonoBehaviour
{
    /* this class is used on the main menu when creating a new character. 
     * the region UIUpdaters has functions that update the UI based on choices made by the player.
     * Start and update methods are used to help update the UI on the correct frame
     * TODO: send information to th static class that has the player stast and information
     */
    public TMP_InputField nameField;
    public TMP_Dropdown classPick;
    public TextMeshProUGUI JobInfo;
    private string characterName;
    private int jobSelection;
    private string jobPick;
    public Weapons thiefWeapon;
    public Weapons mageWeapon;
    public Weapons soldierWeapon;
    PlayerStats player;
    public GameObject continueButton;

    void Start()
    {
        player = new PlayerStats();
        classPick = GetComponentInChildren<TMP_Dropdown>();
        classPick.onValueChanged.AddListener(delegate { JobDescripChanger(classPick); });
        jobSelection = classPick.value;
        jobPick = classPick.options[jobSelection].text;
        JobDescripChanger(classPick);
    }

    void FixedUpdate()
    {
        characterName = nameField.text;
        jobSelection = classPick.value;
        jobPick = classPick.options[jobSelection].text;
        JobDescripChanger(classPick);
       // Debug.Log(jobPick);
    }

    public void Submit()
    {
        switch (jobSelection)
        {
            case 1:
                //thief creator
                player.Creation(jobPick, characterName, 40, 30, 0, thiefWeapon);
                break;
            case 2:
                //soldier creatotr
                //Creation(string job, string incomingName, int startHealth, int strength, int magic, /*Weapon weapon*/)
                player.Creation(jobPick, characterName, 50, 30, 5, soldierWeapon);
                break;
            case 3:
                //mage creator
                player.Creation(jobPick, characterName, 40, 5, 20, mageWeapon);
                break;
        }
    }

    #region UIUpdater
    public void JobDescripChanger(TMP_Dropdown newChange)
    {
        switch (jobSelection)
        {
            case 1:
                JobInfo.text = "Quick but squishy";
                if (!(string.IsNullOrEmpty(nameField.text)))
                    if (!(string.IsNullOrWhiteSpace(nameField.text)))
                        continueButton.SetActive(true);
                break;
            case 2:
                JobInfo.text = "Sturdy enough";
                if (!(string.IsNullOrEmpty(nameField.text)))
                    if (!(string.IsNullOrWhiteSpace(nameField.text)))
                        continueButton.SetActive(true);
                break;
            case 3:
                characterName = nameField.text;
                JobInfo.text = "You're a wizard " + characterName;
                if (!(string.IsNullOrEmpty(nameField.text)))
                    if(!(string.IsNullOrWhiteSpace(nameField.text)))
                        continueButton.SetActive(true);
                break;
            default:
                JobInfo.text = "Job info here";
                if (string.IsNullOrEmpty(nameField.text))
                    if((string.IsNullOrWhiteSpace(nameField.text)))
                        continueButton.SetActive(false);
                break;
        }
    }
    #endregion
}
 