using UnityEngine;
using UnityEngine.InputSystem;

public class RCPlaneController : MonoBehaviour
{
    private RCPlaneInputActions inputActions;
    private Vector2 leftStick;  // Throttle (Y) and Yaw (X)
    private Vector2 rightStick; // Pitch (Y) and Roll (X)
    private Rigidbody rb;

    [Header("Flight Settings")]
    public float throttlePower = 20f;  // Power applied to forward movement
    public float yawSpeed = 100f;      // Turning left/right (yaw)
    public float pitchSpeed = 50f;     // Tilting up/down (pitch)
    public float rollSpeed = 50f;      // Tilting left/right (roll)

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from this game object!");
        }

        inputActions = new RCPlaneInputActions();
        inputActions.RCPlane.Enable();
    }

    void Update()
    {
        // Read inputs as Vector2
        leftStick = inputActions.RCPlane.LeftStick.ReadValue<Vector2>();
        rightStick = inputActions.RCPlane.RightStick.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        // Extract individual axes
        float throttle = Mathf.Clamp(leftStick.y, 0f, 1f);
        float yaw = leftStick.x;
        float pitch = rightStick.y;
        float roll = rightStick.x;

        Debug.Log($"{throttle}, {yaw}, {pitch}, {roll},   ");

        // Apply forces/torques for the plane
        Vector3 forwardMovement = transform.forward * throttle * throttlePower;
        rb.AddForce(forwardMovement);

        float yawRotation = yaw * yawSpeed * Time.fixedDeltaTime;
        rb.AddTorque(Vector3.up * yawRotation);

        float pitchRotation = pitch * pitchSpeed * Time.fixedDeltaTime;
        rb.AddTorque(transform.right * pitchRotation);

        float rollRotation = -roll * rollSpeed * Time.fixedDeltaTime;
        rb.AddTorque(transform.forward * rollRotation);
    }
}
