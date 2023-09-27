using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private Transform _tower;

    public float hookSpeed = 2.0f; // �������� �������� �����
    public GameObject boxPrefab; // ������ �������
    public Transform spawnPoint; // �����, ��� ����� ���������� �������
    private GameObject currentBox; // ������� �������, ������������ �� �����

    private bool isMovingLeft = true; // ����, ����� ����������, �������� �� ���� �����
    private ButtonManager _buttonManager;
    private GameController _gameController;

    private void Start()
    {
        SpawnBox();
        _buttonManager = FindObjectOfType<ButtonManager>();
        _gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        // ������� ���� ����� � ������
        Vector3 newPosition = transform.position;
        if (isMovingLeft)
        {
            newPosition.x -= hookSpeed * Time.deltaTime;
        }
        else
        {
            newPosition.x += hookSpeed * Time.deltaTime;
        }
        transform.position = newPosition;

        // ���� ���� ��������� �������, ������ ����������� ��������
        if (transform.position.x <= -4.0f)
        {
            isMovingLeft = false;
        }
        else if (transform.position.x >= 4.0f)
        {
            isMovingLeft = true;
        }

        // ���� ������ ����� ������ ���� � ���� ������� �� �����, ��������� �������
        if (Input.GetMouseButtonDown(0) && currentBox != null && _buttonManager.IsPlaying())
        {
            _gameController.AddScore();
            ReleaseBox();
            Invoke("MoveCamera", 1f);
            
            Invoke("SpawnBox", 1.5f);
        }
    }

    private void MoveCamera()
    {
        var newCameraPosition = Camera.main.transform.position.y + 1.7f;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, newCameraPosition, Camera.main.transform.position.z);
    }

    void SpawnBox()
    {
        // ������� � ������� ������� �� ����� ����� � ���������� �� �� �����
        currentBox = Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
        currentBox.transform.parent = transform;
    }

    void ReleaseBox()
    {
        // ��������� ������� �� ����� � ������� �� ������������
        currentBox.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        currentBox.transform.parent = null;
        currentBox = null;
    }
}
