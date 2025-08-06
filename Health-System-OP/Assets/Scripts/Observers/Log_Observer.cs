using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Observer : MonoBehaviour, IHealthObserver
{
    [SerializeField]
    private Health healthSubject;

    private void OnEnable()
    {
        healthSubject.HealthChanged += OnHealthChanged;
        healthSubject.Death += OnDeath;
    }

    private void OnDisable()
    {
        healthSubject.HealthChanged -= OnHealthChanged;
        healthSubject.Death -= OnDeath;
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
        Debug.Log("Player has died.");
    }

    public void OnHealthChanged(float deltaHealth)
    {
        if (deltaHealth > 0)
        {
            Debug.Log($"Player health increased by {deltaHealth}.");
        }
        else
        {
            Debug.Log($"Player health decreased by {-deltaHealth}.");
        }
    }
}
