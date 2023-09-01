using UnityEngine;

public abstract class Fire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger entered with: {other.gameObject.name}");

        if (other.gameObject.TryGetComponent<IFirePicker>(out IFirePicker firePicker))
        {
            Debug.Log("IFirePicker found");

            if (other.gameObject.TryGetComponent<IHealable>(out IHealable healable))
            {
                Debug.Log("IHealable found");
                AddHeal(healable);
                Destroy(gameObject);
            }

            AddCoin(firePicker);
        }
    }

    protected abstract void AddCoin(IFirePicker firePicker);

    protected abstract void AddHeal(IHealable healable);
}
