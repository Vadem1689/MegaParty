using UnityEngine;

public class PageSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] _pages;

    private void Start()
    {
        // ShowPage(0);
    }

    public void ShowPage(int index)
    {
        foreach (var page in _pages)
            page.SetActive(false);

        _pages[index].SetActive(true);
    }
}