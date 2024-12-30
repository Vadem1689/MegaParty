using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelTimer : MonoBehaviour
{
    [SerializeField] private SpeenButton _spinButton;
    
    [SerializeField] private Button[] _buttonSpin;
    [SerializeField] private TMP_Text _timeRemainingText;
    [SerializeField] private GameObject _canSpin;
    [SerializeField] private GameObject _nextSpin;
    
    private DateTime _lastTimesSpin;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("LastSpin"))
        {
            string key = "LastPressTime";
            string lastPressTimeString = PlayerPrefs.GetString(key);
            _lastTimesSpin = DateTime.Parse(lastPressTimeString);
            CheckButtonAvailability();
        }
        else
        {
            _lastTimesSpin = DateTime.MinValue;
        }
    }

    private void Update()
    {
        string timing = PlayerPrefs.GetString("LastPressTime");

        if (!string.IsNullOrEmpty(timing))
        {
            DateTime tim;
            if (DateTime.TryParse(timing, out tim))
            {
                // TimeSpan remainingTime = TimeSpan.FromSeconds(15) - (DateTime.Now - tim);
                TimeSpan remainingTime = TimeSpan.FromHours(24) - (DateTime.Now - tim);
                if (remainingTime <= TimeSpan.Zero)
                {
                    CheckButtonAvailability();
                    _timeRemainingText.text = "Готово к вращению!";
                }
                else
                {
                    _timeRemainingText.text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                        remainingTime.Hours,
                        remainingTime.Minutes,
                        remainingTime.Seconds);
                }
            }
            else
            {
                Debug.LogError("Не удалось преобразовать строку в DateTime: " + timing);
            }
        }
    }

    private  void CheckButtonAvailability()
    {
        string key = "LastPressTime";

        if (PlayerPrefs.HasKey(key))
        {
            string timing = PlayerPrefs.GetString("LastPressTime");
            DateTime tim;

            if (DateTime.TryParse(timing, out tim))
            {
                // if (DateTime.Now - tim >= TimeSpan.FromSeconds(15))
                if (DateTime.Now - tim >= TimeSpan.FromHours(24))
                {
                    
                    // Debug.Log("Подхз/одит");
                    _canSpin.SetActive(true);
                    _nextSpin.SetActive(false);
                    
                    /*foreach (var button in buttonSpin)
                        button.interactable = true;*/
                    
                    // _spinButton.ActivateButton();
                    _spinButton.GetComponent<Button>().interactable = true;
                }
                else
                {
                    // Debug.Log("Не подхзодит");
                    _canSpin.SetActive(false);
                    _nextSpin.SetActive(true);
                    
                    // _spinButton.DeactivateButton();
                    _spinButton.GetComponent<Button>().interactable = false;

                    /*foreach (var button in buttonSpin)
                        button.interactable = false;*/
                }
            }
        }
        else
        {
            foreach (var button in _buttonSpin)
                button.interactable = true;
        }
    }

    public void OnButtonClick()
    {
        _lastTimesSpin = DateTime.Now;
        PlayerPrefs.SetString("LastPressTime", DateTime.Now.ToString());
        PlayerPrefs.SetString("LastSpin", "крути");
        PlayerPrefs.Save();

        _canSpin.SetActive(false);
        _nextSpin.SetActive(true);
        _spinButton.DeactivateButton();
        
        foreach (var button in _buttonSpin)
            button.interactable = false;
    }
}
