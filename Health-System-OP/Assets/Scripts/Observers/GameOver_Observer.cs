using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Observer : MonoBehaviour, IHealthObserver
{
    [SerializeField]
    private Health playerHealth;

    [SerializeField]
    private GameObject gameOverImage;

    private void OnEnable()
    {
        playerHealth.HealthChanged += OnHealthChanged;
        playerHealth.Death += OnDeath;
    }

    private void OnDisable()
    {
        playerHealth.HealthChanged -= OnHealthChanged;
        playerHealth.Death -= OnDeath;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameOverImage != null)
            gameOverImage.SetActive(false); // ensure hidden at start
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDeath()
    {
        if (gameOverImage != null)
        {
            gameOverImage.SetActive(true); // show game over image
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        // Using a CanvasGroup component on the gameOverImage
        var canvasGroup = gameOverImage.GetComponent<CanvasGroup>();
        
        canvasGroup.alpha = 0f; // Start fully transparent
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime; 
            yield return null; // Wait for next frame
        }
    }

    public void OnHealthChanged(HealthEventArgs args)
    {

    }
}
