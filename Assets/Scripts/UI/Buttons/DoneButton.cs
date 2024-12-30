using UnityEngine;

public class DoneButton : AbstractButton
{
    [SerializeField] private StatScreen _statScreen;
    [SerializeField] private int _index;
    [SerializeField] private GameObject _screen;
    [SerializeField] private GameObject _effect;
    [SerializeField] private Transform _container;
    [SerializeField] private Sound _sound;

    protected override void OnClick()
    {
        _statScreen.AddLastWorkout(_index);
        _screen.gameObject.SetActive(false);

        GameObject spawnedObject = Instantiate(_effect, transform.position, transform.rotation);
        spawnedObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        spawnedObject.transform.SetParent(_container);
        Vector3 newPosition = spawnedObject.transform.localPosition;
        newPosition.y=-36f;
        newPosition.z = 15f;
        spawnedObject.transform.localPosition = newPosition;
        _sound.PlayDone();

        // Instantiate(_effect, _container,transform);
    }
}