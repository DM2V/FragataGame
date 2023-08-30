using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // El objeto que la cámara seguirá
    public Vector3 offset = new Vector3(41, 26, -100);       // La distancia entre la cámara y el objetivo
    public float smoothSpeed = 0.125f;  // La velocidad de suavizado

    private void LateUpdate()
    {
        // Calcula la posición deseada de la cámara
        Vector3 desiredPosition = target.position + offset;
        // Interpola suavemente hacia la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Actualiza la posición de la cámara
        transform.position = smoothedPosition;

        // Asegura que la cámara mire hacia el objetivo
        transform.LookAt(target);
    }
}
