using UnityEngine;

public class Draw : MonoBehaviour
{
    public Collider drawCollider;
    bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ColourCombinationLockManager.CombinationCorrect += CanOpen;
        drawCollider = GetComponent<Collider>();
        drawCollider.isTrigger = false;
    }
    public void CanOpen()
    {
        drawCollider.isTrigger = true;
    }
    private void OnMouseDown()
    {
        if (isOpen)
        {
            Vector3 move = new Vector3(0.7f, 0, 0);
            transform.Translate(move * 0.5f);
            isOpen = false;
        }
        else
        {
            Vector3 move = new Vector3(-0.7f, 0, 0);
            transform.Translate(move * 0.5f);
            isOpen = true;
        }
        
    }
}
