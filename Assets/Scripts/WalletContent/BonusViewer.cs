using TMPro;
using UnityEngine;

public class BonusViewer : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _bonusText;

    private void OnEnable()
    {
        _bonusText.text = _wallet.CurrentBonuses.ToString();
        _wallet.BonusesChanged += Show;
    }

    private void OnDisable()
    {
        _wallet.BonusesChanged -= Show;
    }

    private void Start()
    {
        _bonusText.text = _wallet.CurrentBonuses.ToString();
    }

    private void Show(int value)
    {
        _bonusText.text = value.ToString();
    }
}