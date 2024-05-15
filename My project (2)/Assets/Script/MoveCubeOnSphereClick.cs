using System.Collections;
using UnityEngine;

public class MoveCubeOnSphereClick : MonoBehaviour
{
    public Transform cubeToMove; // Ссылка на куб, который нужно перемещать
    public float moveSpeed = 1f; // Скорость перемещения куба
    private Vector3 originalPosition; // Исходное положение куба
    private bool isMoving = false; // Флаг, показывающий, находится ли куб в движении

    void Start()
    {
        // Сохраняем исходное положение куба
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
                    // Запускаем перемещение куба туда и обратно
                    StartCoroutine(MoveCubeForwardAndBack());
                }
            }
        }
    }

    IEnumerator MoveCubeForwardAndBack()
    {
        isMoving = true; // Устанавливаем флаг, что куб начал движение
        Vector3 forwardPosition = originalPosition + Vector3.forward * 0.01f;

        // Перемещаем куб вперед
        while (Vector3.Distance(cubeToMove.position, forwardPosition) > 0.0001f)
        {
            cubeToMove.position = Vector3.MoveTowards(cubeToMove.position, forwardPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Перемещаем куб обратно
        while (Vector3.Distance(cubeToMove.position, originalPosition) > 0.0001f)
        {
            cubeToMove.position = Vector3.MoveTowards(cubeToMove.position, originalPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false; // Снимаем флаг движения
    }
}
