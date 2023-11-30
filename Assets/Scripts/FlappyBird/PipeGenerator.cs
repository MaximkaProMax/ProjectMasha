using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeGenerator : MonoBehaviour
{
    public GameObject[] pipePrefabs; // Массив различных префабов труб
    public float spawnInterval = 2f;
    public float minY = -5f;  // Минимальная координата Y
    public float maxY = 5f;   // Максимальная координата Y
    public float spawnRangeX = 10f; // Расстояние вдоль оси X от игрока, на котором будут появляться трубы

    private Transform playerTransform; // Ссылка на трансформ игрока
    private List<GameObject> pipes = new List<GameObject>(); // Список всех созданных труб

    void Start()
    {
        // Находим трансформ игрока
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Удаляем трубы, которые ушли за пределы игровой области
        for (int i = pipes.Count - 1; i >= 0; i--)
        {
            if (pipes[i].transform.position.x < playerTransform.position.x - spawnRangeX)
            {
                Destroy(pipes[i]);
                pipes.RemoveAt(i);
            }

            if (playerTransform.position.y > 10 || playerTransform.position.y < -10)
            {
                ReloadScene();
            }
        }

        // Запускаем метод создания труб только если прошло достаточно времени
        if (Time.time >= spawnInterval)
        {
            SpawnPipe();
            spawnInterval += 2f; // Увеличиваем интервал по времени для следующего создания трубы
        }
    }

    void SpawnPipe()
    {
        // Выбираем случайный префаб из массива
        GameObject selectedPipePrefab = pipePrefabs[Random.Range(0, pipePrefabs.Length)];

        // Создаем новую трубу основываясь на выбранном префабе
        GameObject newPipe = Instantiate(selectedPipePrefab);

        // Определяем позицию Y для появления новой трубы
        float spawnY = Random.Range(minY, maxY);

        // Позиционируем трубу в указанной позиции по оси Y и X на расстоянии spawnRangeX от игрока
        newPipe.transform.position = new Vector2(playerTransform.position.x + spawnRangeX, spawnY);

        // Добавляем новую трубу в список
        pipes.Add(newPipe);
    }

        void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pipe"))  
        {
            ReloadScene(); // Перезагрузить сцену при соприкосновении с трубой
        }
    }
}
