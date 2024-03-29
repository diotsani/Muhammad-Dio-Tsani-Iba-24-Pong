using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Loading");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("Credit");
    }

    public void OpenAuthor()
    {
        Debug.Log("Created by Muhammad Dio Tsani Iba - 149251970100-113");
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LinkURL()
    {
        Application.OpenURL("https://github.com/diotsani");
    }
}
