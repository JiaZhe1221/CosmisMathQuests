using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickInteraction : MonoBehaviour
{
    public GameObject stickPoint; // Assign StickPoint in the Inspector
    public bool isActive = false; // Flag to track active state
    public int crystalElim = 0;

    public void TurnStickPointRed()
    {
        if (stickPoint != null)
        {
            Renderer renderer = stickPoint.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.red;
            }
        }
        isActive = true;
    }

    public void TurnStickPointWhite()
    {
        if (stickPoint != null)
        {
            Renderer renderer = stickPoint.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.white;
            }
        }
        isActive = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isActive && collision.gameObject.CompareTag("Crystal")) 
        { 
            Destroy(collision.gameObject);

            crystalElim ++;

            Debug.Log(crystalElim);
        }
    }

}
