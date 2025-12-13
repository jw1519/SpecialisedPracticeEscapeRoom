using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public int movementSpeed;
    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        GyroManager.Instance.EnableGyro();
    }
    private void FixedUpdate()
    {
        if (!GyroManager.Instance.isGyroActive) return;
        transform.localRotation = GyroManager.Instance.rotation;
        Move();
    }
    void Move()
    {
        if (characterController != null)
        {
            Vector3 acceleration = Accelerometer.current.acceleration.ReadValue();

            Vector3 moveDirection = new(acceleration.x * movementSpeed * Time.deltaTime, 0, -acceleration.z * movementSpeed * Time.deltaTime);
            Vector3 transformedDirection = transform.TransformDirection(moveDirection);

            characterController.Move(transformedDirection);
        }
    }
    public void TurnLeft()
    {
        gameObject.transform.Rotate(0, -90, 0);
    }
    public void TurnRight()
    {
        gameObject.transform.Rotate(0, 90, 0);
    }
}
