using UnityEngine;

public abstract class Fire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IFirePicker>(out IFirePicker firePicker))
        {
            if (other.gameObject.TryGetComponent<IHealable>(out IHealable healable))
            {
                AddHeal(healable);
                Destroy(gameObject);
            }

            AddCoin(firePicker);
        }
    }

    protected abstract void AddCoin(IFirePicker firePicker);

    protected abstract void AddHeal(IHealable healable);
}
