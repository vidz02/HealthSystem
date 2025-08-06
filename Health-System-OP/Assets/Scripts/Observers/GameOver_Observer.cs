using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Observer : MonoBehaviour, IHealthObserver
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

    }

    public void OnHealthChanged(float deltaHealth)
    {

    }
}
