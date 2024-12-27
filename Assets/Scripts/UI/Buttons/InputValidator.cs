using TMPro;
using UnityEngine;

public class InputValidator : AbstractButton
{
    [SerializeField] private TMP_InputField _ageInputField;
    [SerializeField] private TMP_InputField _weightInputField;
    [SerializeField] private TMP_InputField _heightInputField;
    [SerializeField]private TMP_Dropdown  _genderDropdown;

    protected override void OnClick()
    {
        ValidateInput();
    }

    private void ValidateInput()
    {
        string selectedGender = _genderDropdown.options[_genderDropdown.value].text;
        
        if (IsValidInteger(_ageInputField.text) && IsValidInteger(_weightInputField.text) &&
            IsValidInteger(_heightInputField.text))
        {
           PlayerPrefs.SetInt("Age", int.Parse(_ageInputField.text));
           PlayerPrefs.SetInt("Weight", int.Parse(_weightInputField.text));
           PlayerPrefs.SetInt("Height", int.Parse(_heightInputField.text));
           PlayerPrefs.SetInt("Gender", _genderDropdown.value);
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
}