using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillHelper : MonoBehaviour
{
    public SkillTree skill;
    public GameObject skillButton;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI skillText;
    public TextMeshProUGUI skillPointRequirementText;

    void Start()
    {
        descriptionText.text = "Hover over to see a skill to see the description";
        buttonText.text = skill.skill.name;
        for (int i = 0; i < PlayerStats.pskillsSta.Count; i++) {
            if (PlayerStats.pskillsSta[i].name == skill.skill.name)
                skillButton.SetActive(false);

        }     
    }

    public void UISkillUpdateText() {
        descriptionText.text = skill.skill.description;
        skillPointRequirementText.text = "Skill points required: " + skill.skill.skillPointCost;
    }

    public void UISKillResetText() {
        descriptionText.text = "Hover over to a skill to see the description";
        skillPointRequirementText.text = "Hover over a skill to see the point requirements";
    }

    public void SkillClick() {
        if (PlayerStats.currPoinnts >= skill.skill.skillPointCost)
        {
            PlayerStats.currPoinnts -= skill.skill.skillPointCost;
            PlayerStats.pskillsSta.Add(skill.skill);
            skillButton.SetActive(false);
            skillText.text = "Skill Points: " + PlayerStats.currPoinnts;
            if (skill.skill.skillType == PlayerSkills.SkillType.Passive) {
                switch (skill.skill.statUsed) {
                    case PlayerSkills.StatUsed.Int:
                        PlayerStats.magicPwr += (int)skill.skill.skillEffect;
                        break;
                    case PlayerSkills.StatUsed.Str:
                        PlayerStats.attackPwr += (int)skill.skill.skillEffect;
                        break;
                    case PlayerSkills.StatUsed.Health:
                        PlayerStats.currHealth += (int)skill.skill.skillEffect;
                        PlayerStats.maxHealth += (int)skill.skill.skillEffect;
                        break;
                    case PlayerSkills.StatUsed.Mana:
                        PlayerStats.currMP += (int)skill.skill.skillEffect;
                        PlayerStats.maxMP += (int)skill.skill.skillEffect;
                        break;
                }
            }

            descriptionText.text = "You just bought: " + skill.skill.name;
        }
        else
            descriptionText.text = "You don't have enough skill points for that...";
    }
}
