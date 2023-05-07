using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class game_controler : MonoBehaviour
{
    public movement script;
    public TextMeshProUGUI textPlayerName;
    public TextMeshProUGUI textLives;
    public static string playerName;
    void Update()
    {
        UpdateLives();
    }
    void Start()
    {
        playerName = PlayerPrefs.GetString("name", playerName);
       
        UpdatePlayerName();
    }
    public void UpdateLives()
    {
        textLives.text = "" + script.lives;
    }
    public void UpdatePlayerName()
    {
        textPlayerName.text = PlayerPrefs.GetString("name", playerName);
    }

}
