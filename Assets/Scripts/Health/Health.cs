public class Health
{
    private float _maxHealth;
    private float _currentHealth;

    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;

        _currentHealth = _maxHealth;
    }

    public float MaxHealth => _maxHealth;

    public float CurrentHealth => _currentHealth;

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;
    }
}
