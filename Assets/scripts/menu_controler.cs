using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class menucontroler : MonoBehaviour
{   public movement script;
    public TextMeshProUGUI textPlayerName;
    public TextMeshProUGUI textLives;
    public static string playerName;
    public float ktory_lvl; 
    
    public void CreatePlayer(TMP_InputField input)
    {   if (input.text.Length == 0 || input.text.Length > 15)
        {
            return;
        }
        // reset zapisanych warto�ci
        PlayerPrefs.DeleteAll();
        playerName = input.text;
        PlayerPrefs.SetString("name", playerName);
        SceneManager.LoadScene(1);

     }

    public void LoadGame()
    {   
    
        
        if (PlayerPrefs.GetFloat("scena1", 1) == 1)
        {
        SceneManager.LoadScene(1);
        }
        if (PlayerPrefs.GetFloat("scena1", 1) == 2)
        {
        SceneManager.LoadScene(2);
        }


        }
    public void Exit()
    {
        Application.Quit();
    }
   
}
