using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : UnitHealth, IDamageable, IHealable
{
    public event UnityAction OnHealthReduced;

    public event UnityAction OnHealthAdded;

    public event UnityAction PlayerDead;

    public int MaxHealth { get; private set; } = 3;

    public int CurrentHealth
    {
        get
        {
            return _currenHealth;
        }
        private set
        {
            _currenHealth = Mathf.Clamp(value, 0, _maxHealth);

            if (_currenHealth <= 0)
                Die();
        }
    }

    protected override void Die()
    {
        //_animator.SetTrigger(Constants.DeadState);
        //StateManager.Instance.SetState(GameStates.Paused);
        PlayerDead?.Invoke();
    }

    public void TakeDamage()
    {
        CurrentHealth -= 1;
        OnHealthReduced?.Invoke();
        Debug.Log($"Health is {CurrentHealth}");
    }

    public void AddHealth()
    {
        ++CurrentHealth;
        OnHealthAdded?.Invoke();
        Debug.Log($"Health is {CurrentHealth}");
    }
}
