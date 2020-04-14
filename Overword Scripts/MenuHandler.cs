using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    public TextMeshProUGUI mainHP;
    public TextMeshProUGUI mainMP;
    public TextMeshProUGUI mcName;
    public TextMeshProUGUI mcClassChoice;
    PlayerStats player; 
    // Start is called before the first frame update
    void Start()
    {
        player = new PlayerStats();
        //these two are for the main characters stats
        mainHP.text = "HP: " + player.GetCurrHealth().ToString();
        mainMP.text = "MP: " + player.GetCurrMP().ToString();
        mcName.text = player.GetName();
        mcClassChoice.text = player.GetClass();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
