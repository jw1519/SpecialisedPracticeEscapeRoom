using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public int movementSpeed;
    Transform rotator;
    float smoothing = 0.1f;
    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rotator = new GameObject("rotator").transform;
        rotator.SetPositionAndRotation(transform.position, transform.rotation);
    }
    private void FixedUpdate()
    {
        if (!GyroManager.Instance.isGyroActive) return;
        Move();
        LookAround();
    }
    void Move()
    {
        Vector3 acceleration = Accelerometer.current.acceleration.ReadValue();

        Vector3 moveDirection = new(acceleration.x * movementSpeed * Time.deltaTime, 0, -acceleration.z * movementSpeed * Time.deltaTime);
        Vector3 transformedDirection = transform.TransformDirection(moveDirection);

        characterController.Move(transformedDirection);
    }
    private void LookAround()
    {
        Quaternion attitude = AttitudeSensor.current.attitude.ReadValue();

        rotator.rotation = attitude;
        rotator.Rotate(0f, 0f, 180f, Space.Self);
        rotator.Rotate(90f, 180f, 0f, Space.World);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotator.rotation, smoothing);
    }
}
