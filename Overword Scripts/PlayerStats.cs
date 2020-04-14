using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    /* This class has a WHOLE lot going on. It has static variables to update the private variables as well as the saving and reloading for the playerstats
     * 
     * 
     */
    #region static helper variables
    public static string classInfo;
    public static string playerName;
    public static int maxHealth;
    public static int currHealth;
    public static int maxMP;
    public static int currMP;
    public static WeaponData weapon;
    public static int attackPwr;
    public static int level;
    public static int magicPwr;
    public static string gps;
    public static string weaponNameSTA;
    public static List<QuestData> missionList;
    public static int exp;
    public static int gold;
    #endregion

    #region serialized variables
    [SerializeField]
    private string name;
    [SerializeField]
    private string currClass;
    [SerializeField]
    private int currMaxHealth;
    [SerializeField]
    private int currHP;
    [SerializeField]
    private int currMaxMP;
    [SerializeField]
    private int currMagP;
    [SerializeField]
    private WeaponData currWeapon;
    [SerializeField]
    private int currAtkPwr;
    [SerializeField]
    private int currMagicPwer;
    [SerializeField]
    private int currLevel;
    [SerializeField]
    private string location;
    [SerializeField]
    private List<QuestData> questList;
    [SerializeField]
    private int currExp;
    [SerializeField]
    private int currGold;
    #endregion

    /* This constructor calls the static variables to re-update the private variables to be serialized
     */
    public PlayerStats() {
        currClass = classInfo;
        name = playerName;
        currMaxHealth = maxHealth;
        currHP = currHealth;
        currMaxMP = maxMP;
        currMagP = currMP;
        currWeapon = weapon;
        currAtkPwr = attackPwr;
        currMagicPwer = magicPwr;
        currLevel = level;
        location = gps;
        questList = missionList;
        currExp = exp;
        currGold = gold;
    }

    //this function adds values to the static variables initially
    public void Creation(string job, string incomingName, int startHealth, int strength, int magic, Weapons starterWeapon)
    {
        classInfo = job;
        playerName = incomingName;
        maxHealth = startHealth;
        attackPwr = strength;
        magicPwr = magic;
        weapon = new WeaponData(starterWeapon.weapon.GetWeaponName(), starterWeapon.weapon.GetWeaponPwr(), starterWeapon.weapon.GetWeaponDescrpt());
        currHealth = startHealth;
        exp = 0;
        gold = 0;
        maxMP = 20;
        currMP = 20;
        level = 1;
        missionList = new List<QuestData>();
        gps = "Overword";
    }

    #region getters
    public int GetLevel() {
        return currLevel;
    }

    public string GetClass() {
        return currClass;
    }

    public string GetName() {
        return name;
    }

    public int GetCurrHealth() {
        return currHP;
    }

    public int GetCurrMP() {
        return currMagP;
    }

    public int GetMaxHealth() {
        return currMaxHealth;
    }

    public int GetMaxMP() {
        return currMaxMP;
    }

    public int GetStr() {
        return currAtkPwr;
    }

    public int GetInt() {
        return currMagicPwer;
    }

    public WeaponData GetEquippedWeapon() {
        return currWeapon;
    }

    public string GetLocation() {
        return location;
    }

    public List<QuestData> GetQuestList() {
        return questList;
    }

    public int GetExp(){
        return currExp;
    }

    public int GetGold() {
        return currGold;
    }
    #endregion

    #region setters
    public void SetLevel(int newLevel) {
        currLevel = newLevel;
    }

    public void SetClass(string newClass) {
        currClass = newClass;
    }

    public void SetName(string newName) {
        name = newName;
    }

    public void EquipWeapon(WeaponData newWeapon) {
        currWeapon = newWeapon;
    }

    public void SetLocation(string newPlace) {
        location = newPlace;
    }

    public void GainExp(int expGain) {
        exp += expGain;
    }

    public void GainGold(int goldGain) {
        gold += goldGain;
    }
    #endregion

    #region data management
    public void SavePlayer()
    {
        Debug.Log("We savin bois");
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerStats loadedPlayer = SaveSystem.LoadPlayer();
        #region private variable setters
        currClass = loadedPlayer.GetClass();
        name = loadedPlayer.GetName();
        currMaxHealth = loadedPlayer.GetMaxHealth();
        currMaxMP = loadedPlayer.GetMaxMP();
        currHP = loadedPlayer.GetCurrHealth();
        currMP = loadedPlayer.GetCurrMP();
        currAtkPwr = loadedPlayer.GetStr();
        currMagicPwer = loadedPlayer.GetInt();
        currLevel = loadedPlayer.GetLevel();
        location = loadedPlayer.GetLocation();
        currWeapon = loadedPlayer.GetEquippedWeapon();
        currGold = loadedPlayer.GetGold();
        currExp = loadedPlayer.GetExp();
        Debug.Log("We loaded verything");
        Debug.Log("Character info: " + loadedPlayer.GetName() + " " + loadedPlayer.GetClass() + " " + loadedPlayer.GetLevel());
        Debug.Log("Weapon info: " + loadedPlayer.GetEquippedWeapon().GetWeaponName() + " " + loadedPlayer.GetEquippedWeapon().GetWeaponDescrpt() + " " + loadedPlayer.GetEquippedWeapon().GetWeaponPwr());
        Debug.Log("Exp: " + loadedPlayer.GetExp());
        Debug.Log("Gold: " + loadedPlayer.GetGold());
        #endregion

        #region static variable resetters
        classInfo = loadedPlayer.GetClass();
        playerName = loadedPlayer.GetName();
        maxHealth = loadedPlayer.GetMaxHealth();
        currHealth = loadedPlayer.GetCurrHealth();
        maxMP = loadedPlayer.GetMaxMP();
        currMP = loadedPlayer.GetCurrMP();
        attackPwr = loadedPlayer.GetStr();
        level = loadedPlayer.GetLevel();
        magicPwr = loadedPlayer.GetInt();
        gps = loadedPlayer.GetLocation();
        weapon = loadedPlayer.GetEquippedWeapon();
        missionList = loadedPlayer.GetQuestList();
        exp = loadedPlayer.GetExp();
        gold = loadedPlayer.GetGold();

        for (int i = 0; i < missionList.Count; i++) {
            if(missionList[i].GetQuestObjective().goalType == GoalType.ReportTo)
                missionList[i].GetQuestObjective().reporter = GameObject.Find(missionList[i].GetQuestObjective().reporterName);
        }
        questList = missionList;
        #endregion
    }
    #endregion

    public int TakeDamage(int dmg)
    {
        //int damage = dmg - def;
        currHealth -= dmg;
        //returning damage because will calculate armor stuff possibly later
        return dmg;
    }

    public bool AliveCheck()
    {
        if (currHealth <= 0)
            return true;
        else
            return false;
    }
}
