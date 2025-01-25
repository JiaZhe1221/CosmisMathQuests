/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathQuestions : MonoBehaviour
{
    void Start()
    {
        string question;
        int totalNum;
        int ans;
        List<int> numbers;

        GenerateMathQuestion("+", 1, out question, out totalNum, out numbers, out ans);


        Debug.Log("Question: " + question);
        Debug.Log("TotalNum: " + totalNum);
        Debug.Log("Numbers: " + string.Join(", ", numbers));
        Debug.Log("Answer: " + ans);
    }

    void GenerateMathQuestion(string operation, int level, out string question, out int totalNum, out List<int> numbers, out int ans)
    {
        totalNum = Random.Range(2, Mathf.Min(5, level + 2));
        numbers = new List<int>();

        for (int i = 0; i < totalNum; i++)
        {
            int range = Mathf.Clamp(level * 5, 1, 50);
            numbers.Add(Random.Range(1, range + 1));
        }

        question = string.Join(" " + operation + " ", numbers.ConvertAll(n => n.ToString()).ToArray());

        ans = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            switch (operation)
            {
                case "+":
                    ans += numbers[i];
                    break;
                case "-":
                    ans -= numbers[i];
                    break;
                case "x":
                    ans *= numbers[i];
                    break;
                case "/":
                    if (numbers[i] != 0)
                    {
                        ans /= numbers[i];
                    }
                    break;
                default:
                    Debug.LogError("Invalid operation!");
                    break;
            }
        }
    }
}
*/