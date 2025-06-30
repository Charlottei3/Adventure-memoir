using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currenHealth;
    private bool _isDie;

    [SerializeField] private Slider _healthBar;

    public int MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }

    public int CurrenHealth
    {
        get { return _currenHealth; }
        set { _currenHealth = Mathf.Min(0, Mathf.Max(0, _maxHealth)); }
    }

    public bool IsDie
    {
        get => _isDie;
        set => _isDie = _currenHealth <= 0;
    }
    void Start()
    {
        _currenHealth = _maxHealth;
    }

    public void UpdateHealth(int value)
    {
        CurrenHealth -= value;
    }
}
