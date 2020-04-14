using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Equipment/Armor")]
public class Armor : ScriptableObject
{
    public ArmorData armor = new ArmorData();
}
