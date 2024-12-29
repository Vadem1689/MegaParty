using UnityEngine;

public class SelectSpendBonuses : AbstractButton
{
    [SerializeField] private int _index;
    [SerializeField] private SpendBuyScreen _spendBuyScreen;
    
    protected override void OnClick()
    {
        PlayerPrefs.SetInt("SpendItem", _index);
        _spendBuyScreen.gameObject.SetActive(true);
    }
}
