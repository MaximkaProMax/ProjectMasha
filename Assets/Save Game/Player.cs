using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int level = 1;
    public int health = 3;


    //ui methods



    void Update()
    {
        CheckPlayerPosition();
    }

    public void SavePlayer() //для кнопки сохранить
    {
        SaveSystem.SavePlayer(this);
    }


    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }

    void CheckPlayerPosition()
    {
        float playerY = transform.position.y;

        if (playerY < -5f || playerY > 5f)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
