using TMPro;
using UnityEngine;

public class KeyPadDisplay : MonoBehaviour
{
    public TextMeshPro text;

    // Update is called once per frame
    void Update()
    {
        text.text = KeyPad.playerInput;
    }
}