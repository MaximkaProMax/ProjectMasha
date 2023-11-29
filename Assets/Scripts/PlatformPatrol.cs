using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool movingRight = true;
    public Transform groundDetection;

    void Update()
    {
        // Определяем направление движения
        Vector3 direction = movingRight ? Vector3.right : Vector3.left;
        transform.Translate(direction * speed * Time.deltaTime);

        // Создаем обнаружение земли впереди
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        // Проверяем столкновение с препятствием
        if (groundInfo.collider == false)
        {
            // Поворачиваем, если нет земли впереди
            Flip();
        }

        // Проверяем столкновение с препятствием слева или справа
        RaycastHit2D obstacleInfo = Physics2D.Raycast(transform.position, direction, 1f);
        if (obstacleInfo.collider != null)
        {
            // Поворачиваем, если есть препятствие слева или справа
            Flip();
        }
    }

    void Flip()
    {
        // Меняем направление движения и разворачиваем объект
        movingRight = !movingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}