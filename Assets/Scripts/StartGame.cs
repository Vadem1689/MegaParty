using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _request;
    [SerializeField]private PageSwitcher _pageSwitcher;
    
    private int _defaultValue = 0;

    private void Start()
    {
        int value = PlayerPrefs.GetInt("StartGame", _defaultValue);

        if (value <= 0)
            _request.SetActive(true);
        else
        {
            _pageSwitcher.ShowPage(0);
            _request.SetActive(false);
        }
    }
}