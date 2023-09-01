using UnityEngine;

public class Barco : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public float speed = 10f;
    public float rotationSpeed = 30f; // Velocidad de giro en grados por segundo

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Obtener las entradas de movimiento
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular el ángulo de giro basado en la entrada horizontal
        float rotationAngle = horizontalInput * rotationSpeed * Time.deltaTime;

        // Girar el objeto alrededor de su eje vertical (up)
        transform.Rotate(Vector3.up, rotationAngle);

        // Calcular la dirección del movimiento en el plano XZ
        Vector3 forwardMovement = transform.forward * verticalInput * speed * Time.deltaTime;

        // Calcular la posición objetivo
        Vector3 targetPosition = rigidbody.position + forwardMovement;

        // Mover el objeto utilizando MovePosition para que resuelva colisiones automáticamente
        rigidbody.MovePosition(targetPosition);
    }
}
