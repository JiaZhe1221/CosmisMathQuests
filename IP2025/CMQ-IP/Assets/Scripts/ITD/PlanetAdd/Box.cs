using TMPro;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Target weight to solve the puzzle
    public float targetWeight = 50f;

    // Current weight in the box
    private float currentWeight = 0f;

    // Whether the puzzle is already completed
    private bool isPuzzleCompleted = false;

    // TextMeshPro to display weight information
    public TextMeshProUGUI weightDisplay;

    // Reference to the Door script
    public Door door;

    private void Start()
    {
        UpdateWeightDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPuzzleCompleted) return;

        // Get the weight associated with the object's tag
        float objectWeight = GetWeightFromTag(other.tag);
        if (objectWeight > 0)
        {
            currentWeight += objectWeight;
            Debug.Log($"Object added: {objectWeight}Kg. Current Weight: {currentWeight}Kg");

            // Update the display
            UpdateWeightDisplay();

            // Check if the puzzle is solved
            if (Mathf.Approximately(currentWeight, targetWeight))
            {
                CompletePuzzle();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPuzzleCompleted) return;

        // Subtract the weight of the removed object
        float objectWeight = GetWeightFromTag(other.tag);
        if (objectWeight > 0)
        {
            currentWeight -= objectWeight;
            Debug.Log($"Object removed: {objectWeight}Kg. Current Weight: {currentWeight}Kg");

            // Update the display
            UpdateWeightDisplay();
        }
    }

    // Maps tags to their corresponding weights
    private float GetWeightFromTag(string tag)
    {
        switch (tag)
        {
            case "1Kg": return 1f;
            case "5Kg": return 5f;
            case "10Kg": return 10f;
            case "20Kg": return 20f;
            default: return 0f; // Return 0 for unknown tags
        }
    }

    // Called when the puzzle is completed
    private void CompletePuzzle()
    {
        isPuzzleCompleted = true;
        Debug.Log("Puzzle Completed! Correct weight reached.");
        UpdateWeightDisplay();

        // Call the OpenDoor function on the Door script
        if (door != null)
        {
            door.OpenDoor();
        }
        else
        {
            Debug.LogWarning("Door script is not assigned!");
        }
    }

    // Updates the TextMeshPro display with current and target weights
    private void UpdateWeightDisplay()
    {
        if (weightDisplay != null)
        {
            weightDisplay.text = $"Target Weight: {targetWeight}Kg\nCurrent Weight: {currentWeight}Kg";
        }
    }
}


