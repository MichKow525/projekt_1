using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit2 : MonoBehaviour
{
    movement playerPosData;
    public GameObject pauseMenu2;
    public GameObject pauseButton2;
    private float scena;
    
    //pause menu i zapisywanie danych przy wyjœciu do menu g³ównego
    public void Pause2()
    {   pauseButton2.SetActive(false);
        pauseMenu2.SetActive(true);
        Time.timeScale = 0f;

    }
    public void Resume2()
    {    pauseButton2.SetActive(true);
        pauseMenu2.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Start2  ()
    {
        playerPosData = FindObjectOfType<movement>();
    }

    public void quit2()
    {
     PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.SetFloat("scena1",2);
        Time.timeScale = 1f;
        PlayerPrefs.Save();
        playerPosData.PlayerPosSave();
        SceneManager.LoadScene(0);
    }
}