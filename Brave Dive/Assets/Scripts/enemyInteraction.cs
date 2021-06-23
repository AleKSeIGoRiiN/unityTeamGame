using UnityEngine;

public class EnemyInteraction : Health
{
    [SerializeField] private HeathBar _heathBar;
    [SerializeField] private AudioSource dieEnemy;
    [SerializeField] private AudioSource damageEnemy;

    protected override void Start()
    {
        base.Start();
        _heathBar.SetHeathValue(_currentHealth, MaxHealth);
    }
    void Die()
    {
        Destroy(gameObject);

        dieEnemy.Play(); //смерть
    }
    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _heathBar.SetHeathValue(_currentHealth, MaxHealth);
        damageEnemy.Play(); //получение урона

        if (_currentHealth <= 0)
        {
            Die();
        }
    }
}
