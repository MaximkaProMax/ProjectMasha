
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject[] pipePrefabs; // Массив различных префабов труб
    public float spawnInterval = 2f;
    public float minY = -5f;  // Минимальная координата Y
    public float maxY = 5f;   // Максимальная координата Y
    public float spawnRangeX = 10f; // Расстояние вдоль оси X, на котором будут появляться трубы

    private bool spawningFromTop = true; // флаг, указывающий, сверху или снизу появится следующая труба
    private List<GameObject> pipes = new List<GameObject>(); // Список всех созданных труб

    void Update()
    {
        // Запускаем метод создания труб
        SpawnPipe();

        // Удаляем трубы, которые ушли за пределы игровой области
        for (int i = 0; i < pipes.Count; i++)
        {
            if (pipes[i].transform.position.x < transform.position.x - spawnRangeX)
            {
                Destroy(pipes[i]);
                pipes.RemoveAt(i);
                i--;
            }
        }
    }

    void SpawnPipe()
    {
        // Проверяем, нужно ли создать новую трубу в данный момент
        if (Time.time >= spawnInterval)
        {
            // Сбрасываем таймер
            spawnInterval = Time.time + 2f;

            // Выбираем случайный префаб из массива
            GameObject selectedPipePrefab = pipePrefabs[Random.Range(0, pipePrefabs.Length)];

            // Создаем новую трубу основываясь на выбранном префабе
            GameObject newPipe = Instantiate(selectedPipePrefab);

            // Определяем позицию для появления новой трубы
            float spawnY = spawningFromTop ? maxY : minY;

            // Позиционируем трубу в указанной позиции по оси Y и X
            newPipe.transform.position = new Vector2(transform.position.x + spawnRangeX, spawnY);

            // Добавляем коллайдер к новой трубе
            BoxCollider2D pipeCollider = newPipe.AddComponent<BoxCollider2D>(); // Вот здесь исправлено!

            // Добавляем новую трубу в список
            pipes.Add(newPipe);

            // Инвертируем флаг для следующей трубы
            spawningFromTop = !spawningFromTop;
        }
    }
}
