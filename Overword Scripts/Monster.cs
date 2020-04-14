using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : Interactables
{
    /* class for monsters and is supposed to be attached onto monsters.
     * lets their stats be determined specifically for each one which is why all of the variables are public
     * 
     */
    public new string name;
    public int level;
    public int health;
    public int atk;
    public int def;
    [TextArea(2,5)]
    public string description;
    [TextArea(2,5)]
    public string goofer;
    public Sprite monsterPic;
    public float radius = 5f;
    Transform player;
    public int gold;
    public int exp;
    //private bool isFocus;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 vector = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    public void OnFocused(Transform playerTransform)
    {
        //isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        //isFocus = false;
        player = null;
    }

    public int TakeDamage(int dmg) {
        int damage = dmg - def;
        health -= dmg;
        return damage;
    }

    public bool StatusCheck() {
        //Debug.Log(health);
        if (health <= 0)
            return true;
        else
            return false;
    }
}
