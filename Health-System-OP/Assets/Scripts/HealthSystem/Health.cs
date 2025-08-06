using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealthSubject
{
    [SerializeField]
    private float maxHealth = 100;
    private float currentHealth;

    public event Action<HealthEventArgs> HealthChanged;
    public event Action Death;

    private void Awake()
    {
        // Initialize current health to max health
        currentHealth = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        if (amount <= 0 || currentHealth == 0) return;

        var previous = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);  // Clamping ensures health doesn't go below 0

        // If health is 0 or less, invoke the Death event
        if (currentHealth <= 0)
            Death?.Invoke();
        else
        {
            var delta = currentHealth - previous; // negative
            // Invoke the HealthChanged event with decrease in health        
            HealthChanged?.Invoke(new HealthEventArgs(currentHealth, maxHealth, delta));
        }
    }

    public void Heal(float amount)
    {
        if (amount <= 0 || currentHealth == maxHealth) return;

        var previous = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);  // Clamping ensures health doesn't exceed max health

        var delta = currentHealth - previous; // positive
        // Invoke the HealthChanged event with increase in health        
        HealthChanged?.Invoke(new HealthEventArgs(currentHealth, maxHealth, delta));
    }
}
