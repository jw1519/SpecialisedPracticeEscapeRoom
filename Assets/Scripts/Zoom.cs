using System;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    Collider collider;
    public int zoomView;
    public Quaternion rotation;
    public Vector3 targetPosition;
    Camera cam => Camera.main;
    private void Awake()
    {
        collider = GetComponent<Collider>();
    }
    private void OnMouseDown()
    {
        ZoomIn();
    }
    public void ZoomIn()
    {
        if (collider != null)
        {
            collider.enabled = false;
        }
        cam.transform.LookAt(transform, Vector3.up);
        ZoomManager.Instance.RegisterZoom(this);
        cam.fieldOfView = zoomView;
        // Apply rotation while maintaining other axes
        Vector3 currentRotation = cam.transform.rotation.eulerAngles;
        if (rotation.x != 0)
        {
            currentRotation.x += rotation.x;
        }
        else if (rotation.y != 0)
        {
            currentRotation.y += rotation.y;
        }
        else if (rotation.z != 0)
        {
            currentRotation.z += rotation.z;
        }
        cam.transform.rotation = Quaternion.Euler(currentRotation);

        // Apply target position if specified
        if (targetPosition != Vector3.zero)
        {
            cam.transform.position = targetPosition;
        }
    }
    public void ZoomOut()
    {
        if (collider != null)
        {
            collider.enabled = true;
        }
        Debug.Log("Zooming out");
    }
    private void OnDestroy()
    {
        ZoomManager.Instance.currentZooms.Remove(this);
    }
}
