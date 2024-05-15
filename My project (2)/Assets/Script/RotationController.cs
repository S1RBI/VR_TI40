using UnityEngine;

public class RotateCubeOnSphereClick : MonoBehaviour
{
    public Transform cubeToRotate; // Ссылка на куб, который нужно вращать
    public Transform cubeToRotate2; // Ссылка на куб, который нужно вращать
    public float rotationSpeed = 50f; // Скорость вращения куба
    private bool isRotating = false; // Флаг, указывающий, вращается ли куб в данный момент

    void Update()
    {
        // Проверяем, была ли нажата кнопка мыши (в данном случае, левая кнопка)
        if (Input.GetMouseButtonDown(0))
        {
            // Создаем луч из позиции камеры в направлении указателя мыши
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Если луч столкнулся с объектом
            if (Physics.Raycast(ray, out hit))
            {
                // Проверяем, что объект, с которым столкнулся луч, это наша сфера
                if (hit.collider.gameObject == gameObject)
                {
                    // Если куб в данный момент не вращается, начинаем его вращать
                    if (!isRotating)
                    {
                        StartRotation();
                    }
                    else // Иначе, если куб уже вращается, останавливаем его вращение
                    {
                        StopRotation();
                    }
                }
            }
        }
    }

    void StartRotation()
    {
        // Устанавливаем флаг вращения в true
        isRotating = true;
    }

    void StopRotation()
    {
        // Устанавливаем флаг вращения в false
        isRotating = false;
    }

    void FixedUpdate()
    {
        // Если флаг вращения установлен в true, вращаем куб
        if (isRotating)
        {
            // Вращаем куб по оси Y
            cubeToRotate.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            cubeToRotate2.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}
