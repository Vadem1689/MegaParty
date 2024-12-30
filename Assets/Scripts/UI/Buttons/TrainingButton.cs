using UnityEngine;

public class TrainingButton : AbstractButton
{
    [SerializeField] private int _index;
    [SerializeField] private WorkoutSwitcher _workoutSwitcher;

    protected override void OnClick()
    {
        _workoutSwitcher.Show(_index);
    }
}