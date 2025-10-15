using System;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public static event Action OnZoom;
    Collider collider;
    private void Awake()
    {
        collider = GetComponent<Collider>();
    }
    private void OnMouseDown()
    {
        if (collider != null)
        {
            Debug.Log("Zooming in");
            collider.enabled = false;
        }
        Camera.main.orthographicSize = 1;
        OnZoom?.Invoke();
    }
}
