using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    /* This class is meant for all interactables to derive from.
     * May or may not get destroyed later on
     * 
     */ 
    public GameObject pauseMenu;
    public GameObject dialogMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnMouseEnter()
    {
       if (pauseMenu.activeInHierarchy == false && dialogMenu.activeInHierarchy == false)
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    private void OnMouseExit()
    {
        if (pauseMenu.activeInHierarchy == false && dialogMenu.activeInHierarchy == false)
            GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

    private void OnMouseDown()
    {
        if (pauseMenu.activeInHierarchy == false && dialogMenu.activeInHierarchy == false)
            GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    private void OnMouseUp()
    {
        if (pauseMenu.activeInHierarchy == false && dialogMenu.activeInHierarchy == false)
            GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }*/
}
