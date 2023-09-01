using System;
using UnityEngine;

public class PlayerScore : IFirePicker
{
    public int Score { get; private set; }

    public void Add(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Score += value;
        Debug.Log($"Current bank is {Score}");
    }
}
