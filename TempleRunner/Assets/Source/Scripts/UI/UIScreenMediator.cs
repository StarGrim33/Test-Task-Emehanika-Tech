using UnityEngine;

public class UIScreenMediator : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen;
    private PlayerHealth _health;

    public void Init(PlayerHealth health)
    {
        _health = health;
        _health.PlayerDead += OnPlayerDead;
    }

    private void OnDisable()
    {
        _health.PlayerDead -= OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        _deathScreen.SetActive(true);
    }
}
