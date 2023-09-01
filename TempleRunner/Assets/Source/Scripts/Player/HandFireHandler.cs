using UnityEngine;

public class HandFireHandler : MonoBehaviour
{
    [SerializeField] private Light _handFire;
    [SerializeField] private PlayerHealth _health;

    private void OnEnable()
    {
        _health.OnHealthReduced += OnHealthReduced;
        _health.OnHealthAdded += OnHealthAdded;
    }

    private void OnDisable()
    {
        _health.OnHealthReduced -= OnHealthReduced;
        _health.OnHealthAdded -= OnHealthAdded;
    }


    private void OnHealthReduced()
    {
        _handFire.range -= 10;
        _handFire.intensity -= 0.3f;
    }

    private void OnHealthAdded()
    {
        _handFire.range += 10;
        _handFire.intensity += 0.3f;
    }
}
