using TMPro;
using UnityEngine;

public class WheelScreen : MonoBehaviour
{
    [SerializeField] private GameObject _nextSpin; 
    [SerializeField] private GameObject _canSpin;
    [SerializeField] private TMP_Text _nextSpinTimeText;
    [SerializeField] private SpeenButton _nextSpinButton;
    
    private void OnEnable()
    {
        
    }

    private void Start()
    {
        
    }

    private void ShowTimeNextSpin()
    {
        _nextSpinButton.DeactivateButton();
 
    }

    private void ShowCanSpeed()
    {
        _nextSpinButton.ActivateButton();
    }
}
