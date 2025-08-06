using System;

public interface IHealthSubject
{
    /// <summary>
    /// Allows observers to subscribe to player's health changes.
    /// Uses HealthEventArgs to provide details about the health change.
    /// </summary>
    public event Action<HealthEventArgs> HealthChanged;

    /// <summary>
    /// Allows observers to subscribe to player's death event.
    /// </summary>
    public event Action Death;

    /// <summary>
    /// Deals specific amount of damage to the player.
    /// </summary>
    void TakeDamage(float amount);

    /// <summary>
    /// Heals the player by a specified amount.
    /// </summary>
    void Heal(float amount);
}
