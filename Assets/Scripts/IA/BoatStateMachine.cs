using UnityEngine;

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
        switch (currentState)
        {
            case BoatStateEnum.Moving:
                Move();
                break;
            case BoatStateEnum.TurningRight:
                TurnRight();
                break;
            case BoatStateEnum.MovingBackward:
                MoveBackward();
                break;
            case BoatStateEnum.Stopped:
                StopMoving();
                break;
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.up * forwardSpeed * Time.deltaTime);

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 30f)
        {
            elapsedTime = 0f;
            currentState = BoatStateEnum.TurningRight;
        }
    }

    private void TurnRight()
    {
        transform.Rotate(Vector3.up, 90f * Time.deltaTime);

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 20f)
        {
            elapsedTime = 0f;
            currentState = BoatStateEnum.MovingBackward;
        }
    }

    private void MoveBackward()
    {
        transform.Translate(Vector3.down * forwardSpeed * Time.deltaTime);

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 30f)
        {
            elapsedTime = 0f;
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

public enum BoatStateEnum
{
    Moving,
    TurningRight,
    MovingBackward,
    Stopped
}
