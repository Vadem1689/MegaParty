using TMPro;
using UnityEngine;

public class InputValidator : AbstractButton
{
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private TMP_InputField _ageInputField;
    [SerializeField] private TMP_InputField _weightInputField;
    [SerializeField] private TMP_InputField _heightInputField;
    [SerializeField] private TMP_Dropdown _genderDropdown;
    [SerializeField] private HomeScreen _homeScreen;
    [SerializeField] private GameObject _requestScreen; 
    [SerializeField]private PageSwitcher _pageSwitcher;
    
    protected override void OnClick()
    {
        ValidateInput();
    }

    private void ValidateInput()
    {
        string selectedGender = _genderDropdown.options[_genderDropdown.value].text;

        if (IsValidName(_nameInputField.text) && IsValidInteger(_ageInputField.text) &&
            IsValidInteger(_weightInputField.text) && IsValidInteger(_heightInputField.text))
        {
            PlayerPrefs.SetString("Name", _nameInputField.text);
            PlayerPrefs.SetInt("Age", int.Parse(_ageInputField.text));
            PlayerPrefs.SetInt("Weight", int.Parse(_weightInputField.text));
            PlayerPrefs.SetInt("Height", int.Parse(_heightInputField.text));
            PlayerPrefs.SetInt("Gender", _genderDropdown.value);
            _requestScreen.SetActive(false);
            _pageSwitcher.ShowPage(0);
            // _homeScreen.gameObject.SetActive(true);
            PlayerPrefs.SetInt("StartGame", 1);
        }
        else
        {
            Debug.LogError("Одно или несколько полей содержат некорректные символы.");
        }
    }

    private bool IsValidInteger(string input)
    {
        int result;
        return int.TryParse(input, out result);
    }

    private bool IsValidName(string input)
    {
        return !string.IsNullOrWhiteSpace(input) && System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z]+$");
    }
}