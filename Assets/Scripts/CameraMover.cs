using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform tower; // ������ �� ������ �����
    public float cameraSpeed = 2.0f; // �������� �������� ������
    private Vector3 initialPosition; // �������� ������� ������

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // ��������� ������ ����� �� ���� ����� �����
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Lerp(transform.position.y, initialPosition.y + tower.transform.localScale.y, cameraSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
