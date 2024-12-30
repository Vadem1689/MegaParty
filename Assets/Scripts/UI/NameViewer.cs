using TMPro;
using UnityEngine;

public class NameViewer : MonoBehaviour
{
    [SerializeField]private TMP_Text _nameText;
    
    private void OnEnable()
    {
        _nameText.text = PlayerPrefs.GetString("Name");
    }
}
