using UnityEngine;

public class Player : MonoBehaviour, IFirePicker
{
    private IFirePicker _firePicker;

    private void Start()
    {
        _firePicker = new PlayerScore();
    }

    public void Add(int value) => _firePicker.Add(value);
}
