using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    SceneMovement sceneMover;
    PlayerStats player;
    /*
     *  this has the save and load player methods so that it can be saved and loaded within the game
     * 
     */ 
    void Start()
    {
        player = new PlayerStats();
        //this for for testing purposes because this can easily mess up stuff later on
        //ex: you changed something and move to the next scene but dont save the changes so it reloads the before changed information.
        //player.LoadPlayer();
    }
    public void SavePlayer()
    {
        player = new PlayerStats();
        player.SavePlayer();
        Debug.Log("We saved");
        Debug.Log("Name: " + player.GetName());
        Debug.Log("Name: " + player.GetClass());
    }

    public void LoadPlayer()
    {
        //Debug.Log("We loadin");
        player.LoadPlayer();
        Debug.Log("You were here data handleer: " + player.GetLocation());
    }
}
