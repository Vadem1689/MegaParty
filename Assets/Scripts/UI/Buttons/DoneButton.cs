using UnityEngine;

public class DoneButton : AbstractButton
{
    [SerializeField] private StatScreen _statScreen;
    [SerializeField] private int _index;
    
    protected override void OnClick()
    {
        _statScreen.AddLastWorkout(_index);
    }
}
