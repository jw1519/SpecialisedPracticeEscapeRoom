using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public static string correctCode = "1234";
    public static string playerInput = "";
    // Update is called once per frame
    void Update()
    {

        if (playerInput.Length == correctCode.Length)
        {
            if (playerInput == correctCode)
            {
                //unlock
                Debug.Log("corret code input");
            }
            else
            {
                //display error on keypad
                playerInput = "";
            }
        }
    }
    private void OnMouseUp()
    {
        if (playerInput.Length != correctCode.Length)
        {
            playerInput += gameObject.name;
        }
    }
}
