using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // El objeto que la c�mara seguir�
    public Vector3 offset = new Vector3(41, 26, -100);       // La distancia entre la c�mara y el objetivo
    public float smoothSpeed = 0.125f;  // La velocidad de suavizado

    private void LateUpdate()
    {
        // Calcula la posici�n deseada de la c�mara
        Vector3 desiredPosition = target.position + offset;
        // Interpola suavemente hacia la posici�n deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Actualiza la posici�n de la c�mara
        transform.position = smoothedPosition;

        // Asegura que la c�mara mire hacia el objetivo
        transform.LookAt(target);
    }
}
