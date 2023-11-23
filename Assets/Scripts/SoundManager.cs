using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // Создаем статический экземпляр SoundManager

    public AudioClip coinPickupSound; // Звук сбора монетки
    public AudioSource soundSource; // Это ваш источник звука

    void Awake()
    {
        if (instance == null) // Убеждаемся, что существует только один экземпляр SoundManager
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); // Не уничтожать объект при перезагрузке сцены
    }

    public void PlayCoinPickupSound()
    {
        soundSource.clip = coinPickupSound; // Назначаем звук сбора монетки
        soundSource.Play(); // Воспроизводим звук сбора монетки
    }
}
