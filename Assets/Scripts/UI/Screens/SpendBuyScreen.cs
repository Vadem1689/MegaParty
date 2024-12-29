using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpendBuyScreen : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private int[] _price;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Image _buyButtonImage;
    [SerializeField] private Sprite _onBuy;
    [SerializeField] private Sprite _offBuy;

    private int _defaultValue = 0;

    private void OnEnable()
    {
        ChangeValue();
    }

    private void ChangeValue()
    {
        int index = PlayerPrefs.GetInt("SpendItem", _defaultValue);
        bool value = _wallet.CurrentBonuses >= _price[index];
        _icon.sprite = _sprites[index];
        _priceText.text = $" New Icon\n{_price[index]} bonus";
        
        if (value)
            _description.text = $"  On your account {_wallet.CurrentBonuses} bonuses";
        else
            _description.text =
                $"   There are {_wallet.CurrentBonuses} bonuses in your account. This is not enough to buy";


        _buyButtonImage.sprite = value == true ? _onBuy : _offBuy;
        _buyButton.interactable = value == true ? true : false;
    }
}