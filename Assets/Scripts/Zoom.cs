using System;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public static event Action OnZoom;
    Collider collider;
    public int zoomLevel = 1;
    Camera camera => Camera.main;
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
            collider.isTrigger = false;
        }
        Debug.Log("Zooming in");
        camera.transform.position = new Vector3(0, .86f, -.4f);
        OnZoom?.Invoke();
    }
    public void ZoomOut()
    {
        if (collider != null)
        {
            collider.isTrigger = true;
        }
        Debug.Log("Zooming out");
    }
}
