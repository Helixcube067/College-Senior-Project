using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArmorData
{
    private string name;
    private int defensePower;
    private string description;

    public string armorName;
    public int armorDef;
    [TextArea(2,5)]
    public string armorDescript;

    public ArmorData(string incomingName, int incomingDef, string incomingDescript)
    {
        this.name = incomingName;
        this.defensePower = incomingDef;
        this.description = incomingDescript;
    }

    public ArmorData()
    {
        this.armorName = name;
        this.armorDef = defensePower;
        this.armorDescript = description;
        /*this.name = armorName;
        this.defensePower = armorDef;
        this.description = armorDescript;*/
    }
    #region getters
    public int GetArmorDef()
    {
        return defensePower;
    }

    public string GetArmorDescrpt()
    {
        return description;
    }

    public string GetArmorName()
    {
        return name;
    }
    #endregion
    #region setters
    public void SetArmorName(string newName)
    {
        name = newName;
    }

    public void SetArmorDescript(string newDescript)
    {
        description = newDescript;
    }

    public void SetArmorDef(int newDef)
    {
        defensePower = newDef;
    }

    #endregion 
}
