using TMPro;
using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour
{
    // Platform and arrow
    public Transform scalePlatform;
    public Transform weightArrow;

    // TextMeshPro to display weight information
    public TextMeshProUGUI weightDisplay;

    // Original position of the scale and arrow
    public Vector3 originalScalePosition;
    public Vector3 originalArrowPosition;

    // Target positions for the scale (only y-axis will change)
    public Vector3 positionFor1Kg;
    public Vector3 positionFor5Kg;
    public Vector3 positionFor10Kg;
    public Vector3 positionFor20Kg;

    // Target positions for the arrow (only y-axis will change, opposite direction)
    public Vector3 arrowPositionFor1Kg;
    public Vector3 arrowPositionFor5Kg;
    public Vector3 arrowPositionFor10Kg;
    public Vector3 arrowPositionFor20Kg;

    // Speed at which the scale and arrow move
    public float moveSpeed = 2f;

    // Current weight on the scale
    private float currentWeight = 0f;

    private Vector3 targetScalePosition;
    private Vector3 targetArrowPosition;
    private Coroutine scaleMoveCoroutine;
    private Coroutine arrowMoveCoroutine;

    private void Start()
    {
        // Set the starting positions for the scale and arrow
        if (scalePlatform != null)
        {
            scalePlatform.position = originalScalePosition;
        }
        if (weightArrow != null)
        {
            weightArrow.position = originalArrowPosition;
        }

        // Initialize target positions
        targetScalePosition = originalScalePosition;
        targetArrowPosition = originalArrowPosition;

        // Update the display
        UpdateWeightDisplay();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Get the weight associated with the object's tag when in contact
        float objectWeight = GetWeightFromTag(collision.gameObject.tag);
        if (objectWeight > 0)
        {
            currentWeight += objectWeight;
            Debug.Log($"Object added: {objectWeight}Kg. Current Weight: {currentWeight}Kg");

            // Update the target positions for scale and arrow
            SetTargetPositions(objectWeight);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Subtract the weight of the object when it leaves the scale
        float objectWeight = GetWeightFromTag(collision.gameObject.tag);
        if (objectWeight > 0)
        {
            currentWeight -= objectWeight;
            Debug.Log($"Object removed: {objectWeight}Kg. Current Weight: {currentWeight}Kg");

            // Reset the target positions to original
            SetTargetPositions(0);
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

    // Set the target positions for the scale and arrow
    private void SetTargetPositions(float weight)
    {
        switch (weight)
        {
            case 1f:
                targetScalePosition = positionFor1Kg;
                targetArrowPosition = arrowPositionFor1Kg;
                break;
            case 5f:
                targetScalePosition = positionFor5Kg;
                targetArrowPosition = arrowPositionFor5Kg;
                break;
            case 10f:
                targetScalePosition = positionFor10Kg;
                targetArrowPosition = arrowPositionFor10Kg;
                break;
            case 20f:
                targetScalePosition = positionFor20Kg;
                targetArrowPosition = arrowPositionFor20Kg;
                break;
            default:
                targetScalePosition = originalScalePosition;
                targetArrowPosition = originalArrowPosition;
                break;
        }

        // Stop any currently running Coroutines
        if (scaleMoveCoroutine != null)
        {
            StopCoroutine(scaleMoveCoroutine);
        }
        if (arrowMoveCoroutine != null)
        {
            StopCoroutine(arrowMoveCoroutine);
        }

        // Start new Coroutines to move the platform and arrow
        scaleMoveCoroutine = StartCoroutine(MoveToTarget(scalePlatform, targetScalePosition));
        arrowMoveCoroutine = StartCoroutine(MoveToTarget(weightArrow, targetArrowPosition));
    }

    // Coroutine to smoothly move a transform to a target position
    private IEnumerator MoveToTarget(Transform obj, Vector3 targetPos)
    {
        while (Vector3.Distance(obj.position, targetPos) > 0.01f)
        {
            obj.position = Vector3.MoveTowards(
                obj.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            yield return null; // Wait for the next frame
        }

        // Ensure the object exactly reaches the target position
        obj.position = targetPos;
    }

    // Updates the TextMeshPro display with the current weight
    private void UpdateWeightDisplay()
    {
        if (weightDisplay != null)
        {
            weightDisplay.text = $"Current Weight: {currentWeight}Kg";
        }
    }
}

