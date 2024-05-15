using UnityEngine;

public class RotateAndMove : MonoBehaviour
{
    public Transform rotatingObject; // Вращающийся объект
    public Transform movingObject; // Перемещаемый объект

    public float moveFactor = 0.1f; // Коэффициент перемещения

    public enum RotationAxis { X, Y, Z } // Перечисление для выбора оси вращения
    public RotationAxis rotationAxis = RotationAxis.X; // По умолчанию вращение вокруг оси X

    public enum MoveDirection { X, Y, Z } // Перечисление для выбора направления перемещения
    public MoveDirection moveDirection = MoveDirection.X; // По умолчанию перемещение вдоль оси X

    private Quaternion previousRotation; // Предыдущий кватернион поворота

    void Start()
    {
        previousRotation = rotatingObject.rotation; // Инициализация предыдущего кватерниона текущим значением поворота
    }

    void Update()
    {
        Quaternion currentRotation = rotatingObject.rotation;
        Quaternion deltaRotation = Quaternion.Inverse(previousRotation) * currentRotation;

        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);

        Vector3 movementDirection = Vector3.zero;
        switch (moveDirection)
        {
            case MoveDirection.X:
                movementDirection = Vector3.right;
                break;
            case MoveDirection.Y:
                movementDirection = Vector3.up;
                break;
            case MoveDirection.Z:
                movementDirection = Vector3.forward;
                break;
        }

        // Проверяем, соответствует ли ось вращения выбранной пользователем
        if ((rotationAxis == RotationAxis.X && Mathf.Abs(axis.x) > 0.9f) ||
            (rotationAxis == RotationAxis.Y && Mathf.Abs(axis.y) > 0.9f) ||
            (rotationAxis == RotationAxis.Z && Mathf.Abs(axis.z) > 0.9f))
        {
            float movement = angle * (axis[(int)rotationAxis] > 0 ? 1 : -1) * moveFactor;
            movingObject.position += movementDirection * movement;
        }

        previousRotation = currentRotation;
    }
}
