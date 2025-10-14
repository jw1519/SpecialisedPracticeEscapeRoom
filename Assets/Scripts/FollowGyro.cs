using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    [SerializeField] Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    void Start()
    {
        GyroManager.Instance.EnableGyro();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = GyroManager.Instance.rotation;
    }
}
