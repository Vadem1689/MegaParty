using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _defaultvalue = 0;

    public event Action<int> BonusesChanged;

    public int CurrentBonuses { get; private set; }

    private void Start()
    {
        CurrentBonuses = PlayerPrefs.GetInt("Bonuses", _defaultvalue);
        BonusesChanged?.Invoke(CurrentBonuses);
    }

    public void Increase(int value)
    {
        if (value <= 0) return;

        CurrentBonuses += value;
        PlayerPrefs.SetInt("Bonuses", CurrentBonuses);
        BonusesChanged?.Invoke(CurrentBonuses);
    }

    public void Decrease(int value)
    {
        if (value <= 0) return;

        CurrentBonuses -= value;
        PlayerPrefs.SetInt("Bonuses", CurrentBonuses);
        BonusesChanged?.Invoke(CurrentBonuses);
    }
}