using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    public TriggerAreaScales triggerArea;  // Reference to TriggerAreaScales script
    public GenerateMulMathQ questionGenerator; // Reference to question generator
    private Renderer childRenderer; // Renderer to change object color
    public Color neutralColor = Color.white; // Default color 
    private void Start()
    {
        // Search recursively for the first Renderer in children
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        if (renderers.Length > 0)
        {
            childRenderer = renderers[0]; // Take the first Renderer found
            Debug.Log("Renderer found on: " + childRenderer.gameObject.name);
            // **Set initial neutral color**
            childRenderer.material.color = neutralColor;
        }
        else
        {
            Debug.LogError("No Renderer found in children! Ensure the cube has a MeshRenderer.");
        }
    }

    public void CheckAnswer()
    {
        if (triggerArea == null || questionGenerator == null)
        {
            Debug.LogError("Missing reference to TriggerAreaScales or GenerateMulMathQ!");
            return;
        }

        int playerAnswer = triggerArea.Answer; // Get calculated answer from TriggerAreaScales
        int correctAnswer = questionGenerator.GetGeneratedAnswer(); // Get generated math answer

        Debug.Log("Player Answer (Rocks): " + playerAnswer);
        Debug.Log("Correct Answer: " + correctAnswer);

        if (playerAnswer == correctAnswer)
        {
            Debug.Log("Correct! Turning Green.");
            ChangeChildColor(Color.green);
        }
        else
        {
            Debug.Log("Incorrect! Turning Red.");
            ChangeChildColor(Color.red);
        }
    }

    void ChangeChildColor(Color color)
    {
        if (childRenderer != null)
        {
            childRenderer.material.color = color;
            Debug.Log("Changed color to: " + color);
        }
        else
        {
            Debug.LogError("Renderer is missing! Ensure the cube has a MeshRenderer.");
        }
    }
}
