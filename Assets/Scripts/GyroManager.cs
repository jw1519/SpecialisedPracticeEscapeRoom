using UnityEngine;

public class GyroManager : MonoBehaviour
{
    public static GyroManager Instance;
    Gyroscope gyroscope;
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
        }
    }
    private void Update()
    {
        if (isGyroActive)
        {
            rotation = gyroscope.attitude;
            rotation = new Quaternion(0, gyroscope.attitude.y, 0, -gyroscope.attitude.w);
        }
    }
}
