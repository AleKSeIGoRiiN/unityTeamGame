public class playerInteraction : Health
{

    protected override void Start()
    {
        base.Start();
        _currentHealth = MaxHealth;


    }
    void Die()
    {
        Destroy(gameObject);
    }

    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
}
