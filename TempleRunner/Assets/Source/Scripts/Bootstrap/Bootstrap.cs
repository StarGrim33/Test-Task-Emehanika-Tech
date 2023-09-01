using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private Player _player;
    [SerializeField] private UIScreenMediator _uiScreenMediator;
    private PlayerScore _playerScore;

    private void Awake()
    {
        PlayerScore firePicker = new();
        _player.Init(firePicker);
        _scoreView.Init(firePicker);
        _uiScreenMediator.Init(_playerHealth);
    }
}
