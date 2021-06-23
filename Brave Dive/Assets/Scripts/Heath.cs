using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [Header("Health")]
    public int MaxHealth = 3;
    protected int _currentHealth;

    public abstract void TakeDamage(int damage);

    protected virtual void Start()
    {
        _currentHealth = MaxHealth;
    }
}
