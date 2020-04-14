using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ConfirmationPage : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI jobText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI StrText;
    public TextMeshProUGUI IntText;
    public TextMeshProUGUI weaponDisplay;
    PlayerStats player;
    // Start is called before the first frame update
    void Start()
    {
        player = new PlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
        player = new PlayerStats();
        nameText.text = player.GetName();
        jobText.text = player.GetClass();
        hpText.text = player.GetMaxHealth().ToString();
        StrText.text = player.GetStr().ToString();
        IntText.text = player.GetInt().ToString();
        weaponDisplay.text = player.GetEquippedWeapon().GetWeaponName();
    }
}
