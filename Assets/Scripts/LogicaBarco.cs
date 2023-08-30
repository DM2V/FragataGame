using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaBarco : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private CapsuleCollider capsuleCollider;

    public float speed = 10f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        // Obtener las entradas de movimiento
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Solo permitir movimiento hacia adelante o giro
        if (verticalInput > 0f)
        {
            // Calcular la dirección del movimiento en el plano XZ
            Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

            if (movementDirection != Vector3.zero)
            {
                // Calcular la posición objetivo
                Vector3 targetPosition = transform.position + movementDirection * speed * Time.deltaTime;

                // Mover el objeto utilizando MovePosition para que resuelva colisiones automáticamente
                rigidbody.MovePosition(targetPosition);
            }
        }
    }
}
