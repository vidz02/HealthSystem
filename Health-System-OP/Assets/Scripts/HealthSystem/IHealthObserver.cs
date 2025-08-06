public interface IHealthObserver
{
    /// <summary>
    /// Called when the health of the subject changes.
    /// </summary>
    /// <param name="deltaHealth">The change in health value.</param>
    void OnHealthChanged(float deltaHealth);
    /// <summary>
    /// Called when the subject dies.
    /// </summary>
    void OnDeath();
}
