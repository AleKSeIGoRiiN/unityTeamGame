using UnityEngine;

public class EnemyInteraction : Health
{
    [SerializeField] private HeathBar _heathBar;

    protected override void Start()
    {
        base.Start();
        _heathBar.SetHeathValue(_currentHealth, MaxHealth);
    }
    void Die()
    {
        Destroy(gameObject);
    }
    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _heathBar.SetHeathValue(_currentHealth, MaxHealth);
        
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
}
