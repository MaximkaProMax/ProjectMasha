using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInfo : MonoBehaviour
{
    public GameObject infoPanel;
    private bool isPlayerClose;

    private void Start()
    {
        // Предположим, что infoPanel привязан в инспекторе
        // Проверим привязку перед установкой активности
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("InfoPanel is not assigned!");
        }
    }

    // Убираем Update, так как мы будем управлять отображением панели через OnTriggerEnter2D и OnTriggerExit2D

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = true;
            DisplayInfoPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = false;
            HideInfoPanel();
        }
    }

    private void DisplayInfoPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("InfoPanel is not assigned!");
        }
    }

    private void HideInfoPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("InfoPanel is not assigned!");
        }
    }
}