using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private SceneMovement sceneMovement;
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }    
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Pause(GameObject referencedObject)
    {
        referencedObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Resume(GameObject referencedObject)
    {
        referencedObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
    }

    //this function has to have different functionalty later on
    //this function will take you to the load screen
    public void QuittingGame()
    {

        Debug.Log("Quitting game...");
        PauseMenuUI.SetActive(false);
        sceneMovement.LoadLevel("Title screen");
        Time.timeScale = 1f;
    }
}
