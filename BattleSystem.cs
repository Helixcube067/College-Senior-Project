using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public GameObject player;
    public GameObject enemy;
    public Transform playerSpot;
    public Transform enemySpot;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupBattle()
    {
        Instantiate(player, playerSpot);
        Instantiate(enemy, enemySpot);
    }
}
