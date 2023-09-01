using UnityEngine;

public class Player : MonoBehaviour, IFirePicker
{
    private IFirePicker _firePicker;

    public void Add(int value) => _firePicker.Add(value);

    public void Init(IFirePicker firePicker)
    {
        _firePicker = firePicker;
    }
}
