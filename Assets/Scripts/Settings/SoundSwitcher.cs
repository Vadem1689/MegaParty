using UnityEngine;
using UnityEngine.UI;

public class SoundSwitcher : MonoBehaviour
{
    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _on;
    [SerializeField] private Sprite _off;

    private int _defaultValue = 1;
    private int _currentValue;

    private void Awake()
    {
        _currentValue = PlayerPrefs.GetInt("Sound", _defaultValue);
        AudioListener.volume = _defaultValue;
        _soundImage.sprite = _currentValue == 1 ? _on : _off;
    }

    public void ChangeValue()
    {
        if (_currentValue == 1)
        {
            _currentValue = 0;
            SetValue(_currentValue);
        }
        else
        {
            _currentValue = 1;
            SetValue(_currentValue);
        }
    }

    private void SetValue(int value)
    {
        PlayerPrefs.SetInt("Sound", value);
        _soundImage.sprite = value == 1 ? _on : _off;
    }
}