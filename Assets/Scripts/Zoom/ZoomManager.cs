using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomManager : MonoBehaviour
{
    public static ZoomManager Instance;
    public List<Zoom> currentZooms = new List<Zoom>();
    public Button zoomOutButton;
    Camera cam => Camera.main;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void RegisterZoom(Zoom zoom)
    {
        if (!currentZooms.Contains(zoom))
        {
            currentZooms.Add(zoom);
        }
        if (currentZooms.Count > 0)
        {
            GyroManager.Instance.DisableGyro();
            zoomOutButton.gameObject.SetActive(true);
        }
    }
    public void UnregisterZoom()
    {
        if (currentZooms.Count > 0)
        {
            Zoom zoom = currentZooms[currentZooms.Count - 1];
            zoom.ZoomOut();
            currentZooms.Remove(zoom);
        }
        if (currentZooms.Count == 0)
        {
            GyroManager.Instance.EnableGyro();
            zoomOutButton.gameObject.SetActive(false);
            cam.fieldOfView = 60; //reset to default zoom
            cam.transform.position = new Vector3(0, 1, 0);
            Debug.Log(transform.position);
        }
        else //zoom to the previous zoom
        {
            Zoom zoom = currentZooms[currentZooms.Count - 1];
            if (zoom == null) UnregisterZoom();
            zoom.ZoomIn();
        }
    }
}
