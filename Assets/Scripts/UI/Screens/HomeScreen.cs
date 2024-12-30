using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class HomeScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _date;
    [SerializeField] private TMP_Text _name;

    private void OnEnable()
    {
        UpdateDateText();
    }

    private void UpdateDateText()
    {
        DateTime currentDate = DateTime.Now;
        CultureInfo culture = new CultureInfo("en-US");
        string formattedDate = currentDate.ToString("dddd, d MMMM", culture);
        _date.text = formattedDate;

        if (_name != null)
            _name.text = $"HI {PlayerPrefs.GetString("Name", "Anonymous")}";
    }
}