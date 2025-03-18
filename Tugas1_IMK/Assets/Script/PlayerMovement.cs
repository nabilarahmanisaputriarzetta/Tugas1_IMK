using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 20f;
    public float lateralSpeed = 15f;
    public float maxLateralPos = 3f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (GameStateManager.Instance.CurrentState == GameState.Playing)
        {
            ForwardMovement();
            LateralMovement();
            ClampPosition();
        }
    }

    void ForwardMovement()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, forwardSpeed);
    }

    void LateralMovement()
    {
        float direction = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            direction = -1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            direction = 1f;

        rb.linearVelocity = new Vector3(direction * lateralSpeed, rb.linearVelocity.y, forwardSpeed);
    }

    void ClampPosition()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -maxLateralPos, maxLateralPos);
        transform.position = clampedPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameStateManager.Instance.ChangeToGameOver();
        }
    }
}