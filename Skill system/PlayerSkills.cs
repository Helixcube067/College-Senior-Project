using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSkills
{
    public enum StatUsed
    {
        Int, Str, Mana, Health, None
    }
    public enum SkillType
    {
        Passive, Heal, Attack, Other
    }

    public enum Resource {
        Hp, Mp, None
    }

    public string name;
    public StatUsed statUsed;
    public SkillType skillType;
    public Resource resourceType;
    public float skillEffect;
    [TextArea(2,5)]
    public string description;
    [TextArea(2, 5)]
    public string actionDescription;
    public int skillPointCost;
    public float resourceCost;

    private string namePRI;
    private StatUsed statUsedPRI;
    private SkillType skillTypePRI;
    private Resource resourceTypePRI;
    private float effectPRI;
    private string descriptPRi;
    private int skillPointCostPRI;
    private float resourceCostPRI;
    private string actionDescriptionPRI;

    public PlayerSkills() {
        /*namePRI = name;
        statUsedPRI = statUsed;
        skillTypePRI = skillType;
        effectPRI = skillEffect;
        descriptPRi = description;*/
        name = namePRI;
        statUsed = statUsedPRI;
        skillType = skillTypePRI;
        skillEffect = effectPRI;
        description = descriptPRi;
        skillPointCost = skillPointCostPRI;
        actionDescription = actionDescriptionPRI;
        resourceCost = resourceCostPRI;
        resourceType = resourceTypePRI;
    }

    public PlayerSkills(string name, StatUsed statUsed, SkillType skillType, Resource resource,float effect, string Descript, int skillPointCost, float resourceCost, string actionDescript) {
        namePRI = name;
        statUsedPRI = statUsed;
        effectPRI = effect;
        descriptPRi = description;
        skillTypePRI = skillType;
        skillPointCostPRI = skillPointCost;
        resourceTypePRI = resource;
        resourceCostPRI = resourceCost;
        actionDescriptionPRI = actionDescript;
    }
}
