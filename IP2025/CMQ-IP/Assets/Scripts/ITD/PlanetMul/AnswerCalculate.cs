using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCalculate : MonoBehaviour
{
    public int RocksInScale1 = 0;
    public int RocksInScale2 = 0;
    public int Answer;

    public GenerateMulMathQ questionGenerator; // Reference to math question generator
    public AnswerChecker AnswerChecker;

    public void AddRock(string scaleID)
    {
        if (scaleID == "Scale1")
        {
            RocksInScale1++;
        }
        else if (scaleID == "Scale2")
        {
            RocksInScale2++;
        }

        Debug.Log($"Updated Counts - Scale1: {RocksInScale1}, Scale2: {RocksInScale2}");
        CalculateAnswer();
    }

    public void RemoveRock(string scaleID)
    {
        if (scaleID == "Scale1" && RocksInScale1 > 0)
        {
            RocksInScale1--;
        }
        else if (scaleID == "Scale2" && RocksInScale2 > 0)
        {
            RocksInScale2--;
        }

        Debug.Log($"Updated Counts - Scale1: {RocksInScale1}, Scale2: {RocksInScale2}");
        CalculateAnswer();
    }

    private void CalculateAnswer()
    {
        Answer = RocksInScale1 * RocksInScale2;
        AnswerChecker.CheckAnswer();
    }

}
