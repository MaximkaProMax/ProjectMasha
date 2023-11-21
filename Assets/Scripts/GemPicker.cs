using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemPicker : MonoBehaviour
{
    public TMP_Text coinsText;
    private float coins = 0;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Gem")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(coll.gameObject);
        }
    }
}
