using System.Collections;
using UnityEngine;

public class InfoScreen : MonoBehaviour
{
    [SerializeField] private GameObject _infoButton;
  
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
    
    private void OnEnable()
    {
        StartCloseInfo();
    }

    private void StartCloseInfo()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(CloseInfo());
    }
    
    private IEnumerator CloseInfo()
    {
        yield return _waitForSeconds;
        _infoButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
