using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSubMathQuestion : MonoBehaviour
{
    public MathQuestions MathQuestions;
    public UIMathQuestion UiMathQuestion;
    public GameObject objectPrefab; // Assign your prefab in the Inspector
    public Transform spawnArea; // Define the area where objects should spawn

    string question;
    int totalNum;
    int ans;
    List<int> numbers;

    private void Start()
    {
        GenerateSubQuestion();
        UiMathQuestion.updateUI();
    }

    public void GenerateSubQuestion()
    {
        MathQuestions.GenerateMathQuestion("+", 1, out question, out totalNum, out numbers, out ans);

        Debug.Log("Question: " + question);
        Debug.Log("TotalNum: " + totalNum);
        Debug.Log("Numbers: " + string.Join(", ", numbers));
        Debug.Log("Answer: " + ans);

        Debug.Log("b4 update");
        UiMathQuestion.updateVariable(question, totalNum, numbers, ans);
        Debug.Log("after update");

        SpawnObjects();
    }

    public int GetGeneratedAnswer()
    {
        return ans; // Return generated answer for external scripts
    }

    private void SpawnObjects()
    {
        int spawnCount = ans + Random.Range(2,5); // Ensures count is more than ans
        Debug.Log("Spawning " + spawnCount);

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        if (spawnArea != null)
        {
            Vector3 spawnCenter = spawnArea.position; // Center of the spawn area
            Vector3 spawnSize = spawnArea.localScale; // Size of the spawn area

            float x = Random.Range(spawnCenter.x - spawnSize.x / 2, spawnCenter.x + spawnSize.x / 2);
            float y = Random.Range(spawnCenter.y - spawnSize.y / 2, spawnCenter.y + spawnSize.y / 2);
            float z = Random.Range(spawnCenter.z - spawnSize.z / 2, spawnCenter.z + spawnSize.z / 2);

            return new Vector3(x, y, z);
        }
        else
        {
            return new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
        }
    }
}
