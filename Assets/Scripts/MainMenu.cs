using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("Level3");
    }
}
