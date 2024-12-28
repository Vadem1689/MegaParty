using UnityEngine;
using UnityEngine.UI;

public class TodayPlanButton : AbstractButton
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _off;
    [SerializeField] private Sprite _on;
    [SerializeField] private GameObject _todayPlan;

    private int _default = 1;
    private bool _isActive = false;

    private void Start()
    {
        int value = PlayerPrefs.GetInt("TodayPlan", _default);
        ChangeValue(value > 0);
    }

    private void ChangeValue(bool value)
    {
        _isActive = value;
        _image.sprite = value ? _on : _off;
        _todayPlan.SetActive(value);
        PlayerPrefs.SetInt("TodayPlan", value ? 1 : 0);
    }

    protected override void OnClick()
    {
        _isActive = !_isActive;
        
        ChangeValue(_isActive);
        
    }
}