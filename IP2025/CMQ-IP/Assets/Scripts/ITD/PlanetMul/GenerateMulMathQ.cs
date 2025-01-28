using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GenerateMulMathQ : MonoBehaviour
{
    public MathQuestions MathQuestionGenerate; // Ref to MathQuestion Script
    public UIMathQuestion uiMathQuestion; // Reference to the UI script
    public AnswerCalculate AnswerCalculate;
    public AnswerChecker AnswerChecker;
    

    string question;
    int totalNum;
    int ans;
    List<int> numbers;

    public void GenerateMulQuestion()
    {
        MathQuestionGenerate.GenerateMathQuestion("x", 1, out question, out totalNum, out numbers, out ans); ;

        Debug.Log("Question: " + question);
        Debug.Log("TotalNum: " + totalNum);
        Debug.Log("Numbers: " + string.Join(", ", numbers));
        Debug.Log("Answer: " + ans);

        Debug.Log("b4 update");
        uiMathQuestion.updateVariable(question, totalNum, numbers, ans);
        Debug.Log("after update");

    }

    public int GetGeneratedAnswer()
    {
        return ans; // Return generated answer for external scripts
    }
}
