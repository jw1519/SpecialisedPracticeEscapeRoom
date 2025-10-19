using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public int movementSpeed;
    CameraMovementInput inputAction;
    InputAction move;
    Rigidbody rb;
    
    Vector3 forceDirection = Vector3.zero;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputAction = new CameraMovementInput();
    }
    private void OnEnable()
    {
        move = inputAction.Camera.Move;
        inputAction.Camera.Enable();
    }
    private void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * movementSpeed * transform.right;
        forceDirection += move.ReadValue<Vector2>().y * movementSpeed * transform.forward;
        rb.AddForce(forceDirection, ForceMode.Force);
        forceDirection = Vector3.zero;
    }
}
