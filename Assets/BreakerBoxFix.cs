
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this to use TextMeshPro

public class BreakerBoxFix : MonoBehaviour
{
    public ParticleSystem sparks; // Reference to sparking effect
   public Animator animator; // Reference to animation
    public TextMeshProUGUI interactionText; // Reference to TextMeshPro UI element

    private bool isFixed = false;
    public float fixTime = 3f; // Time required to fix the breaker box
    private float currentFixTime = 0f; // Tracks fixing progress

    void Update()
    {
        // Check if player is holding 'E' key
        if (Input.GetKey(KeyCode.E) && !isFixed)
        {
            currentFixTime += Time.deltaTime; // Progressively increase the fix time
            Debug.Log("Fix Progress: " + (currentFixTime / fixTime) * 100 + "%");

            // When fix time is reached, finalize repair
            if (currentFixTime >= fixTime)
            {
                FixBreakerBox();
            }
        }
        else
        {
            // Reset progress if player stops holding 'E'
            currentFixTime = 0f;
        }
    }

    void FixBreakerBox()
    {
        isFixed = true;

        // Play fixing animation
       // animator.SetTrigger("Fix");

        // Stop sparking effect
        sparks.Stop();
        Debug.Log("Sparks should be stopped now.");

        Debug.Log("Breaker Box Fully Fixed!");

        // Hide interaction text
        interactionText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFixed)
        {
            Debug.Log("Press and hold E to fix the breaker box.");
            interactionText.text = "Press and hold E to fix the breaker box.";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.text = "";
        }
    }
}
