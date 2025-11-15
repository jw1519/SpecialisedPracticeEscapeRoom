using UnityEngine;

[ExecuteInEditMode]
public class RevealLightSource : MonoBehaviour
{
    public Material revealMaterial;
    public Light lightSource;
    float originalSpotAngle = 60f;
    bool isOn => lightSource.enabled;
    private void Awake()
    {
        lightSource = GetComponent<Light>();
        lightSource.color = Color.magenta;
        if (lightSource.enabled)
        {
            TurnLightOnOrOff();
        }
    }
    void Update()
    {
        if (lightSource != null && lightSource.enabled == true)
        {
            revealMaterial.SetVector("_LightPosition", lightSource.transform.position);
            revealMaterial.SetVector("_LightDirection", -lightSource.transform.forward);
            revealMaterial.SetFloat("_LightAngle", lightSource.spotAngle);
        }
    }
    public void TurnLightOnOrOff()
    {
        if (!isOn)
        {
            lightSource.spotAngle = originalSpotAngle;
            lightSource.enabled = true;
        }
        else
        {
            lightSource.spotAngle = 0;
            lightSource.enabled = false;
        }
    }
}
