using TMPro;
using UnityEngine;

public class ProfileInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _weightText;
    [SerializeField] private TMP_Text _heightText;
    [SerializeField] private TMP_Text _ageText;

    private void OnEnable()
    {
        Show();
    }

    private void Start()
    {
        Show();
    }

    private void Show()
    {
        _nameText.text = PlayerPrefs.GetString("Name");
        _weightText.text = PlayerPrefs.GetInt("Weight").ToString();
        _heightText.text = PlayerPrefs.GetInt("Height").ToString();
        _ageText.text = PlayerPrefs.GetInt("Age").ToString();
    }
}