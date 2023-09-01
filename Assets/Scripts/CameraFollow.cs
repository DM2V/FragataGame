using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objeto del barco al que la cámara debe seguir
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // Ajusta los valores como necesites

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Calcula la posición deseada de la cámara sumando la posición del barco y el offset
        Vector3 desiredPosition = target.position + offset;

        // Interpola suavemente la posición actual de la cámara hacia la posición deseada
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;

        // Hace que la cámara mire al barco
        transform.LookAt(target);
    }
}
