using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class game_controler : MonoBehaviour
{   public float finalscore;
    public movement script;
    public killcheck lol;
    public TextMeshProUGUI textPlayerName;
    public TextMeshProUGUI textLives;
    public TextMeshProUGUI textScore;
    public static string playerName;
    void Update()
    {
        UpdateLives();
        UpdateScore();
    }
    void Start()
    {
        playerName = PlayerPrefs.GetString("name", playerName);
       finalscore = PlayerPrefs.GetFloat("killpoint") + script.score;
        UpdatePlayerName();
      
    }
    public void UpdateLives()
    {   
        textLives.text = "" + script.lives;
    }

    public void UpdateScore()
    {
        finalscore = PlayerPrefs.GetFloat("killpoint")+ script.score;
        textScore.text = "" + finalscore;
        PlayerPrefs.SetFloat("finalScore", finalscore);
    }
    public void UpdatePlayerName()
    {
        textPlayerName.text = PlayerPrefs.GetString("name", playerName);
    }

}
