using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    void Start()
    {
        GyroManager.Instance.EnableGyro();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GyroManager.Instance.isGyroActive) return;
        transform.localRotation = GyroManager.Instance.rotation;
    }
}
