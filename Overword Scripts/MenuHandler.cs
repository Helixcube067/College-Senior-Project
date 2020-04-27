using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class just mass handles the UI for the overword scene through updates
/// </summary>
public class MenuHandler : MonoBehaviour
{
    #region Party menu UI
    public TextMeshProUGUI mainHP;
    public TextMeshProUGUI mainMP;
    public TextMeshProUGUI mcName;
    public TextMeshProUGUI mcClassChoice;
    #endregion

    #region individual MC UI
    public TextMeshProUGUI mcLvl;
    public TextMeshProUGUI mcExp;
    public TextMeshProUGUI mcStr;
    public TextMeshProUGUI mcInt;
    public TextMeshProUGUI mcWeapon;
    public TextMeshProUGUI mcClass;
    public TextMeshProUGUI mcNameInner;
    #endregion

    #region job references
    public Weapons mageWeapon;
    public Weapons thiefWeapon;
    public Weapons soldierWeapon;
    public GameObject soliderButton;
    public GameObject mageButton;
    public GameObject thiefButton;
    #endregion

    public TextMeshProUGUI titleSkillUpdaterText;
    PlayerStats player; 
    // Start is called before the first frame update
    void Start()
    {
        player = new PlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void StatPreview() {
        mainHP.text = "HP: " + PlayerStats.currHealth.ToString() + "/" + PlayerStats.maxHealth.ToString();
        mainMP.text = "MP: " + PlayerStats.currMP.ToString() + "/" + PlayerStats.maxMP.ToString();
        mcName.text = PlayerStats.playerName;
        mcClassChoice.text = "Class: " + PlayerStats.classInfo;
    }

    public void StatUpdater() {
        mcNameInner.text = PlayerStats.playerName;
        mcClass.text = "Class: " + PlayerStats.classInfo;
        mcLvl.text = "Level: " + PlayerStats.level.ToString();
        mcExp.text = "Exp: " + PlayerStats.exp.ToString();
        mcInt.text = "Int: " + PlayerStats.magicPwr.ToString();
        mcStr.text = "Str: " + PlayerStats.attackPwr.ToString();
        mcWeapon.text = "Weapon: " + PlayerStats.weapon.GetWeaponName();
    }

    public void SwitchToThief() {
        PlayerStats.classInfo = "Thief";
        PlayerStats.weapon = new WeaponData(thiefWeapon.weapon.GetWeaponName(), thiefWeapon.weapon.GetWeaponPwr(), thiefWeapon.weapon.GetWeaponDescrpt());
    }

    public void SwitchToSoldier()
    {
        PlayerStats.classInfo = "Soldier";
        PlayerStats.weapon = new WeaponData(soldierWeapon.weapon.GetWeaponName(), soldierWeapon.weapon.GetWeaponPwr(), soldierWeapon.weapon.GetWeaponDescrpt());
    }

    public void SwitchToMage() {
        PlayerStats.classInfo = "Mage";
        PlayerStats.weapon = new WeaponData(mageWeapon.weapon.GetWeaponName(), mageWeapon.weapon.GetWeaponPwr(), mageWeapon.weapon.GetWeaponDescrpt());
    }

    public void JobButtonClick() {
        switch (PlayerStats.classInfo) {
            case "Mage":
                mageButton.SetActive(false);
                thiefButton.SetActive(true);
                soliderButton.SetActive(true);
                break;
            case "Soldier":
                soliderButton.SetActive(false);
                mageButton.SetActive(true);
                thiefButton.SetActive(true);
                break;
            case "Thief":
                thiefButton.SetActive(false);
                soliderButton.SetActive(true);
                mageButton.SetActive(true);
                break;
        }
    }

    public void ResetTitleText() {
        mcNameInner.text = "Party";
    }

    public void SkillMenuClick() {
        titleSkillUpdaterText.text = "Skill Points: " + PlayerStats.currPoinnts;
    }

}
