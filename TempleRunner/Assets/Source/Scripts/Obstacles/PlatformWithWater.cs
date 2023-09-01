using UnityEngine;

public class PlatformWithWater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamageable>(out IDamageable component))
        {
            component.TakeDamage();
        }
    }
}
