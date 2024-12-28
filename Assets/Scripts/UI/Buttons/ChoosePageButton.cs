using UnityEngine;

public class ChoosePageButton : AbstractButton
{
    [SerializeField] private PageSwitcher _pageSwitcher;
    [SerializeField] private int _index;

    protected override void OnClick()
    {
        _pageSwitcher.ShowPage(_index);
    }
}