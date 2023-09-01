using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    protected int _maxHealth;
    protected int _currenHealth;

    protected void OnEnable()
    {
        _currenHealth = 3;
        _maxHealth = 3;
    }

    protected virtual void Die() { }
}
