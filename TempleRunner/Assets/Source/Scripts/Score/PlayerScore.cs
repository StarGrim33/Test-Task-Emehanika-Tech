using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : IFirePicker
{
    public event UnityAction<int> OnPlayerScoreChange;

    public int Score { get; private set; }

    public void Add(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Score += value;
        OnPlayerScoreChange?.Invoke(Score);
        Debug.Log($"Current bank is {Score}");
    }
}
