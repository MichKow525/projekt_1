using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    movement playerPosData;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    
    //pause menu i zapisywanie danych przy wyjœciu do menu g³ównego
    public void Pause()
    {   pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

    }
    public void Resume()
    {    pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Start ()
    {
        playerPosData = FindObjectOfType<movement>();
    }

    public void quit()
    {   
        Time.timeScale = 1f;
        playerPosData.PlayerPosSave();
        SceneManager.LoadScene(0);
    }
}