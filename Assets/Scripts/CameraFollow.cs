using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objeto del barco al que la c�mara debe seguir
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // Ajusta los valores como necesites

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Calcula la posici�n deseada de la c�mara sumando la posici�n del barco y el offset
        Vector3 desiredPosition = target.position + offset;

        // Interpola suavemente la posici�n actual de la c�mara hacia la posici�n deseada
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;

        // Hace que la c�mara mire al barco
        transform.LookAt(target);
    }
}
