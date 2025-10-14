using UnityEngine;

public class GyroManager : MonoBehaviour
{
    public static GyroManager Instance;
    Gyroscope gyroscope;
    public Quaternion rotation;
    bool gyroActive;

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
        gyroActive = false;
    }
    public void EnableGyro()
    { 
        if (gyroActive) return;

        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
            gyroActive = gyroscope.enabled;
        }
        else
        {
            gyroActive = false;
            Debug.Log("Gyroscope not supported on this device");
        }
    }
    private void Update()
    {
        if (gyroActive)
        {
            rotation = gyroscope.attitude;
            rotation = new Quaternion(0, gyroscope.attitude.y, 0, -gyroscope.attitude.w);
        }
    }
}
