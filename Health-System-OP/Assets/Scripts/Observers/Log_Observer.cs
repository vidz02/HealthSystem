using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Observer : MonoBehaviour, IHealthObserver
{
    [SerializeField]
    private Health playerHealth;

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
        Debug.Log("Game Over: Player has died.");
    }

    public void OnHealthChanged(HealthEventArgs args)
    {
        if (args.delta > 0)
        {
            Debug.Log($"Player health increased by {args.delta}.");
        }
        else
        {
            Debug.Log($"Player health decreased by {-args.delta}.");
        }
    }
}
