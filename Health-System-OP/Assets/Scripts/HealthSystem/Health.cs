using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealthSubject
{
    [SerializeField]
    private float maxHealth = 100;
    private float currentHealth;

    public event Action<float> HealthChanged;
    public event Action Death;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        if (amount <= 0 || currentHealth == 0) return;

        var previous = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        var delta = currentHealth - previous; // negative
        
        // Invoke the HealthChanged event with the change in health        
        HealthChanged?.Invoke(delta);
        
        // If health is 0 or less, invoke the Death event
        if (currentHealth <= 0)
            Death?.Invoke();
    }

    public void Heal(float amount)
    {
        if (amount <= 0 || currentHealth == maxHealth) return;

        var previous = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        var delta = currentHealth - previous; // positive

        // Invoke the HealthChanged event with the change in health        
        HealthChanged?.Invoke(delta);
    }
}
