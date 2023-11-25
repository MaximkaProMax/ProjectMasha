using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    void Start()
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float targetAspect = 16f / 9f;  // Задайте желаемое соотношение сторон, например, 16:9

        Vector3 scale = transform.localScale;

        if (screenAspect > targetAspect) // Если соотношение сторон экрана больше желаемого соотношения сторон
        {
            scale.y = 1.0f;  // Оставляем высоту неизменной
            scale.x = screenAspect / targetAspect;  // Устанавливаем ширину исходя из соотношения сторон экрана
        }
        else // Если соотношение сторон экрана меньше желаемого соотношения сторон
        {
            scale.x = 1.0f;  // Оставляем ширину неизменной
            scale.y = targetAspect / screenAspect;  // Устанавливаем высоту исходя из соотношения сторон экрана
        }

        transform.localScale = scale;
    }
}