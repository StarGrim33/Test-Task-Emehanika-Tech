using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private List<Image> _heartsList;
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnEnable()
    {
        _playerHealth.OnHealthReduced += OnHealthReduced;
        _playerHealth.OnHealthAdded += OnHealthAdded;
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthReduced -= OnHealthReduced;
        _playerHealth.OnHealthAdded -= OnHealthAdded;
    }

    private void Start()
    {
        SetStartHealth();
    }

    private void OnHealthReduced()
    {
        ReduceHearts();
    }

    private void OnHealthAdded()
    {
        AddHearts();
    }

    private void SetStartHealth()
    {
        for (int i = 0; i < _playerHealth.MaxHealth; i++)
        {
            GameObject heart = Instantiate(_heartPrefab, this.transform);
            _heartsList.Add(heart.GetComponent<Image>());
        }
    }

    private void ReduceHearts()
    {
        int heartFill = _playerHealth.CurrentHealth;

        for (int i = 0; i < _heartsList.Count; i++)
        {
            _heartsList[i].fillAmount = i < heartFill ? 1 : 0;
        }
    }

    private void AddHearts()
    {
        int heartFill = _playerHealth.CurrentHealth;

        for (int i = 0; i < _heartsList.Count; i++)
        {
            _heartsList[i].fillAmount = i < heartFill ? 1 : 0;
        }
    }
}
