using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    #region battle handling
    private Interaction interaction;
    public BattleState state;
    public GameObject enemy;
    public Transform enemySpot;
    public TMP_Text mainNameText;
    public TMP_Text mainHPText;
    public TMP_Text mainMPText;
    PlayerStats player;
    public static Monster enemyUnit;
    public TMP_Text statusUpdate;
    [SerializeField]
    SceneMovement sceneMover;
    #endregion
    #region level up info
    public GameObject levelupPanel;
    public GameObject battlePanel;
    public TextMeshProUGUI levelNameText;
    public TextMeshProUGUI levelStrText;
    public TextMeshProUGUI levelIntText;
    public TextMeshProUGUI levelText;
    #endregion
    //public BattleHUD enemyHUD
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        player = new PlayerStats();
        //player.LoadPlayer();
        StartCoroutine(SetupBattle());
    }

    // Update is called once per frame
    void Update()
    {
        mainNameText.text = PlayerStats.playerName;
        mainHPText.text = "HP: " + PlayerStats.currHealth + "/" + PlayerStats.maxHealth;
        mainMPText.text = "MP: " + PlayerStats.currMP + "/" + PlayerStats.maxMP;
        //hpSlider.value = unit.currentHP;
    }

    IEnumerator SetupBattle()
    {
        Image enePic = enemy.GetComponent<Image>();
        enePic.sprite = enemyUnit.monsterPic;
        Debug.Log("Monster name: " + enemyUnit.name);
        Debug.Log("Monster description: " + enemyUnit.description);
        
        statusUpdate.text = "A wild level " + enemyUnit.level + " " + enemyUnit.name + " has appeared";
        //enemyHUD.SetHUD(enemyUnit)
        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
        
    }

    void PlayerTurn() {
        statusUpdate.text = "Choose an action";
    }

    #region forget this for now
    /*void SetHP(int newValue) {
        hpSlider.value = PlayerStats.currHealth;
    }*/

    /*public void SetHUD(Monster monster) {
        //basically do UI updating here
    }*/
    #endregion

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        else
            StartCoroutine(PlayerAttack());
    }

    public void OnSkillButton() {
        if (state != BattleState.PLAYERTURN)
            return;
        else
            StartCoroutine(PlayerSkill());
    }
    IEnumerator PlayerSkill()
    {
        int damage;
        bool isDead;

        switch (player.GetClass()) {
            case "Mage":
                if (PlayerStats.currMP >= 10) {
                    statusUpdate.text = "You unleash a giant discharge of magical energy";
                    int magicAmp =  (int)(PlayerStats.magicPwr * 1.5);
                    damage = enemyUnit.TakeDamage(magicAmp);
                    isDead = enemyUnit.StatusCheck();
                    yield return new WaitForSeconds(2f);
                    statusUpdate.text = "You did " + damage + " damage";
                    PlayerStats.currMP -= 10;
                    if (PlayerStats.currMP < 0)
                        PlayerStats.currMP = 0;
                    yield return new WaitForSeconds(2f);
                    if (isDead)
                    {
                        state = BattleState.WON;
                        StartCoroutine(EndBattle());
                    }

                    else
                    {
                        state = BattleState.ENEMYTURN;
                        StartCoroutine(EnemyTurn());
                    }
                }
                else
                {
                    statusUpdate.text = "You don't have enough MP for a skill";
                    yield return new WaitForSeconds(1f);
                }
                break;
            case "Soldier":
                if (PlayerStats.currMP >= 5)
                {
                    statusUpdate.text = "You use first aid to patch yourself up";
                    yield return new WaitForSeconds(2f);
                    PlayerStats.currHealth += 15;
                    if (PlayerStats.currHealth > PlayerStats.maxHealth)
                        PlayerStats.currHealth = PlayerStats.maxHealth;
                    statusUpdate.text = "You heal for " + 15;
                    PlayerStats.currMP -= 5;
                    if (PlayerStats.currMP < 0)
                        PlayerStats.currMP = 0;
                    yield return new WaitForSeconds(2f);
                    state = BattleState.ENEMYTURN;
                    StartCoroutine(EnemyTurn());
                }
                else{
                    statusUpdate.text = "You don't have enough MP for a skill";
                    yield return new WaitForSeconds(1f);
                }
                break;
            case "Thief":
                if (PlayerStats.currMP >= 10)
                {
                    statusUpdate.text = "You manage to sneak attack your opponent";
                    damage = enemyUnit.TakeDamage(PlayerStats.weapon.attackPower * PlayerStats.attackPwr);
                    isDead = enemyUnit.StatusCheck();
                    yield return new WaitForSeconds(2f);
                    statusUpdate.text = "You did " + damage + " damage";
                    PlayerStats.currMP -= 10;
                    if (PlayerStats.currMP < 0)
                        PlayerStats.currMP = 0;
                    yield return new WaitForSeconds(2f);
                    if (isDead)
                    {
                        state = BattleState.WON;
                        StartCoroutine(EndBattle());
                    }

                    else
                    {
                        state = BattleState.ENEMYTURN;
                        StartCoroutine(EnemyTurn());
                    }
                }
                else
                {
                    statusUpdate.text = "You don't have enough MP for a skill";
                    yield return new WaitForSeconds(1f);
                }
                break;
        }
    }
    IEnumerator PlayerAttack() {
        bool isDead;
        int damage;
        if (string.Equals(PlayerStats.classInfo, "Mage")) {
            damage = enemyUnit.TakeDamage(PlayerStats.magicPwr);
            enemyUnit.health -= damage;
            statusUpdate.text = "You did " + damage + " damage";
            isDead = enemyUnit.StatusCheck();
        }
        else
        {
            damage = enemyUnit.TakeDamage(PlayerStats.attackPwr);
            statusUpdate.text = "You did " + damage + " damage";
            isDead = enemyUnit.StatusCheck();
        }
            
        //enemyHUD.SetHP(enemyUnit.currentHP);
        
        yield return new WaitForSeconds(2f);
        if (isDead) {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
        }

        else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EndBattle() {
        if (state == BattleState.WON)
        {
            statusUpdate.text = "You won!";
            PlayerStats.gold += enemyUnit.gold;
            PlayerStats.exp += enemyUnit.exp;
            yield return new WaitForSeconds(2f);
            if (PlayerStats.exp >= 100)
                InitiateLevelUp();
            else
                sceneMover.LoadLevel("Overword");
        }

        else if (state == BattleState.LOST)
        {
            statusUpdate.text = "You died...";
            yield return new WaitForSeconds(2f);
            sceneMover.LoadLevel("Title screen");
        }  
    }

    IEnumerator EnemyTurn() {
        bool playerDeath;
        int decision = Random.Range(0, 4);
        if (decision >= 2)
        {
            statusUpdate.text = enemyUnit.name + " is attacking!";
            
            yield return new WaitForSeconds(2f);
            int dmg = player.TakeDamage(enemyUnit.atk);
            statusUpdate.text = "You took " + dmg + " damage";
            playerDeath = player.AliveCheck();

        }
        else {
            statusUpdate.text = enemyUnit.goofer;
            playerDeath = false;
        }

        yield return new WaitForSeconds(1f);
        if (playerDeath)
        {
            state = BattleState.LOST;
            StartCoroutine(EndBattle());
        }
        else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }

    void InitiateLevelUp() {
        int preSTR = player.GetStr();
        int preInt = player.GetInt();
        int preLevel = player.GetLevel();
        battlePanel.SetActive(false);
        levelupPanel.SetActive(true);
        player.LevelUp();
        levelNameText.text = PlayerStats.playerName;
        levelStrText.text = "Str: " + preSTR + " -> " + PlayerStats.attackPwr;
        levelIntText.text = "Int: " + preInt + " -> " + PlayerStats.magicPwr;
        levelText.text = "Lvl: " + preLevel + " -> " + PlayerStats.level;
    }
}
