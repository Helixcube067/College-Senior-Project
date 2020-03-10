using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //simple class used to have a name of who's speaking and an array of string to have sentences
    public string name;

    [TextArea(3,10)]
    public string[] sentences;
}
