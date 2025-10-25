using UnityEngine;

[ExecuteInEditMode]
public class RevealLightSource : MonoBehaviour
{
    public Material revealMaterial;
    public Light lightSource;
    private void Awake()
    {
        lightSource = GetComponent<Light>();
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
}
