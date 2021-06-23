using UnityEngine;
public class playerInteraction : Health
{

    [SerializeField] private AudioSource diePlayer;
    protected override void Start()
    {
        base.Start();
        _currentHealth = MaxHealth;


    }
    void Die()
    {
        Destroy(gameObject);

        diePlayer.Play(); //смерть
    }

    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
        //получение урона
    }
}
