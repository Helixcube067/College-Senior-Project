using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Interactables
{
    /* class for monsters and is supposed to be attached onto monsters.
     * lets their stats be determined specifically for each one which is why all of the variables are public
     * 
     */
    public new string name;
    public float radius = 5f;
    public int health;
    public int level;
    Transform player;
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
}
