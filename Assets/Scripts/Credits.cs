using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");  // Замените "MainMenu" на имя вашей сцены главного меню
    }
}