using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIMathQuestion : MonoBehaviour
{
    public TextMeshProUGUI answerText;

    private string question;
    private int totalNum;
    private List<int> numbers;
    private int ans;

    public void updateVariable(string newQuestion, int newTotalNum, List<int> newNumbers, int newAnswer)
    {
        question = newQuestion;
        totalNum = newTotalNum;
        numbers = newNumbers;
        ans = newAnswer;
    }

    public void updateUI()
    {
        answerText.text = ans.ToString();
    }

}