using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Observer : MonoBehaviour, IHealthObserver
{
    [SerializeField]
    private Health playerHealth;
    [SerializeField] 
    private TMP_Text healthText;

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
        // When the player dies, we can set the health text to 0%
        if (healthText != null) 
            healthText.text = "Health: 0%";
    }

    public void OnHealthChanged(HealthEventArgs args)
    {
        // Update the health text with the current health percentage
        if (healthText != null)
            healthText.text = "Health: " + args.current/args.max*100 + "%";
    }
}
