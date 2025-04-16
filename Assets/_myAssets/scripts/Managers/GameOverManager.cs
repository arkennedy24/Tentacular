using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;


public class GameOverManager : MonoBehaviour
{
	public float restartDelay = 5f;
		
	public Animator anim;                          // Reference to the animator component.
	float restartTimer;
    public FloatContainer health;
    public CollectedItems score;
    public IntContainer endScore;
    public GameObject WinCanvas;
    public GameObject LoseCanvas;
   
    void Start()
    {
        WinCanvas.SetActive(false);
        LoseCanvas.SetActive(false);
    }

    void Update ()
	{
		if(health.floatVariable <= 0)
        {
            GameOver();
        }

		if(score.score >= score.endScore )
		{
        Win();
		}
	}


    void GameOver()
    {
        
        restartTimer += Time.deltaTime;
        LoseCanvas.SetActive(true);

        if (restartTimer >= restartDelay)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Win()
{
    restartTimer += Time.deltaTime;
    WinCanvas.SetActive(true);
        
        
    if (restartTimer >= restartDelay)
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
}
