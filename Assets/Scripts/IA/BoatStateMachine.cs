using UnityEngine;

public enum BoatStateEnum
{
    Moving,
    TurningRight,
    MovingBackward,
    Stopped
}

public class BoatStateMachine : MonoBehaviour
{
    public BoatStateEnum currentState;
    private float elapsedTime = 0f;
    public float forwardSpeed = 5f; // Ajusta la velocidad hacia adelante

    private void Start()
    {
        currentState = BoatStateEnum.Moving;
    }

    private void Update()
    {
        // Actualizar el estado actual
        switch (currentState)
        {
            case BoatStateEnum.Moving:
                // El barco está en movimiento
                Move();
                break;
            case BoatStateEnum.TurningRight:
                // El barco está girando a la derecha
                TurnRight();
                break;
            case BoatStateEnum.MovingBackward:
                // El barco se mueve hacia la izquierda en el espacio local
                // Cambia al estado de parada después de 20 segundos
                transform.Translate(Vector3.up * -forwardSpeed * Time.deltaTime, Space.Self);
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= 20f)
                {
                    currentState = BoatStateEnum.Stopped;
                }
                break;
            case BoatStateEnum.Stopped:
                // El barco está detenido
                StopMoving();
                break;
        }
    }

    private void Move()
    {
        // El barco se mueve hacia adelante
        transform.Translate(Vector3.up * forwardSpeed * Time.deltaTime);

        // Si ha pasado el tiempo suficiente, cambia al estado de giro
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 30f)
        {
            elapsedTime = 0f;
            currentState = BoatStateEnum.TurningRight;
        }
    }

    private void TurnRight()
    {
        // El barco gira a la derecha
        transform.Rotate(Vector3.up, 90f * Time.deltaTime);

        // Si ha pasado el tiempo suficiente, cambia al estado de movimiento hacia atrás
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 20f)
        {
            elapsedTime = 0f;
            currentState = BoatStateEnum.MovingBackward;
        }
    }

    private void MoveBackward()
    {
        // El barco se mueve hacia la izquierda en el espacio local
        // Cambia al estado de parada después de 20 segundos
        transform.Translate(Vector3.up * -forwardSpeed * Time.deltaTime, Space.Self);
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 20f)
        {
            currentState = BoatStateEnum.Stopped;
        }
    }

    private void StopMoving()
    {
        // Detener cualquier tipo de movimiento del barco
        // Por ejemplo, si tienes un Rigidbody, podrías establecer su velocidad en cero:
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
    }
}