using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float sensitivity = 10;  // Чувствительность вращения персонажа
    private float rotationLimit = 10f; // Ограничение вращения персонажа по вертикали

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;

            // Ограничиваем вращение персонажа по горизонтали
            transform.localEulerAngles = new Vector3(0, rotationX, 0);

            // // Ограничиваем вращение персонажа по вертикали
            // float rotationY = Mathf.Clamp(transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * sensitivity, -rotationLimit, rotationLimit);
            // transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
        }
    }
}
