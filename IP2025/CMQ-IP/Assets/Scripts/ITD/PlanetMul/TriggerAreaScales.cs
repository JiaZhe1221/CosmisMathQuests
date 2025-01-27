using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerAreaScales : MonoBehaviour
{
    public string ScaleID;
    
    public int RocksInScale1 = 0;
    public int RocksInScale2 = 0;
    public int Answer;
    public AnswerChecker check;

    private void Start()
    {
        Debug.Log(RocksInScale1);
    }

    private void MulAns()
    {
         Answer = RocksInScale1 * RocksInScale2;
         check.CheckAnswer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            Debug.Log("Rock entered: " + other.gameObject.name);
            Debug.Log("Rock detected");
            if (ScaleID == "Scale1")
            {
                RocksInScale1++;
                Debug.Log("Add RockInScale1: " + RocksInScale1);
            }
            else if (ScaleID == "Scale2")
            {
                RocksInScale2++;
                Debug.Log("Add RockInScale2: " + RocksInScale2);
            }

            MulAns();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            Debug.Log("Rock detected");
            if (ScaleID == "Scale1")
            {
                RocksInScale1--;
                Debug.Log("Minused RockInScale1: " + RocksInScale1);
            }
            else if (ScaleID == "Scale2")
            {
                RocksInScale2--;
                Debug.Log("Minused RockInScale2: " + RocksInScale2);
            }

            MulAns();
        }
    }

}
