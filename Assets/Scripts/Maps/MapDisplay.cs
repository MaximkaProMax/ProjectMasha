using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text mapName;
    [SerializeField] private TMP_Text mapDescription;
    [SerializeField] private Image mapImage;
    [SerializeField] private Button playButton;

    public void DisplayMap(Map map)
    {
        mapName.text = map.mapName;
        mapDescription.text = map.mapDescription;
        mapImage.sprite = map.mapImage;

        bool mapUnlocked = PlayerPrefs.GetInt("currentScene", 0) >= map.mapIndex;

        playButton.interactable = mapUnlocked;

        if (mapUnlocked)
            mapImage.color = Color.white;
        else
            mapImage.color = Color.grey;

        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() => SceneManager.LoadScene(map.mapName));
    }
}
