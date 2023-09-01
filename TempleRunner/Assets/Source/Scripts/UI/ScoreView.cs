using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    
    private PlayerScore _score;

    private void OnDisable()
    {
        _score.OnPlayerScoreChange -= OnPlayerScoreChange;
    }

    private void Start()
    {
        _scoreText.text = "Score: 0";
    }

    public void Init(PlayerScore score)
    {
        _score = score;
        _score.OnPlayerScoreChange += OnPlayerScoreChange;
    }

    private void OnPlayerScoreChange(int value)
    {
        string text = "Score:" + _score.Score.ToString();
        _scoreText.text = text;
    }
}
