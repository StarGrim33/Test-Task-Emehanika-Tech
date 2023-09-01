using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private HealthBarView _healthBar;

    private void Awake()
    {
        //_mediator.Init(levelSystem, _playerHealth);
        //_healthBar.Init(levelSystem, _playerHealth);
    }
}
