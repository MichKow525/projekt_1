using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class scoreboard : MonoBehaviour
{
    public TextMeshProUGUI textPlayerName;
    public TextMeshProUGUI textDeaths;
    public TextMeshProUGUI textScore;
    public movement script;
    public static string playerName;

    void Start()
    {
       
    }
    void Update()
    {
        textPlayerName.text = "Gratulacje " + PlayerPrefs.GetString("name", "test");
        textScore.text = "Twój wynik to : " + PlayerPrefs.GetFloat("finalScore",0);
        textDeaths.text = "œmierci: " + PlayerPrefs.GetInt("œmierci", 0) ;
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.DeleteAll();
    }

}
