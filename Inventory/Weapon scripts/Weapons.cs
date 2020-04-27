using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Equipment/Weapon")]
public class Weapons : ScriptableObject
{
    /* Scriptable object to make a bunch of different weapons
     * This calls the WeaponData script because this does not want to be serialized
     * 
     */
    public WeaponData weapon = new WeaponData();
}
