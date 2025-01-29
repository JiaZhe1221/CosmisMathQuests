using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    public AnswerCalculate AnswerCalculate;  // Reference to AnsCal script
    public GenerateMulMathQ questionGenerator; // Reference to question generator
    public Renderer[] childRenderers; // Array to hold multiple child renderers
    public Color neutralColor = Color.white; // Default color 

    private int currentCapIndex = 0; // Tracks which cap should change color

    private void Start()
    {
        // Get all Renderer components in child objects
        childRenderers = GetComponentsInChildren<Renderer>();

        if (childRenderers.Length > 0)
        {
            Debug.Log("Found " + childRenderers.Length + " renderers.");

            // Set all child renderers to white initially
            foreach (Renderer rend in childRenderers)
            {
                rend.material.color = neutralColor;
            }
        }
        else
        {
            Debug.LogError("No Renderers found in children! Ensure the objects have a MeshRenderer.");
        }
    }

    public void CheckAnswer()
    {
        if (AnswerCalculate == null || questionGenerator == null)
        {
            Debug.LogError("Missing reference to AnswerCalculate or GenerateMulMathQ!");
            return;
        }

        int playerAnswer = AnswerCalculate.Answer; // Get calculated answer from AnsCal
        int correctAnswer = questionGenerator.GetGeneratedAnswer(); // Get generated math answer

        Debug.Log("Player Answer (Rocks): " + playerAnswer);
        Debug.Log("Correct Answer: " + correctAnswer);

        if (currentCapIndex < childRenderers.Length) // Ensure index is within range
        {
            if (playerAnswer == correctAnswer)
            {
                Debug.Log("Correct! Turning Green.");
                childRenderers[currentCapIndex].material.color = Color.green;

                // Move to the next cap in sequence
                currentCapIndex++;
            }
            else
            {
                Debug.Log("Incorrect! Turning Red.");
                childRenderers[currentCapIndex].material.color = Color.red;
            }
        }
        else
        {
            Debug.Log("All caps have been checked.");
        }
    }
}
