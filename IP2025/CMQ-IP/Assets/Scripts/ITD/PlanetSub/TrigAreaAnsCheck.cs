using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrigAreaAnsCheck : MonoBehaviour
{
    public GenerateSubMathQuestion GenerateSubMathQuestion;
    public StickInteraction StickInteraction;

    int amountOfCrystal = 0;
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Crystal"))
        {  
            amountOfCrystal--;
            Debug.Log("Crystal exited left: " + amountOfCrystal);
        }
    }

    public void InitializeCrystalAmount()
    {
        amountOfCrystal = GenerateSubMathQuestion.spawnObj;
        Debug.Log("Crystal amount: " +  amountOfCrystal);
    }

}
