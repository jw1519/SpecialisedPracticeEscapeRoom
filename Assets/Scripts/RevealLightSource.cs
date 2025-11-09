using UnityEngine;

[ExecuteInEditMode]
public class RevealLightSource : MonoBehaviour
{
    public Material revealMaterial;
    public Light lightSource;
    float originalSpotAngle = 60f;
    private void Awake()
    {
        lightSource = GetComponent<Light>();
        lightSource.color = Color.magenta;
    }
    // Update is called once per frame
    void Update()
    {
        if (lightSource != null)
        {
            revealMaterial.SetVector("_LightPosition", lightSource.transform.position);
            revealMaterial.SetVector("_LightDirection", -lightSource.transform.forward);
            revealMaterial.SetFloat("_LightAngle", lightSource.spotAngle);
        }
        
    }
    public void SetLightOff()
    {
        lightSource.spotAngle = 0;
    }
    public void ResetLightAngle()
    {
        lightSource.spotAngle = originalSpotAngle;
    }
}
