using System;
using UnityEngine;
using UnityEngine.UI;

public class Inspect : MonoBehaviour
{
    public static Inspect instance;

    public GameObject objectPrefab;
    Transform objectToInspect;
    public float rotationSpeed;
    public GameObject backButton;
    Vector3 cameraPosition;
    Quaternion cameraRotation;

    Vector3 previousMousePosition;
    Camera cam;
    private void Awake()
    {
        instance = this;
        cam = Camera.main;
        gameObject.SetActive(false);
    }
    public void EnableInspect(GameObject obj)
    {
        objectPrefab = obj;
        if (objectPrefab != null)
        {
            gameObject.SetActive(true);
            backButton.SetActive(true);
            GameObject instance = Instantiate(objectPrefab, transform);
            objectPrefab = instance;
            objectToInspect = objectPrefab.transform;
            // keep original position and roation
            cameraPosition = cam.transform.localPosition;
            cameraRotation = cam.transform.rotation;

            cam.transform.localPosition = new Vector3(cam.transform.position.x, 5, cam.transform.position.x);
            cam.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public void DisableInspect()
    {
        Destroy(objectPrefab);
        objectToInspect = null;
        gameObject.SetActive(false);
        backButton.SetActive(false);

        //put camera back
        cam.transform.localPosition = cameraPosition;
        cam.transform.rotation = cameraRotation;
    }
    private void Update()
    {
        if (objectToInspect == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMoutsePosition = Input.mousePosition - previousMousePosition;
            float rotationX = -deltaMoutsePosition.y * rotationSpeed * Time.deltaTime;
            float rotationY = -deltaMoutsePosition.x * rotationSpeed * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
            objectToInspect.rotation = rotation * objectToInspect.rotation;
            previousMousePosition = Input.mousePosition;
        }
    }
}
