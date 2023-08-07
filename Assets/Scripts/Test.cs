using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public void Play()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(1);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
    public void menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
