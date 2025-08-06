using System;

public interface IHealthSubject
{
    public event Action<float> HealthChanged;
    public event Action Death;

    void TakeDamage(float amount);
    void Heal(float amount);
}
