using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;

    // Distance the doors should slide open
    public float slideDistance = 2f;

    // Speed at which the doors open
    public float openingSpeed = 5f;

    // Target positions
    private float leftOpenX;
    private float rightOpenX;

    // Flags
    private bool isOpening = false;

    private void Start()
    {
        // Store the target X positions for open doors
        if (leftDoor != null)
            leftOpenX = leftDoor.position.x - slideDistance; // Move left along X-axis
        if (rightDoor != null)
            rightOpenX = rightDoor.position.x + slideDistance; // Move right along X-axis
    }

    private void Update()
    {
        if (isOpening)
        {
            // Move the left door
            if (leftDoor != null)
            {
                Vector3 currentPosition = leftDoor.position;
                leftDoor.position = new Vector3(
                    Mathf.MoveTowards(currentPosition.x, leftOpenX, openingSpeed * Time.deltaTime),
                    currentPosition.y,
                    currentPosition.z
                );
            }

            // Move the right door
            if (rightDoor != null)
            {
                Vector3 currentPosition = rightDoor.position;
                rightDoor.position = new Vector3(
                    Mathf.MoveTowards(currentPosition.x, rightOpenX, openingSpeed * Time.deltaTime),
                    currentPosition.y,
                    currentPosition.z
                );
            }

            // Stop updating when both doors are fully open
            if ((leftDoor == null || Mathf.Approximately(leftDoor.position.x, leftOpenX)) &&
                (rightDoor == null || Mathf.Approximately(rightDoor.position.x, rightOpenX)))
            {
                isOpening = false;
            }
        }
    }

    public void OpenDoor()
    {
        Debug.Log("Opening sliding doors...");
        isOpening = true;
    }
}


