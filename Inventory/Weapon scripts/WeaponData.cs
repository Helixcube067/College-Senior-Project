using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    /* This class is a template for the Weapons.cs scriptable object
     * This object is serializable and therefore it gets saved
     * 
     * This class sets the publics first and the constructor updates the privates variabbles for serialization
     * Getters return public variables which is kinda....not needed tbh
     */ 
    public string name;
    public int attackPower;
    [TextArea(2, 5)]
    public string description;

    private string weaponName;
    private string weaponDescript;
    private int weaponPwr;

    public WeaponData() {
        //name = weaponName;
        //description = weaponDescript;
        //attackPower = weaponPwr;
        weaponName = name;
        weaponDescript = description;
        weaponPwr = attackPower;
    }

    public WeaponData(string name, int attackPower, string description) {
        this.name = name;
        this.attackPower = attackPower;
        this.description = description;
        /*this.weaponName = name;
        this.weaponPwr = attackPower;
        this.weaponDescript = description;*/
    }

    public string GetWeaponName() {
        return name;
    }

    public string GetWeaponDescrpt() {
        return description;
    }

    public int GetWeaponPwr() {
        return attackPower;
    }
}
