using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrigAreaAnsCheck : MonoBehaviour
{  // if ans = spawnobj in generatesubmathq - crystalelim in stickinteraction correct ans true 
    public GenerateSubMathQuestion GenerateSubMathQuestion;
    public StickInteraction StickInteraction;

    public int amountOfCrystal;
    public bool AnsCheck = false;

    public List<GameObject> crystalsInTrigger = new List<GameObject>(); 

    public void CheckAnswer()
    {
        if (GenerateSubMathQuestion.spawnObj - StickInteraction.crystalElim == GenerateSubMathQuestion.ans)
        {
            AnsCheck = true;
            Debug.Log("Ans become correct");
            amountOfCrystal = GenerateSubMathQuestion.spawnObj - StickInteraction.crystalElim;
            Debug.Log("Crystal Amount: " + amountOfCrystal + " :Ans: " + GenerateSubMathQuestion.ans);

        }
        else
        {
            AnsCheck = false;
            Debug.Log("Ans become wrong");
        }
    }

    public void RestartLevel()
    {
        Debug.Log("Crystals in Trigger Area: " + crystalsInTrigger.Count);

        if (crystalsInTrigger.Count == 0)
        {
            Debug.LogWarning("No crystals detected in the trigger area!");
        }

        // Loop through all objects in the list
        for (int i = 0; i < crystalsInTrigger.Count; i++)
        {
            GameObject crystal = crystalsInTrigger[i];

            if (crystal != null)
            {
                Debug.Log("Destroying: " + crystal.name + " | Position: " + crystal.transform.position);
                Destroy(crystal);
            }
            else
            {
                Debug.LogWarning("A crystal reference is NULL! It may have been destroyed elsewhere.");
            }
        }

        // Clear list after destroying objects
        crystalsInTrigger.Clear();

        // Restart Level Mechanics
        GenerateSubMathQuestion.GenerateSubQuestion();
        GenerateSubMathQuestion.UiMathQuestion.updateUI();
        StickInteraction.crystalElim = 0;

        Debug.Log("RestartLevel() complete.");
    }
}