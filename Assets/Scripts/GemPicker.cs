using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GemPicker : MonoBehaviour
{
    public TMP_Text coinsText;
    public AudioSource coinSound; // Ссылка на источник звука
    public AudioClip coinPickupSound; // Звук сбора монетки
    private float coins = 0;

    private void Start()
    {
        coinSound = GetComponent<AudioSource>(); // Получаем доступ к Audio Source
        coinSound.clip = coinPickupSound; // Назначаем звук сбора монетки
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Gem")
        {
            coins++;
            coinsText.text = coins.ToString();
            SoundManager.instance.PlayCoinPickupSound(); // Вызываем метод воспроизведения звука из SoundManager
            Destroy(coll.gameObject);
        }
    }
}