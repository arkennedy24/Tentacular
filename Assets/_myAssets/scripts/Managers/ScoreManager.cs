using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


	public class ScoreManager : MonoBehaviour
	{
    public FloatContainer currentHealth;                        // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    //Animator anim;                                            // Reference to the Animator component.
    bool isDead;                                                // Whether the player is dead.
    public static bool damaged;                                 // True when the player gets damaged.

	public CollectedItems scoreSystem;
	public TextMeshProUGUI scoreText;
		
		
	void Awake ()
	{
        // Set up the reference.
        //scoreText = GetComponent <TMPro.TextMeshProUGUI> ();
        			
		// Reset the score.
		scoreSystem.score = scoreSystem.resetScore;
    
        //playerAudio = GetComponent<AudioSource>();

        // Set the initial health of the player.
        currentHealth.floatVariable = currentHealth.resetFloatVariable;
    }


		void Update ()
		{
            //set the slider to match the health
            healthSlider.value = currentHealth.floatVariable;
            // If the player has just been damaged...
            if (damaged)
            {
                 //... set the colour of the damageImage to the flash colour.
                damageImage.color = flashColour;
            }
            // Otherwise...
            else
            {
                 //... transition the colour back to clear.
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

            // Reset the damaged flag.
            damaged = false;

            // Set the displayed text to be the word "Score" followed by the score value.
            scoreText.text = "SCOREs: " + scoreSystem.score;
		}
        
        void Death()
        {
            // Set the death flag so this function won't be called again.
            isDead = true;
        }
    }
