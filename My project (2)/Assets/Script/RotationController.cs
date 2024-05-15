using UnityEngine;

public class RotateCubeOnSphereClick : MonoBehaviour
{
    public Transform cubeToRotate; // ������ �� ���, ������� ����� �������
    public Transform cubeToRotate2; // ������ �� ���, ������� ����� �������
    public float rotationSpeed = 50f; // �������� �������� ����
    private bool isRotating = false; // ����, �����������, ��������� �� ��� � ������ ������

    void Update()
    {
        // ���������, ���� �� ������ ������ ���� (� ������ ������, ����� ������)
        if (Input.GetMouseButtonDown(0))
        {
            // ������� ��� �� ������� ������ � ����������� ��������� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���� ��� ���������� � ��������
            if (Physics.Raycast(ray, out hit))
            {
                // ���������, ��� ������, � ������� ���������� ���, ��� ���� �����
                if (hit.collider.gameObject == gameObject)
                {
                    // ���� ��� � ������ ������ �� ���������, �������� ��� �������
                    if (!isRotating)
                    {
                        StartRotation();
                    }
                    else // �����, ���� ��� ��� ���������, ������������� ��� ��������
                    {
                        StopRotation();
                    }
                }
            }
        }
    }

    void StartRotation()
    {
        // ������������� ���� �������� � true
        isRotating = true;
    }

    void StopRotation()
    {
        // ������������� ���� �������� � false
        isRotating = false;
    }

    void FixedUpdate()
    {
        // ���� ���� �������� ���������� � true, ������� ���
        if (isRotating)
        {
            // ������� ��� �� ��� Y
            cubeToRotate.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            cubeToRotate2.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}
