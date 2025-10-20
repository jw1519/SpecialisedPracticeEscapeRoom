using UnityEngine;
using UnityEngine.InputSystem;
public class GyroManager : MonoBehaviour
{
    public static GyroManager Instance;
    UnityEngine.Gyroscope gyroscope;
    public Quaternion rotation;
    public bool isGyroActive;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        isGyroActive = false;
    }
    public void EnableGyro()
    { 
        if (isGyroActive) return;

        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
            isGyroActive = gyroscope.enabled;
            InputSystem.EnableDevice(Accelerometer.current);
            InputSystem.EnableDevice(AttitudeSensor.current);
        }
        else
        {
            isGyroActive = false;
            Debug.Log("Gyroscope not supported on this device");
        }
    }
    public void DisableGyro()
    {
        if (!isGyroActive) return;
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope.enabled = false;
            isGyroActive = gyroscope.enabled;
            InputSystem.DisableDevice(Accelerometer.current);
            InputSystem.DisableDevice(AttitudeSensor.current);
        }
    }
    private void Update()
    {
        if (isGyroActive)
        {
            rotation = gyroscope.attitude;
            rotation = new Quaternion(0, gyroscope.attitude.y, 0, -gyroscope.attitude.w);
            Vector3 acceleration = Accelerometer.current.acceleration.ReadValue();
            Vector3 attatude = AttitudeSensor.current.attitude.ReadValue().eulerAngles;
        }
    }
}
