using System;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public static event Action<string, string> Rotated;
    List<string> colors;
    public string currentColor = "LightBlue";
    public Transform pivotPoint;
    private void Start()
    {
        currentColor = colors[0];
        // Define the color sequence
        colors = new List<string> { "LightBlue", "Green", "Yellow", "Pink", "DarkBlue", "Red" };
    }
    public void Rotate()
    {
        transform.RotateAround(pivotPoint.position, Vector3.right, 60);
        currentColor = colors[(colors.IndexOf(currentColor) + 1) % colors.Count];
        Rotated?.Invoke(gameObject.name, currentColor);
    }
    private void OnMouseDown()
    {
        Rotate();
    }
}
