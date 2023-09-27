using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform tower; // Ссылка на объект башни
    public float cameraSpeed = 2.0f; // Скорость движения камеры
    private Vector3 initialPosition; // Исходная позиция камеры

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Поднимаем камеру вверх по мере роста башни
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Lerp(transform.position.y, initialPosition.y + tower.transform.localScale.y, cameraSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
