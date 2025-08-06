public interface IHealthObserver
{
    /// <summary>
    /// Called when the health of the player changes.
    /// </summary>
    /// <param name="args">Health event arguments whenever there is a change in health value.</param>
    void OnHealthChanged(HealthEventArgs args);
    /// <summary>
    /// Called when the player dies.
    /// </summary>
    void OnDeath();
}
