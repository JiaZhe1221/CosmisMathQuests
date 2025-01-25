/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathQuestions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Example usage
        public string question;
        public int totalNum;
        public int ans;
        public List<int> numbers;

        GenerateMathQuestion("+", 1, out question, out totalNum, out numbers, out ans);

        Debug.Log("Question: " + question);
        Debug.Log("TotalNum: " + totalNum);
        Debug.Log("Numbers: " + string.Join(", ", numbers));
        Debug.Log(numbers[1]);
        Debug.Log("Answer: " + ans);
       

    }

    // Function to generate math questions based on operation and difficulty level
    void GenerateMathQuestion(string operation, int level, out string question, out int totalNum, out List<int> numbers, out int ans)
    {
        // Determine the number of operands based on the level (max 4 operands)
        totalNum = Random.Range(2, Mathf.Min(5, level + 2)); // level 1 -> 2 operands, level 5 -> max 4 operands
        numbers = new List<int>();

        // Generate random numbers based on the level
        for (int i = 0; i < totalNum; i++)
        {
            // Number range increases with difficulty
            int range = Mathf.Clamp(level * 5, 1, 50);  // Range depends on level, e.g., level 1 -> 5, level 5 -> 25
            numbers.Add(Random.Range(1, range + 1));  // Random number between 1 and range
        }

        // Generate the math question string
        question = string.Join(" " + operation + " ", numbers.ConvertAll(n => n.ToString()).ToArray());

        // Calculate the answer based on the operation
        ans = numbers[0]; // Start with the first number
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
                    // Ensure no division by zero
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