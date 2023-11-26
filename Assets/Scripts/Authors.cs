using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Authors : MonoBehaviour
{
    public void ReturnToCreditsMenu()
    {
        SceneManager.LoadScene("Credits"); // Замените "MainMenu" на имя вашей сцены главного меню
    }
}
