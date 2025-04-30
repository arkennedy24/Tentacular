
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class BreakerBoxFix : MonoBehaviour
{
    public ParticleSystem sparks; 
    public Animator animator; 
    public TextMeshProUGUI interactionText; 
    public Camera playerCamera; 
    private bool isFixed = false;
    public float fixTime = 3f; 
    private float currentFixTime = 0f; 
	public CollectedItems score;
    void Update()
    {
        
        if (Input.GetKey(KeyCode.E) && !isFixed && IsLookingAtBreakerBox())
        {
            currentFixTime += Time.deltaTime; 
            Debug.Log("Breaker Box Fix Progress: " + (currentFixTime / fixTime) * 100 + "%");

           
            if (currentFixTime >= fixTime)
            {
                FixBreakerBox();
            }
        }
        else
        {
            
            currentFixTime = 0f;
        }
    }

    bool IsLookingAtBreakerBox()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }
        return false;
    }

    void FixBreakerBox()
    {
        isFixed = true;
		score.score += 1;

        // Play fixing animation
        // animator.SetTrigger("Fix");

       
        sparks.Stop();
        Debug.Log("Breaker Box Sparks should be stopped now.");

        Debug.Log("Breaker Box Fully Fixed!");

       
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
