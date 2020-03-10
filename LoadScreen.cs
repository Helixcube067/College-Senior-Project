using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadScreen : MonoBehaviour
{
    PlayerStats player;
    public TextMeshProUGUI mainLevel;
    public TextMeshProUGUI mcName;
    public TextMeshProUGUI mcClass;
    // Start is called before the first frame update
    void Start()
    {
        player = new PlayerStats();
        player.LoadPlayer();
        //these two are for the main characters stats
        mcName.text = player.GetName();
        mainLevel.text = player.GetLevel().ToString();
        mcClass.text = player.GetClass();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

