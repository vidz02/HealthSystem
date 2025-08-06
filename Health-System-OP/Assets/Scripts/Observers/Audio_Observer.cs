using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Observer : MonoBehaviour, IHealthObserver
{
    [SerializeField]
    private Health playerHealth;
    
    [SerializeField]
	private AudioClip deathSound, damageSound, healSound;

	[SerializeField]
	private AudioSource audioSource;

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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDeath()
    {
        // When the player dies, we can play the death sound
        if (audioSource != null && deathSound != null)
            audioSource.PlayOneShot(deathSound);
    }

    public void OnHealthChanged(HealthEventArgs args)
    {
		if (audioSource == null) return;

        if (args.delta > 0)
        {
            // If health increased, play heal sound
            if (healSound != null)
                audioSource.PlayOneShot(healSound);
        }
        else if (damageSound != null)
            audioSource.PlayOneShot(damageSound);   // If health decreased, play damage sound
    }
}
