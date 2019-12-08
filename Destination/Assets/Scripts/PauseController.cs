using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {
    public string mainMenuScene;//not set up yet TODO
    public GameObject pauseMenu;
    public Controller control;
    public bool isPaused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isPaused)
            {
                ReturnToMain();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isPaused)
            {
                ResetScene();
            }
        }
	}

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ResetScene()
    {
        ResumeGame();
        control.ResetScene();
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }
}
