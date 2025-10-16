using TMPro;
using UnityEngine;
public class KeyPadDisplay : MonoBehaviour
{
    public TextMeshPro text;

    private void Start()
    {
        KeyPad.inputChanged += UpdateDisplay;
    }
    public void UpdateDisplay(string playerInput)
    {
        text.text = playerInput;
    }
}