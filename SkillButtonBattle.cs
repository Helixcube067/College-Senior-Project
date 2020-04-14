using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillButtonBattle : MonoBehaviour
{
    public TextMeshProUGUI floatingText;
    public GameObject floatingTextRefence;

    public void FloatingText()
    {
        Vector3 positional;
        switch (PlayerStats.classInfo) {

            case "Mage":
                positional = new Vector3(this.gameObject.transform.position.x, (this.gameObject.transform.position.y) + 3.0f, this.gameObject.transform.position.z);
                floatingTextRefence.gameObject.transform.position = positional;
                floatingText.text = "Unleash a power magical attack";
                floatingTextRefence.SetActive(true);
                break;
            case "Soldier":
                positional = new Vector3(this.gameObject.transform.position.x, (this.gameObject.transform.position.y) + 3.0f, this.gameObject.transform.position.z);
                positional.y += 3.0f;
                floatingTextRefence.gameObject.transform.position = positional;
                floatingText.text = "Use first aid to heal yourself";
                floatingTextRefence.SetActive(true);
                break;
            case "Thief":
                positional = new Vector3(this.gameObject.transform.position.x, (this.gameObject.transform.position.y) + 3.0f, this.gameObject.transform.position.z);
                floatingTextRefence.gameObject.transform.position = positional;
                floatingTextRefence.SetActive(true);
                floatingText.text = "Use your stealth for a sneak attack";
                break;
        }
    }

    public void RemoveFloatingText()
    {
        floatingTextRefence.SetActive(false);
    }
}
