using System.Collections;
using UnityEngine;

public class MoveCubeOnSphereClick : MonoBehaviour
{
    public Transform cubeToMove; // ������ �� ���, ������� ����� ����������
    public float moveSpeed = 1f; // �������� ����������� ����
    private Vector3 originalPosition; // �������� ��������� ����
    private bool isMoving = false; // ����, ������������, ��������� �� ��� � ��������

    void Start()
    {
        // ��������� �������� ��������� ����
        originalPosition = cubeToMove.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject && !isMoving)
                {
                    // ��������� ����������� ���� ���� � �������
                    StartCoroutine(MoveCubeForwardAndBack());
                }
            }
        }
    }

    IEnumerator MoveCubeForwardAndBack()
    {
        isMoving = true; // ������������� ����, ��� ��� ����� ��������
        Vector3 forwardPosition = originalPosition + Vector3.forward * 0.01f;

        // ���������� ��� ������
        while (Vector3.Distance(cubeToMove.position, forwardPosition) > 0.0001f)
        {
            cubeToMove.position = Vector3.MoveTowards(cubeToMove.position, forwardPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // ���������� ��� �������
        while (Vector3.Distance(cubeToMove.position, originalPosition) > 0.0001f)
        {
            cubeToMove.position = Vector3.MoveTowards(cubeToMove.position, originalPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false; // ������� ���� ��������
    }
}
