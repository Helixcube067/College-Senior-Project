using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Skill", menuName = "Abilities/Skills")]
public class SkillTree : ScriptableObject
{
    public PlayerSkills skill = new PlayerSkills();
}
