using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTrigger : MonoBehaviour
{
    public string scaleID; // Identify the scale (Scale1 or Scale2)
    public AnswerCalculate AnswerCalculate; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            Debug.Log("Rock entered: " + other.gameObject.name);
            AnswerCalculate.AddRock(scaleID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            Debug.Log("Rock exited: " + other.gameObject.name);
            AnswerCalculate.RemoveRock(scaleID);
        }
    }
}
