using System;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public static event Action OnZoom;
    Collider collider;
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
    }
    public void ZoomOut()
    {
        if (collider != null)
        {
            collider.enabled = true;
        }
        Debug.Log("Zooming out");
    }
}
