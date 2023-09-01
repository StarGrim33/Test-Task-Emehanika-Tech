using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageable, IHealable
{
    private int _maxHealth = 3;
    private int _currenHealth;

    public event UnityAction OnHealthReduced;

    public event UnityAction OnHealthAdded;

    public event UnityAction PlayerDead;

    public int MaxHealth 
    {
        get
        { 
            return _maxHealth;
        }

        private set
        {
            _maxHealth = value;
        } 
    }

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

    private void Awake()
    {
        _currenHealth = _maxHealth;
        Debug.Log($"Health is {CurrentHealth}");
    }

    private void Die()
    {
        //_animator.SetTrigger(Constants.DeadState);
        GameStateHandler.Instance.SetState(GameState.Pause);
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
        if (CurrentHealth < MaxHealth)
        {
            CurrentHealth += 1;
            OnHealthAdded?.Invoke();
        }
    }
}
