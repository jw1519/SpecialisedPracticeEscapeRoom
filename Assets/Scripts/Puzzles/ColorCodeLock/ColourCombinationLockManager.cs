using System;
using System.Collections;
using UnityEngine;

public class ColourCombinationLockManager : MonoBehaviour
{
    public string[] correctCombination;
    public string[] currentCombination;
    void Start()
    {
        Rotation.Rotated += OnRotated;
        //set initial combination to all LightBlue as its the starting colour
        currentCombination = new string[correctCombination.Length];
        for (int i = 0; i < currentCombination.Length; i++)
        {
            currentCombination[i] = "LightBlue";
        }
    }
    private void OnRotated(string wheelName, string colour)
    {
        StartCoroutine(CheckCombination(wheelName, colour));
    }

    public IEnumerator CheckCombination(string wheelName, string colour)
    {
        switch (wheelName)
        {
            case "Wheel_1":
                currentCombination[0] = colour;
                break;
            case "Wheel_2":
                currentCombination[1] = colour;
                break;
            case "Wheel_3":
                currentCombination[2] = colour;
                break;
            case "Wheel_4":
                currentCombination[3] = colour;
                break;
        }
        if (IsCombinationCorrect())
        {
            Debug.Log("Combination Correct! Lock Opened.");
            yield return new WaitForSeconds(1f);
            Destroy(gameObject); //when code is correct destroy the lock
        }
    }
    public bool IsCombinationCorrect()
    {
        for (int i = 0; i < correctCombination.Length; i++)
        {
            if (currentCombination[i] != correctCombination[i])
            {
                return false;
            }
        }
        return true;
    }
}
