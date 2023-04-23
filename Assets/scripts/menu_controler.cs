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
    
    public void CreatePlayer(TMP_InputField input)
    {   if (input.text.Length == 0 || input.text.Length > 15)
        {
            return;
        }
    playerName = input.text;
        SceneManager.LoadScene(1);

     }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
   
}
