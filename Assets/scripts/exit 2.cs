using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit2 : MonoBehaviour
{
    movement playerPosData;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    private float scena;
    
    //pause menu i zapisywanie danych przy wyjœciu do menu g³ównego
    public void Pause2()
    {   pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

    }
    public void Resume2()
    {    pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Start2  ()
    {
        playerPosData = FindObjectOfType<movement>();
    }

    public void quit2()
    {   scena = 2;
        PlayerPrefs.SetFloat("scena1", 2 );
        Time.timeScale = 1f;
        PlayerPrefs.Save();
        playerPosData.PlayerPosSave();
        SceneManager.LoadScene(0);
    }
}